using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace DownloaderHTTP
{
    public class LoaderList
    {
        public List<FileLoaderInterfaceAdaptation> downloaderList;
        public int numberOfWorkerThreads;


        public LoaderList()
        {
            this.numberOfWorkerThreads = 1;
            downloaderList = new List<FileLoaderInterfaceAdaptation>();
        }

        public void AddDownload(FileLoaderInterfaceAdaptation fileLoader)
        {
            downloaderList.Add(fileLoader);
        }

        public async Task StartLoad()
        {
            int i = 0;
            FileLoaderInterfaceAdaptation.numberOfThreads = numberOfWorkerThreads;
            foreach (var download in downloaderList)
            {
                try
                {
                    download.CreateDownloadInterface(i);
                    //download.fileLoader.activThread = new Thread(delegate () { download.StartLoad(); });
                    i++;
                }
                catch (Exception e)
                { }
            }

            foreach (var download in downloaderList)
            {
               // download.fileLoader.activThread.Start();
                download.StartLoad().Start();
            }
        }
    }

    public class FileLoaderInterfaceAdaptation
    {
        public FileLoader fileLoader;
        public Button buttonStop;
        public Button buttonStart;
        public Button buttonDelete;
        public Label labelNameFile;
        public Label labelStatysLoad;
        public ProgressBar progressBar;
        private readonly TabControl tabControl;
        public static int numberOfThreads;
        private static int fairNumberOfThreads;
        public static bool IsAllDownloadFinished;
        private static Semaphore sem;
        public FileLoaderInterfaceAdaptation(string downloadFolder, string nameLoadFile, string serverUrl, TabControl tabControl) : 
            this(downloadFolder, nameLoadFile, serverUrl, 5, 1, tabControl) { }

        public FileLoaderInterfaceAdaptation(string downloadFolder, string nameLoadFile, string serverUrl,
            int chunkMultiplier, int countThread, TabControl tabControl)
        {
            fileLoader = new FileLoader(downloadFolder, nameLoadFile, serverUrl, chunkMultiplier);
            this.tabControl = tabControl;
            numberOfThreads = countThread;
            fairNumberOfThreads = 0;
            IsAllDownloadFinished = false;
            sem = new Semaphore(countThread, countThread);
        }
        public void Click_buttonDelete(object sender, EventArgs e)
        {
            fileLoader.DeleteDownload();
            labelStatysLoad.Text = "Удалён";
            labelStatysLoad.ForeColor = Color.Red;
            
        }
        public void Click_buttonStop(object sender, EventArgs e)
        {
            labelStatysLoad.ForeColor = Color.BlueViolet;
            labelStatysLoad.Text = "Остановленно";
            fileLoader.StopDownload();
           // fileLoader.activThread = new Thread(delegate () { StartLoad(); });
        }

        public void Click_buttonStart(object sender, EventArgs e)
        {
            try
            {
                if (IsNotMaxTreads())
                {
                    if (!fileLoader.IsDownloadFinished)
                    {
                        labelStatysLoad.Text = "Загрузка";
                        labelStatysLoad.ForeColor = Color.Green;
                        Task.Run(StartLoad);
                        //fileLoader.activThread.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Максимальное количество одновременных загрузок", "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task StartLoad()
        {

            while (!IsAllDownloadFinished)
            {
                //sem.WaitOne();
                if (!fileLoader.IsDownloadFinished)
                {
                    if (fileLoader.IsDownloading)
                        continue;
                    if (IsNotMaxTreads())
                        try
                        {
                            if (!fileLoader.IsDownloading)
                            {
                                fairNumberOfThreads++;
                                labelStatysLoad.Text = "Загрузка";
                                labelStatysLoad.ForeColor = Color.Green;
                                fileLoader.StartLoad().Wait();
                                fairNumberOfThreads--;
                            }
                        }
                        catch (Exception e)
                        {
                            fileLoader.StartLoad().Wait();
                            fairNumberOfThreads--;
                        }
                        finally
                        {
                            labelStatysLoad.Text = "Загрузка";
                            labelStatysLoad.ForeColor = Color.Green;
                        }
                }
                Task.Delay(500).Wait();
                //sem.Release();
            }
        }

        private static bool IsNotMaxTreads()
        {
            return numberOfThreads > fairNumberOfThreads;
        }
        public async Task CreateDownloadInterface(int downloadNumber)
        {
            buttonDelete = new Button();
            buttonStop = new Button();
            buttonStart = new Button();
            labelNameFile = new Label();
            labelStatysLoad = new Label();
            progressBar = new ProgressBar();
            SetSettingsLabel(new Point(2, NextHeightPoint(downloadNumber)), new Size(210, 27), fileLoader.nameLoadFile, labelNameFile);
            SetSettingsLabel(new Point(210, NextHeightPoint(downloadNumber)), new Size(80, 27), "Остановленно", labelStatysLoad);
            SetSettingsProgressBar(new Point(290, NextHeightPoint(downloadNumber)), new Size(260, 27), progressBar);
            SetSettingsButton(new Point(700, NextHeightPoint(downloadNumber)), new Size(70, 27), "Delete", buttonDelete, Click_buttonDelete);
            SetSettingsButton(new Point(630, NextHeightPoint(downloadNumber)), new Size(60, 27), "Stop", buttonStop, Click_buttonStop);
            SetSettingsButton(new Point(560, NextHeightPoint(downloadNumber)), new Size(60, 27), "Start", buttonStart, Click_buttonStart);
        }

        private int NextHeightPoint(int point)
        {
            int defoliateCoordinate = 6;
            if (point == 0) return defoliateCoordinate;
            return 32 * point + defoliateCoordinate;
        }

        private void SetSettingsButton(Point point, Size size, string text, Button button, Action<object, EventArgs> clickEvent)
        {
            //button.Name = name;
            button.Text = text;
            button.Location = point;
            button.Size = size;
            button.Click += new EventHandler(clickEvent);
            try
            {
                tabControl.TabPages[1].Controls.Add(button);
            }
            catch (Exception e)
            {
                tabControl.TabPages[1].Controls.Add(button);
            }
            
        }

        private void SetSettingsProgressBar(Point point, Size size, ProgressBar progressBar)
        {
            progressBar.Location = point;
            progressBar.Size = size;
            tabControl.TabPages[1].Controls.Add(progressBar);
        }

        private void SetSettingsLabel(Point point, Size size, string text, Label label)
        {
            label.Text = text;
            label.Location = point;
            label.AutoSize = true;
            label.MaximumSize = size;
            tabControl.TabPages[1].Controls.Add(label);
            if (label.Text == "Остановленно")
                label.ForeColor = Color.BlueViolet;
        }
    }
}


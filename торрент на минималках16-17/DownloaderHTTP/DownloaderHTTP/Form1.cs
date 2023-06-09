using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DownloaderHTTP.Extensions;
using DownloaderHTTP.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DownloaderHTTP
{
    public partial class Form1 : Form
    {
        private readonly string serverUrl = "http://127.0.0.1:8888";
        private LoaderList loaderList = new LoaderList();
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var files = await GetAllFiles(serverUrl).ConfigureAwait(false);
                if (files == null)
                {
                    throw new Exception("Ошибка");
                }

                foreach (var file in files)
                {
                    dataGridViewAvailableFiles.Rows.Add(file);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string[]> GetAllFiles(string serverUrl)
        {
            return await HttpDialog.GetRequestAndResponseStringArreyAsync(serverUrl, "/AllFiles").ConfigureAwait(false);
        }

        private void AddDownloadListFile()
        {
            if (dataGridViewAvailableFiles.CurrentCell.Value == null) return;
            dataGridViewDownloadFiles.Rows.Add(dataGridViewAvailableFiles.CurrentCell.Value);
            dataGridViewAvailableFiles.Rows.RemoveAt(dataGridViewAvailableFiles.CurrentRow.Index);
        }

        private void DeleteDownloadListFile()
        {
            if (dataGridViewDownloadFiles.CurrentCell.Value == null) return;
            dataGridViewAvailableFiles.Rows.Add(dataGridViewDownloadFiles.CurrentCell.Value);
            dataGridViewDownloadFiles.Rows.RemoveAt(dataGridViewDownloadFiles.CurrentRow.Index);
        }


        private void buttonDownloadFiles_Click_1(object sender, EventArgs e)
        {
            Task.Run(Download);
        }

        private void buttonDeletDownloadFile_Click_1(object sender, EventArgs e)
        {
            DeleteDownloadListFile();
        }

        private void buttonAddDownloadFile_Click_1(object sender, EventArgs e)
        {
            AddDownloadListFile();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void buttonChooseDownloadFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDownloadFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private async Task Download()
        {
            try
            {
                CreateDownloadList();
                Task.Run(loaderList.StartLoad);
                Invoke((MethodInvoker)delegate
                {
                    tabControl1.SelectedIndex = 1;
                });
                Task.Run(CheckProgress);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void CreateDownloadList()
        {
            for (int i = 0; i < dataGridViewDownloadFiles.Rows.Count-1; i++)
            {
                var downloadFolder = textBoxDownloadFolder.Text;
                var nameFile = dataGridViewDownloadFiles.Rows[i].Cells[0].Value.ToString();
                var sizePages = int.Parse(textBoxPacketSize.Text);
                var countThread = int.Parse(textBoxCountThread.Text);
                loaderList.AddDownload(
                    new FileLoaderInterfaceAdaptation(downloadFolder, nameFile, serverUrl, sizePages, countThread, tabControl1));
            }
        }
        private async Task CheckProgress()
        {
            Task.Delay(500).Wait();
            while (loaderList.downloaderList[0].fileLoader.IsDownloadFinished == false)
            {
                var countReady = 0;
                foreach (var download in loaderList.downloaderList.Where(download => download.progressBar!=null))
                {
                    Invoke((MethodInvoker)delegate
                    {
                        if (download.progressBar.Value < 100)
                            download.progressBar.Value = (int)(download.fileLoader.progress * 100);
                        else
                        {
                            download.labelStatysLoad.Text = "Завершено";
                            download.labelStatysLoad.ForeColor = Color.Aqua;
                            countReady++;
                        }
                    });
                }
                if (countReady == loaderList.downloaderList.Count)
                    loaderList.downloaderList[0].fileLoader.IsDownloadFinished = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SeekerOfForbidden;

namespace seeker_of_forbiden_Window
{
    public partial class Form1 : Form
    {
        private SeekerOfForbiddenClass censor = new SeekerOfForbiddenClass();
        public Form1()
        {
            InitializeComponent();
            labelSearchDrectoryPath.Visible = false;
            textBoxSearchDrectoryPath.Visible = false;
            buttonEnterSearchDrectoryPath.Visible = false;
            buttonChooseSearchDrectoryPath.Visible = false;
            //checkBoxReportOnly.Checked = true;
            progressBarFileSearch.Maximum = 0;
            progressBarSearchForBidden.Maximum = 0;
            buttonContinu.Enabled=false;
            buttonPause.Enabled=false;
            buttonCancel.Enabled=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void KeepThePath(TextBox tb, ref string appointment)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                tb.Text = openFolderDialog.SelectedPath;
                appointment = openFolderDialog.SelectedPath;
            }
        }

        private void ButtonEnterPathToTheForbiddenWordsDictionary_Click(object sender, EventArgs e)
        {
            censor.pathToTheForbiddenWordsDictionary = textBoxPathToTheForbiddenWordsDictionary.Text;
        }

        private void ButtonChoosePathToTheForbiddenWordsDictionary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxPathToTheForbiddenWordsDictionary.Text = censor.pathToTheForbiddenWordsDictionary = openFileDialog.FileName;
            }
        }

        private void ButtonEnteringForbiddenWords_Click(object sender, EventArgs e)
        {
            censor.listOfForBiddenWords.AddRange(textBoxEnteringForbiddenWords.Text
                .Split(new string[] { " ", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void ButtonEnterFolderPathForFilesWithForbiddenWords_Click(object sender, EventArgs e)
        {
            censor.folderPathForFilesWithForbiddenWords = textBoxFolderPathForFilesWithForbiddenWords.Text;
        }

        private void ButtonChooseFolderPathForFilesWithForbiddenWords_Click(object sender, EventArgs e)
        {
            KeepThePath(textBoxFolderPathForFilesWithForbiddenWords, ref censor.folderPathForFilesWithForbiddenWords);
        }

        private void ButtonEnterPathToTheReportFile_Click(object sender, EventArgs e)
        {
            censor.pathToTheReportFile = textBoxPathToTheReportFile.Text;
        }

        private void ButtonChoosePathToTheReportFile_Click(object sender, EventArgs e)
        {
            KeepThePath(textBoxPathToTheReportFile,ref censor.pathToTheReportFile);
        }

        private void ButtonEnterSearchDrectoryPath_Click(object sender, EventArgs e)
        {
            censor.searchDrectoryPath = textBoxSearchDrectoryPath.Text;
        }

        private void ButtonChooseSearchDrectoryPath_Click(object sender, EventArgs e)
        {
            KeepThePath(textBoxSearchDrectoryPath,ref censor.searchDrectoryPath);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            labelSearchDrectoryPath.Visible = !labelSearchDrectoryPath.Visible;
            textBoxSearchDrectoryPath.Visible = !textBoxSearchDrectoryPath.Visible;
            buttonEnterSearchDrectoryPath.Visible = !buttonEnterSearchDrectoryPath.Visible;
            buttonChooseSearchDrectoryPath.Visible = !buttonChooseSearchDrectoryPath.Visible;
            OnOrOffSearchAcrossAllDrives();
        }

        private void OnOrOffSearchAcrossAllDrives()
        {
            censor.searchAcrossAllDrives = !censor.searchAcrossAllDrives;
            if (censor.searchAcrossAllDrives)
            {
                censor.searchDrectoryPath = "";
            }
        }

        private void CheckBoxReportOnly_CheckedChanged(object sender, EventArgs e)
        {
            censor.reportOnly=!censor.reportOnly;
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEnabledOffOrOn();
                buttonPause.Enabled = true;
                buttonCancel.Enabled = true;
                progressBarFileSearch.Value = 0;
                progressBarSearchForBidden.Value = 0;
                progressBarSearchForBidden.Maximum = 0;
                progressBarFileSearch.Maximum = 0;
                labelTheEnd.Visible = false;
               // Task.WhenAll(Task.Run(checkProgressBar), Task.Run(Start));
                Task.Run(checkProgressBar);
                Task.Run(Start);
               

                // checkProgressBar();
                //await Task.Run(Start);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void ButtonEnabledOffOrOn()
        {
            buttonChooseSearchDrectoryPath.Enabled = !buttonChooseSearchDrectoryPath.Enabled;
            buttonChooseFolderPathForFilesWithForbiddenWords.Enabled = !buttonChooseFolderPathForFilesWithForbiddenWords.Enabled;
            buttonChoosePathToTheForbiddenWordsDictionary.Enabled = !buttonChoosePathToTheForbiddenWordsDictionary.Enabled;
            buttonChoosePathToTheReportFile.Enabled = !buttonChoosePathToTheReportFile.Enabled;
            buttonEnterFolderPathForFilesWithForbiddenWords.Enabled = !buttonEnterFolderPathForFilesWithForbiddenWords.Enabled;
            buttonEnterPathToTheForbiddenWordsDictionary.Enabled = !buttonEnterPathToTheForbiddenWordsDictionary.Enabled;
            buttonEnterPathToTheReportFile.Enabled = !buttonEnterPathToTheReportFile.Enabled;
            buttonEnterSearchDrectoryPath.Enabled = !buttonEnterSearchDrectoryPath.Enabled;
            buttonEnteringForbiddenWords.Enabled = !buttonEnteringForbiddenWords.Enabled;
            buttonStart.Enabled = !buttonStart.Enabled;
        }

        private void CompletinAaTask()
        {
            Invoke((MethodInvoker)delegate
            {
                
                labelTheEnd.Visible = true;
                buttonStart.Enabled = true;
                ButtonEnabledOffOrOn();
                labelTheEnd.Text = "Готово";
                labelTheEnd.ForeColor = Color.Green;
                buttonStart.Enabled = true;
                buttonContinu.Enabled=false;
                buttonPause.Enabled= false;
                buttonCancel.Enabled=false;
                //progressBarFileSearch.Value = 0;
                //progressBarSearchForBidden.Value= 0;
                //progressBarSearchForBidden.Maximum = 0;
                //progressBarFileSearch.Maximum = 0;
            });
            censor.Dispools();
        }

        private async Task Start()
        {
            try
            {
                censor.StartAutoSearchingAndFix();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
           
        }

        private async Task checkProgressBar()
        {
            try
            {
                while (progressBarFileSearch.Maximum < 1)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        progressBarFileSearch.Maximum = SeekerOfForbiddenClass.castomProgressBarFileSearch.Maximum;
                        //progressBarSearchForBidden.Value = censor.castomProgressBarSearchForForbidden.Value;
                    });
                    await Task.Delay(200);
                }
                while (progressBarFileSearch.Value < progressBarFileSearch.Maximum)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        progressBarFileSearch.Value = SeekerOfForbiddenClass.castomProgressBarFileSearch.Value;
                        //progressBarSearchForBidden.Value = censor.castomProgressBarSearchForForbidden.Value;
                    });
                    await Task.Delay(200);
                }
                while (progressBarSearchForBidden.Maximum < 1)
                {
                    Invoke((MethodInvoker)delegate
                    {
                       
                        progressBarSearchForBidden.Maximum = censor.castomProgressBarSearchForForbidden.Maximum;
                    });
                    await Task.Delay(200);
                }
                while (progressBarSearchForBidden.Value < progressBarSearchForBidden.Maximum)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        progressBarSearchForBidden.Value = censor.castomProgressBarSearchForForbidden.Value;
                    });
                    await Task.Delay(200);
                }
                CompletinAaTask();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
           
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            censor.Pause();
            buttonContinu.Enabled = !buttonContinu.Enabled;
            buttonPause.Enabled = !buttonPause.Enabled;
        }

        private void buttonContinu_Click(object sender, EventArgs e)
        {
            censor.Resume();
            buttonContinu.Enabled = !buttonContinu.Enabled;
            buttonPause.Enabled = !buttonPause.Enabled;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonCancel.Enabled = !buttonCancel.Enabled;
            censor.Cancel();
            buttonPause.Enabled = false;
            buttonContinu.Enabled = false;
            labelTheEnd.ForeColor = Color.Red;
            labelTheEnd.Text = "Задача отменена";
            labelTheEnd.Visible = true;
            buttonStart.Enabled = true;
            ButtonEnabledOffOrOn();
        }
    }
}

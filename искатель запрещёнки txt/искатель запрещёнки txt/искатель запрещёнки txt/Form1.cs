using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace искатель_запрещёнки_txt
{
    public partial class Form1 : Form
    {
        private string path = Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\");
        Process process = new Process();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCmd_Click(object sender, EventArgs e)
        {
            var pathProgramm = Path.Combine(path, "seeker of forbidden cmd\\bin\\Debug\\seeker of forbidden cmd.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo(pathProgramm);
            startInfo.WorkingDirectory = Path.GetDirectoryName(pathProgramm);
            try
            {
                if (!IsRunning(process.Id))
                    process = Process.Start(startInfo);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                process = Process.Start(startInfo);
            }
            //this.Enabled = false;
        }

        private void buttonWindow_Click(object sender, EventArgs e)
        {

            var pathProgramm = Path.Combine(path, "seeker of forbiden Window\\bin\\Debug\\seeker of forbiden Window.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo(pathProgramm);
            startInfo.WorkingDirectory = Path.GetDirectoryName(pathProgramm);
            try
            {
                if (!IsRunning(process.Id))
                    process = Process.Start(startInfo);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                process = Process.Start(startInfo);
            }


            //this.Enabled=false;
        }
        static bool IsRunning(int id)
        {
            try
            {
                Process.GetProcessById(id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

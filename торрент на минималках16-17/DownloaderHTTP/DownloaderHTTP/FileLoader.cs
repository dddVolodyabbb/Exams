using DownloaderHTTP.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloaderHTTP
{
    public class FileLoader
    {
        public Thread activThread;
        public double progress;
        private long loadFileSize;
        private long loadedByte;
        private int sizeChank = 1024 * 1024;
        private int chunkMultiplier;
        private string downloadFolder;
        private string serverUrl;
        public string nameLoadFile;
        public bool IsDownloading;
        public bool IsDownloadFinished;

        public FileLoader(string downloadFolder, string nameLoadFile, string serverUrl) : this(downloadFolder, nameLoadFile, serverUrl, 5) { }

        public FileLoader(string downloadFolder, string nameLoadFile, string serverUrl, int chunkMultiplier)
        {
            this.nameLoadFile = nameLoadFile;
            this.serverUrl = serverUrl;
            this.downloadFolder = downloadFolder;
            this.chunkMultiplier = chunkMultiplier;
            sizeChank *= chunkMultiplier;
            progress = 0;
            loadedByte = 0;
            loadFileSize = FindOutFileSize().Result;
            IsDownloading = false;
            IsDownloadFinished = false;
        }

        private async Task<long> FindOutFileSize()
        {
            var fileSize = await HttpDialog.GetRequestAndResponseStringAsync(serverUrl, Path.Combine("/SizeFile", nameLoadFile)).ConfigureAwait(false);
            if (fileSize == null)
            {
                MessageBox.Show("Ошибка загрузки размера файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("Ошибка загрузки размера файла");

            }
            return long.Parse(fileSize);
        }

        public void StopDownload()
        {
            IsDownloading = false;
        }

        public void DeleteDownload()
        {
            StopDownload();
            Task.Delay(100);
            File.Delete(Path.Combine(downloadFolder, nameLoadFile));
        }

        public async Task StartLoad()
        {
            int filePartCount = (int)(loadFileSize - loadedByte / sizeChank);
            using (FileStream outputFile = new FileStream(Path.Combine(downloadFolder, nameLoadFile), FileMode.Create, FileAccess.Write))
            {
                IsDownloading = true;
                outputFile.Seek(loadedByte, SeekOrigin.Begin);
                while (loadedByte < loadFileSize && IsDownloading)
                {
                    try
                    {
                        var request = Path.Combine("/DownloadFile", nameLoadFile, loadedByte.ToString(),
                            chunkMultiplier.ToString());
                        var filePart = await HttpDialog.GetRequestAndResponseByteArreyAsync(serverUrl, request)
                            .ConfigureAwait(false);
                        if (filePart == null)
                        {
                            throw new Exception("Ошибка загрузки файла");
                        }

                        await outputFile.WriteAsync(filePart, 0, filePart.Length).ConfigureAwait(false);
                        loadedByte += filePart.Length;
                        progress = ((double)loadedByte / loadFileSize);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if(loadFileSize== loadedByte)
                    IsDownloadFinished = true;
                IsDownloading = false;
            }
        }
    }
}

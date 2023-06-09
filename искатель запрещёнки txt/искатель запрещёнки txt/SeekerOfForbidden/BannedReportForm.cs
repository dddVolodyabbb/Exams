using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekerOfForbidden
{
    /// <summary>
    /// Класс хранит путь и размер файла, количество и список запрещённых слов
    /// </summary>
    public class BannedReportForm
    {
        /// <summary>
        /// путь к файлу
        /// </summary>
        public string filePath;
        /// <summary>
        /// размер файла в байтах
        /// </summary>
        public long fileSize;
        /// <summary>
        /// количество запрещенных слов
        /// </summary>
        public int numberOfForbiddenWords;
        /// <summary>
        /// список запрещенных слов
        /// </summary>
        public List<string> foundForbiddenWordsList;

        public BannedReportForm(string filePath)
        {
            this.filePath = filePath;
            GetSizeFileByte();
            foundForbiddenWordsList = new List<string>();
        }

        /// <summary>
        /// Вычисляет размер файла
        /// </summary>
        private void GetSizeFileByte()
        {
            fileSize = (new FileInfo(filePath).Length);
        }
    }
}

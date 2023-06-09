using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

namespace SeekerOfForbidden
{
    public class SeekerOfForbiddenClass
    {
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        private static CancellationToken token = cancelTokenSource.Token;
        private bool paused;
        /// <summary>
        /// Объект для управления работой (пауза продолжить)
        /// </summary>
        public static object syncObj = new object();
        /// <summary>
        /// Погресс бар для поиска файлов</summary>
        public static CastomProgressBar castomProgressBarFileSearch;

        /// <summary>
        /// Прогресс бар для поиска запрещёнки
        /// </summary>
        public CastomProgressBar castomProgressBarSearchForForbidden;

        /// <summary>
        /// Путь конкретной директории для поиска запрещёнки.
        /// </summary>
        public string searchDrectoryPath;

        /// <summary>
        /// путь к словарю запрещенных слов
        /// </summary>
        public string pathToTheForbiddenWordsDictionary;

        /// <summary>
        /// Путь к папке с файлами с запрещенными словами
        /// </summary>
        public string folderPathForFilesWithForbiddenWords;

        /// <summary>
        /// Путь к папке с файломи отчётами
        /// </summary>
        public string pathToTheReportFile;

        /// <summary>
        /// Список отчётов
        /// </summary>
        public List<BannedReportForm> reportsList;

        /// <summary>
        /// Загруженный список запрещённых слов
        /// </summary>
        public readonly List<string> listOfForBiddenWords;

        /// <summary>
        /// Пути всех найденных файло с запрещёнкой
        /// </summary>
        //private List<string> allFoundPathsWithABan;
        /// <summary>
        /// Если true то отключаются исправления и перенос оригиналов в другую папку 
        /// </summary>
        public bool reportOnly;

        /// <summary>
        /// Если true то сканируются все накопители
        /// </summary>
        public bool searchAcrossAllDrives;

        /// <summary>
        /// Счётчик для ускоренного сканирования папок
        /// </summary>
        private static int countIToProgressBar;

        /// <summary>
        /// создаёт класс для поиска запрещёнки с сохраняемыми папками в корне и
        /// стандартным набором запрещённых слов
        /// </summary>
        public SeekerOfForbiddenClass()
        {
            // allFoundPathsWithABan = new List<string>();
            reportsList = new List<BannedReportForm>();
            listOfForBiddenWords = new List<string>();
            reportOnly = true;
            searchAcrossAllDrives = true;
            countIToProgressBar = 0;
            castomProgressBarFileSearch = new CastomProgressBar();
            castomProgressBarSearchForForbidden = new CastomProgressBar();
        }

        /// создаёт класс для поиска запрещёнки
        /// </summary>
        /// <param name="pathToTheForbiddenWordsDictionary">путь к словарю запрещенных слов</param>
        /// <param name="folderPathForFilesWithForbiddenWords">путь к папке для файлов с запрещенными словами</param>
        /// <param name="pathToTheReportFile">Путь к файлу отчёта</param>
        public SeekerOfForbiddenClass(string pathToTheForbiddenWordsDictionary, string folderPathForFilesWithForbiddenWords, string pathToTheReportFile) : base()
        {
            this.pathToTheForbiddenWordsDictionary = pathToTheForbiddenWordsDictionary;
            this.folderPathForFilesWithForbiddenWords = folderPathForFilesWithForbiddenWords;
            this.pathToTheReportFile = pathToTheReportFile;
        }



        /// <summary>
        /// Начать поиск и исправление
        /// </summary>
        /// <param name="searchAcrossAllDrives">true - Поиск по всем доступным накопителям</param>
        public async Task StartAutoSearchingAndFix()
        {
            try
            {
                AllFolderPaths();
                CalculatingTheNumberForTheProgressBar();
                castomProgressBarFileSearch.SetMaxProgressBar();
                if (searchAcrossAllDrives)
                    GetAllDirectoriesForBannedWords();
                else
                    GetDirectoryPathForBannedWords();
                castomProgressBarSearchForForbidden.SetMaxProgressBar(reportsList.Count);
                SearchForForbiddenWords();
                CreateAReport();
                BannedPopularityReport();
                //Dispools();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Проверка и заполнение всех путей до папок
        /// </summary>
        /// <returns></returns>
        private void AllFolderPaths()
        {
            FindingOrCreatingAReportFile();
            SearchOrCreateAFolderWithForbiddenWords();
            ReadForbiddenWords();

        }
        /// <summary>
        /// Поиск или создание папки для файла с отчётом
        /// </summary>
        private void FindingOrCreatingAReportFile()
        {
            if (string.IsNullOrEmpty(pathToTheReportFile))
            {
                pathToTheReportFile =
                    Path.Combine("D:\\testPoligon", "Reports");
                Directory.CreateDirectory(pathToTheReportFile);
            }

            if (!IsCorrectPuth(pathToTheReportFile))
                Directory.CreateDirectory(pathToTheReportFile);
            // throw new Exception("Данный файл не коректен или не существует");
        }

        /// <summary>
        /// поиск или создание папки с файлами с запрещёнными словами
        /// </summary>
        private void SearchOrCreateAFolderWithForbiddenWords()
        {
            if (string.IsNullOrEmpty(folderPathForFilesWithForbiddenWords))
            {
                folderPathForFilesWithForbiddenWords =
                    Path.Combine("D:\\testPoligon", "Files with forbidden words");
                Directory.CreateDirectory(folderPathForFilesWithForbiddenWords);
            }
            if (!IsCorrectPuth(folderPathForFilesWithForbiddenWords))
                Directory.CreateDirectory(pathToTheReportFile);
            //throw new Exception("Данный путь не коректен или не существует");
        }

        /// <summary>
        /// Загружает запрещённые слова по умолчанию и из файла
        /// </summary>
        private void ReadForbiddenWords()
        {
            listOfForBiddenWords.AddRange(new[] { "едрёнбатон", "полёный", "кактус" });
            if (!string.IsNullOrEmpty(pathToTheForbiddenWordsDictionary) && listOfForBiddenWords.Count == 0)
            {
                IsCorrectFile(pathToTheForbiddenWordsDictionary);
                listOfForBiddenWords.AddRange(File.ReadAllText(pathToTheForbiddenWordsDictionary)
                    .Split(new string[] { " ", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries));
            }
        }

        /// <summary>
        /// Проверка корректности и существования пути
        /// </summary>
        /// <param name="correctPuth">Путь который нужно проверить</param>
        ///  <returns>Возвращает true если папка не будет найденна</returns>
        private bool IsCorrectPuth(string puth)
        {
            if (!Directory.Exists(puth))
                return false;
            return true;
        }

        private bool IsCorrectFile(string puthFile)
        {
            if (!File.Exists(puthFile))
                return false;
            return true;
        }

        /// <summary>
        /// Вызов поиска файлов с запрещёнкой в текущей дерикторрии через функцию MyGetFiles
        /// </summary>
        /// <param name="path">Путь к папке, в которой нужно провести поиск</param>
        private void GetDirectoryPathForBannedWords()
        {
            IsCorrectPuth(searchDrectoryPath);
            List<string> files = new List<string>();
            files = MyGetFiles(searchDrectoryPath, true);
            foreach (var file in files)
            {
                //castomProgressBarFileSearch.ValueIsUp(file);
                reportsList.Add(new BannedReportForm(file));
                //allFoundPathsWithABan.Add(file);
            }
        }
        /// <summary>
        /// Ищет все накопители и вызывает поиск файлов в накопителях через функцию MyGetFiles
        /// </summary>
        private void GetAllDirectoriesForBannedWords()
        {
            IsCorrectPuth(searchDrectoryPath);
            List<string> files = new List<string>();
            foreach (var drive in DriveInfo.GetDrives())
            {
                files = MyGetFiles(drive.Name, true);
                foreach (var file in files)
                {
                    reportsList.Add(new BannedReportForm(file));
                    //allFoundPathsWithABan.Add(file);
                    //castomProgressBarFileSearch.ValueIsUp(file);

                }
            }
        }

        /// <summary>
        /// Производит поиск файлов, оперделённых расширений в определённой папке
        /// </summary>
        /// <param name="path">Путь к папке, в которой нужно провести поиск</param>
        /// <returns>Лист с адресами файлов</returns>
        private static List<string> MyGetFiles(string path, bool progressBar)
        {
            var files = new List<string>();
            try
            {
                files.AddRange(Directory.GetFiles(path, "*.txt")
                    //.Where(s => s.EndsWith() //||
                    //s.EndsWith(".doc") ||
                    //s.EndsWith(".docx"
                    )
                    //)
                    ;
                foreach (var directory in Directory.GetDirectories(path))
                {
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    lock (syncObj) { }
                    if (progressBar)
                        castomProgressBarFileSearch.ValueIsUp(directory);
                    Console.WriteLine(directory);
                    files.AddRange(MyGetFiles(directory, progressBar));

                }

            }
            catch (UnauthorizedAccessException) { }
            return files;
        }

        /// <summary>
        /// Ищет запрещённые слова по пути файлов в списке - отчёте, заполняет отчёт, пикает слова.
        /// </summary>
        private void SearchForForbiddenWords()
        {
            try
            {
                foreach (var reportForm in reportsList)
                {
                    string[] textFileArrey;
                    string[] originFileArrey;
                    castomProgressBarSearchForForbidden.ValueIsUp();
                    try
                    {
                        originFileArrey = File.ReadAllText(reportForm.filePath)
                            .Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        textFileArrey = RemoveSigns(originFileArrey);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                   
                    
                    foreach (var biddenWord in listOfForBiddenWords)
                    {
                        for (var i = 0; i < textFileArrey.Length; i++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                token.ThrowIfCancellationRequested();
                            }
                            lock (syncObj) { }
                            if (textFileArrey[i].Contains(biddenWord))
                            {
                                reportForm.numberOfForbiddenWords++;
                                reportForm.foundForbiddenWordsList.Add(textFileArrey[i]);
                                if (!Char.IsLetter(originFileArrey[i][originFileArrey[i].Length - 1]) && !reportOnly)
                                {
                                    originFileArrey[i] = "*******" + originFileArrey[i][originFileArrey[i].Length - 1];
                                }
                                else if (!reportOnly)
                                {
                                    originFileArrey[i] = "*******";
                                }
                            }
                        }
                    }

                    if (reportForm.foundForbiddenWordsList.Count > 0 && !reportOnly)
                    {
                        MoveCensoredFile(reportForm.filePath, Path.Combine(
                            folderPathForFilesWithForbiddenWords, Path.GetFileName(reportForm.filePath)));
                        File.WriteAllText(reportForm.filePath, string.Join(" ", originFileArrey));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        /// <summary>
        /// Удаляет все знаки и воззводит в нижний регистр
        /// </summary>
        /// <param name="str">массив слов</param>
        /// <returns>массив слов без знаков и строчными буквами</returns>
        private string[] RemoveSigns(string[] arr)
        {
            var newArr = new string[arr.Length];
            arr.CopyTo(newArr, 0);
            var charsToRemove = new string[] { "@", ",", ".", ";", ":", "'", "\"", "!", "?" };
            for (int i = 0; i < arr.Length; i++)
            {
                foreach (var simvol in charsToRemove)
                {
                    newArr[i] = newArr[i].Replace(simvol, string.Empty).ToLower();
                }
            }
            return newArr;
        }

        /// <summary>
        /// перемещает оригинал в другую папку
        /// </summary>
        /// <param name="filePath"></param>
        private void MoveCensoredFile(string filePath, string newFilePath)
        {
            string originalPath = filePath;
            if (IsCorrectFile(newFilePath))
            {
                newFilePath = ChangeFilesWithTheSameName(newFilePath);
            }
            File.Move(filePath, newFilePath);
        }

        /// <summary>
        /// Проверяет название файла на совпадения и изменяет при необходимости
        /// </summary>
        /// <param name="filePath">Путь, где нужно создать файл и где необходима проверка на совпадение</param>
        /// <returns>Путь файла с изменённым названием</returns>

        private string ChangeFilesWithTheSameName(string filePath)
        {
            string nameFileNoExtension = Path.GetFileNameWithoutExtension(filePath);
            var stack = new Stack<char>();
            for (var i = nameFileNoExtension.Length - 1; i >= 0; i--)
            {
                if (!char.IsNumber(nameFileNoExtension[i]))
                {
                    break;
                }
                stack.Push(nameFileNoExtension[i]);
                nameFileNoExtension = nameFileNoExtension.Remove(nameFileNoExtension.Length - 1);
            }
            var fileNumber = new string(stack.ToArray());
            if (stack.Count > 0)
                nameFileNoExtension = nameFileNoExtension + (int.Parse(fileNumber) + 1);
            else
                nameFileNoExtension = nameFileNoExtension + 2;

            return Path.Combine(Path.GetDirectoryName(filePath), nameFileNoExtension) + Path.GetExtension(filePath);
        }

        /// <summary>
        /// Создаёт файл отчёта
        /// </summary>
        /// <returns></returns>
        private void CreateAReport()
        {
            var fileName = "Report " + Regex.Replace(DateTime.Now.ToString(), @"[\.:]", " ");
            pathToTheReportFile = Path.Combine(pathToTheReportFile, fileName + ".txt");
            using (StreamWriter f = new StreamWriter(pathToTheReportFile))
            {
                foreach (var reportForm in reportsList)
                {
                    if (reportForm.numberOfForbiddenWords > 0)
                    {
                        f.WriteLine("Путь: " + reportForm.filePath);
                        f.WriteLine("Размер: " + reportForm.fileSize + " байт");
                        f.WriteLine("Кол-во запрещёнки: " + reportForm.numberOfForbiddenWords + " слов\n");
                        f.WriteLine("Список запрещённых слов этого файла:");
                        for (int i = 0; i < reportForm.foundForbiddenWordsList.Count; i++)
                        {
                            f.WriteLine((i + 1) + ") " + reportForm.foundForbiddenWordsList[i]);
                        }
                        f.WriteLine(
                            "\n-----------------------------------------------------------------------------------------\n");
                    }
                }
            }
        }

        /// <summary>
        /// Печать в консоль отчёта по всем найденным файлам с запрещёнкой
        /// </summary>
        public void PrintAllReportsToConsole()
        {
            if (reportsList.Count > 0)
                foreach (var reportForm in reportsList)
                {
                    if (reportForm.numberOfForbiddenWords > 0)
                    {
                        Console.WriteLine("Путь: " + reportForm.filePath);
                        Console.WriteLine("Размер: " + reportForm.fileSize + " байт");
                        Console.WriteLine("Кол-во запрещёнки: " + reportForm.numberOfForbiddenWords + " слов\n");
                        Console.WriteLine("Список запрещённых слов этого файла:");
                        for (int i = 0; i < reportForm.foundForbiddenWordsList.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ") " + reportForm.foundForbiddenWordsList[i]);
                        }
                        Console.WriteLine(
                            "\n-----------------------------------------------------------------------------------------\n");
                    }
                }
        }

        /// <summary>
        /// Печать топ 10 запрещёнок
        /// </summary>
        /// <returns></returns>
        public void BannedPopularityReport()
        {
            List<string> biddenWordList = new List<string>();
            foreach (var reportForm in reportsList)
            {
                foreach (var biddenWord in reportForm.foundForbiddenWordsList)
                {
                    if (reportForm.numberOfForbiddenWords > 0)
                        biddenWordList.Add(biddenWord);
                }
            }

            var top = biddenWordList
                .GroupBy(g => g)
                .Select(s => new { Word = s.Key, Count = s.Count() })
                .OrderByDescending(g => g.Count)
                .Take(10);

            using (StreamWriter f = new StreamWriter(pathToTheReportFile, append: true))
            {
                foreach (var t in top)
                {
                    var str = t.Word + " " + t.Count;
                    f.WriteLine(str);
                    //Console.WriteLine(str);
                }
            }
        }

        /// <summary>
        /// Вызывает методы, вычиляющие максимуум для прогресс бара
        /// </summary>

        private void CalculatingTheNumberForTheProgressBar()
        {
            List<string> folders = new List<string>();
            if (searchAcrossAllDrives)
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    folders.AddRange(MyGetFileSupTo2FoldersDeep(drive.Name));
                }
            }
            else
            {
                folders.AddRange(MyGetFileSupTo2FoldersDeep(searchDrectoryPath));
            }
        }

        /// <summary>
        /// Поверхностно (глубиной не более двух папок) сканирует файловую систему
        /// </summary>
        /// <param name="path">Директория сканирования</param>
        /// <returns>Лист с найденными папками</returns>
        private static List<string> MyGetFileSupTo2FoldersDeep(string path)
        {
            var files = new List<string>();
            try
            {
                files.AddRange(Directory.GetDirectories(path));
                foreach (var directory in Directory.GetDirectories(path))
                {
                    lock (syncObj) { }
                    if (countIToProgressBar < 2)
                    {
                        countIToProgressBar++;
                        //Console.WriteLine( directory);
                        castomProgressBarFileSearch.foldersWithAcceleratedSearchForTheProgressBar.Add(directory);
                        files.AddRange(MyGetFileSupTo2FoldersDeep(directory));
                    }
                    else
                        break;
                }
            }
            catch (UnauthorizedAccessException) { }
            countIToProgressBar--;
            return files;
        }

        public void Dispools()
        {
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            castomProgressBarFileSearch.Maximum = 0;
            castomProgressBarFileSearch.Value = 0;
            castomProgressBarSearchForForbidden.Maximum = 0;
            castomProgressBarSearchForForbidden.Value = 0;
            //allFoundPathsWithABan = new List<string>();
            reportsList.Clear();
        }

        /// <summary>
        /// Приостановить задачу
        /// </summary>
        public void Pause()
        {
            if (paused == false)
            {
                // This will acquire the lock on the syncObj,
                // which, in turn will "freeze" the loop
                // as soon as you hit a lock(syncObj) statement
                Monitor.Enter(syncObj);
                paused = true;
            }
        }

        /// <summary>
        /// Продолжить задачу
        /// </summary>
        public void Resume()
        {
            if (paused)
            {
                paused = false;
                // This will allow the lock to be taken, which will let the loop continue
                Monitor.Exit(syncObj);
            }
        }

        public void Cancel()
        {
            cancelTokenSource.Cancel();
        }
    }
}

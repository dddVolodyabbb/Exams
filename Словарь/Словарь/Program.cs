using System;
using System.IO;
using System.Linq;
using Commands;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Menus;


namespace Словарь
{
    
    class MyDictionary
    {
        Library library = new Library();
        public const string ENFile = "F:\\interpreter\\EN.txt";
        public const string RUSFile = "F:\\interpreter\\RUS.txt";
        public MyDictionary()
        {
            library.RussianDictionary = File.ReadAllLines(RUSFile).ToList();
            library.EnglishDictionary = File.ReadAllLines(ENFile).ToList();
        }

        public void Menu()
        {
            var wrapper = new ValueWrapper<Library>();
            wrapper.Value = library;
            var mainMenu = new MainMenu<Library>(wrapper, new Translator(), new AddTranslation());
            mainMenu.Start();
            SaveToFile();
        }

        private void SaveToFile()
        {
            File.WriteAllLines(RUSFile, library.RussianDictionary);
            File.WriteAllLines(ENFile, library.EnglishDictionary);
        }
        public void Print()
        {
            foreach (var line in library.RussianDictionary)
            {
                Console.WriteLine(line);
            }
        }
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            MyDictionary dictionary = new MyDictionary();
            dictionary.Menu();
            int[] ints = { 1, 3, 4, 5 };
            //dictionary.Print();
        }
    }
}

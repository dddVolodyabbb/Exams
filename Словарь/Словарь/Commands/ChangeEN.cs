using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleMenu.Core.Logic;
using Словарь;
using System.Text.RegularExpressions;
using ConsoleMenu.Core.Logic.Menus;


namespace Commands
{
    public class ChangeEN : ICommand<Library>
    {
        public string Description => "Правка EN перевода";

        public void Execute(ValueWrapper<Library> wrapper)
        {
            Console.Clear();
            var subMenu = new SubMenu<Library>("Добавление варианта перевода", new AddingTranslationOption());
            wrapper.Value.language = "RUS";
            List<string> translator = wrapper.Value.EnglishDictionary[wrapper.Value.value].Split(' ').ToList();
            subMenu.PrintCommands();
            for (int i = 0; i < translator.Count - 1; i++)
                Console.WriteLine(i + 2 + ": " + translator[i]);
            Console.WriteLine();
            Console.WriteLine("Выбрать редактируемое слово или команду");
            string choice = Console.ReadLine();
            if (choice == "1" || choice == "0")
            {
                subMenu.Start(choice);
            }
            else
            {
                Console.Clear();
                int input = 0;
                Console.WriteLine("1: Изменить выбранный перевод");
                Console.WriteLine("2: Удалить выбранный перевод");
                Console.Write(" => ");
                input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        translator[int.Parse(choice) - 2] = TranslationRevision(translator[int.Parse(choice) - 2]);
                        break;
                    case 2:
                        translator = TranslationDelete(translator, (int.Parse(choice) - 2));
                        break;
                }
                wrapper.Value.EnglishDictionary[wrapper.Value.value] = string.Join(" ", translator);
            }
        }
        private string TranslationRevision(string word)
        {
            Console.Clear();
            Console.WriteLine("Редактируемое слово: " + word);
            Console.Write("Изменённое слово: ");
            word = Console.ReadLine();
            return word;
        }

        private List<string> TranslationDelete(List<string> line, int cauntWord)
        {
            line.RemoveAt(cauntWord);
            return line;
        }
    }
}
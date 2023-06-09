using ConsoleMenu.Core.Logic;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Словарь;

namespace Commands
{
    public class AddTranslation : ICommand<Library>

    {
        public string Description => "Добавить перевод";

        public void Execute(ValueWrapper<Library> wrapper)
        {
            Console.WriteLine("Ввести 1 для ввода перевода слова\\слов");
            Console.WriteLine("Ввести слово\\слова");
            string word = Console.ReadLine();
            if (Regex.IsMatch(word, "[а-яА-ЯеЁ]"))
            {
                Add(wrapper.Value.RussianDictionary, wrapper.Value.EnglishDictionary, word);
            }
            else if (Regex.IsMatch(word, "[a-zA-Z]"))
            {
                Add(wrapper.Value.EnglishDictionary, wrapper.Value.RussianDictionary, word);
            }

            Console.Clear();
        }

        private void Add(List<string> list1, List<string> list2, string word)
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "1")
                    break;
                word += " " + input;
            }
            list1.Add(word);
            word = "";
            Console.WriteLine("Ввести 0 для сохранения");
            Console.WriteLine("Ввести слово\\слова");
            while (true)
            {
                input = Console.ReadLine();
                if (input == "0")
                    break;
                if (word == "")
                    word = input;
                word += " " + input;
            }
            list2.Add(word);
        }
    }
}

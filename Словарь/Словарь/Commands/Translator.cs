using System;
using System.Text.RegularExpressions;
using System.Threading;
using ConsoleMenu.Core.Logic;
using ConsoleMenu.Core.Logic.Commands;
using ConsoleMenu.Core.Logic.Menus;
using Словарь;
using static System.Int32;


namespace Commands
{
    //переделать функцию поиска переводимого слова
    public class Translator : ICommand<Library>
    {
        public string Description => "Переводчик";

        public void Execute(ValueWrapper<Library> wrapper)
        {
            string word;
            string oldWord="";
            string oldTranslator="";
            Console.Clear();
            do
            {
                bool notFound = false;
                var toChange = new SubMenu<Library>("Изменить перевод", wrapper, new ChangeEN(), new ChangeRUS());
                SubMenu<Library> mainMenu;
                mainMenu = wrapper.Value.value>=0 ? new SubMenu<Library>("Переводчик", wrapper, new SubMenuCommand<Library>(toChange), 
                    new DeleteAllTranslation(), new SaveTheTranslationToAFile()) : new SubMenu<Library>("Переводчик", wrapper);
                mainMenu.PrintCommands();
                if (oldWord != ""&& oldTranslator!="")
                {
                    Console.WriteLine();
                    Console.WriteLine(oldWord);
                    Console.WriteLine(oldTranslator);
                    Console.WriteLine();
                }
                Console.WriteLine("Ввести переводимое слово или команду");
                Console.Write(" => ");
                oldWord=word = Console.ReadLine();

                if (Regex.IsMatch(word, "[0-9]"))
                    mainMenu.Start(word);
                if (Regex.IsMatch(word, "[а-яА-ЯеЁ]"))
                {
                    //Console.WriteLine(RussianDictionary.Select(x=>x.Contains(word)));
                    for (int i = 0; i < wrapper.Value.RussianDictionary.Count; i++)
                    {
                        if (!wrapper.Value.RussianDictionary[i].Contains(word)) continue;
                        Console.WriteLine(wrapper.Value.EnglishDictionary[i]);
                        oldTranslator = wrapper.Value.EnglishDictionary[i];
                        wrapper.Value.value = i;
                        notFound = true;
                        break;
                    }
                }
                else if (Regex.IsMatch(word, "[a-zA-Z]"))
                {
                    for (int i = 0; i < wrapper.Value.RussianDictionary.Count; i++)
                    {
                        if (!wrapper.Value.EnglishDictionary[i].Contains(word)) continue;
                        Console.WriteLine(wrapper.Value.RussianDictionary[i]);
                        oldTranslator = wrapper.Value.RussianDictionary[i];
                        wrapper.Value.value = i;
                        notFound = true;
                        break;
                    }
                }

                if (notFound == false && !Regex.IsMatch(word, "[0-9]"))
                {
                    Console.WriteLine("Для продолжения нажать кнопку");
                    Console.WriteLine("Совпадений не найдено");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (word != "0");
        }
    }
}
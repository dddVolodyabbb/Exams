using System;
using ConsoleMenu.Core.Logic;
using Словарь;

namespace Commands
{
    public class AddingTranslationOption : ICommand<Library>
    {
        public string Description => "Добавление варианта перевода";

        public void Execute(ValueWrapper<Library> wrapper)
        {
            Console.WriteLine("Ввести новое слово");
            if (wrapper.Value.language=="RUS")
                wrapper.Value.RussianDictionary[wrapper.Value.value] += " " + Console.ReadLine();
            else if (wrapper.Value.language=="EN")
                wrapper.Value.EnglishDictionary[wrapper.Value.value] += " " + Console.ReadLine();
        }
    }
}
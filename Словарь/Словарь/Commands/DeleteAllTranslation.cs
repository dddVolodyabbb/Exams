using System;
using ConsoleMenu.Core.Logic;
using Словарь;

namespace Commands
{
    public class DeleteAllTranslation : ICommand<Library>
    {
        public string Description => "Удалить весь первеод";

        public void Execute(ValueWrapper<Library> wrapper)
        {
            wrapper.Value.EnglishDictionary.RemoveAt(wrapper.Value.value);
            wrapper.Value.RussianDictionary.RemoveAt(wrapper.Value.value);
        }
    }
}
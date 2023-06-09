using ConsoleMenu.Core.Logic;
using System.IO;
using Словарь;

namespace Commands
{
    public class SaveTheTranslationToAFile: ICommand<Library>
    {
        const string path = "F:\\interpreter\\translation.txt";
        public string Description => "Сохранить результат перевода в файл по пути "+ path;

        public void Execute(ValueWrapper<Library> wrapper)
        {
            
            string[] translation =
            {
                wrapper.Value.RussianDictionary[wrapper.Value.value],
                wrapper.Value.EnglishDictionary[wrapper.Value.value]
            };
                File.WriteAllLines(path, translation);
        }
    }
}
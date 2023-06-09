using System.Collections.Generic;

namespace Словарь
{
    public class Library
    {
        public List<string> RussianDictionary { get; set; }
        public List<string> EnglishDictionary { get; set; }
        public int value { get; set; }
        public string language;

        public Library()
        {
            RussianDictionary = new List<string>();
            EnglishDictionary = new List<string>();
            value = -1;
            language = "";
        }
    }
}
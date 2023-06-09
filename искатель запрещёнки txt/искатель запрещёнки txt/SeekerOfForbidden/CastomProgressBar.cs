using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeekerOfForbidden
{
    public class CastomProgressBar
    {
        /// <summary>
        /// Список папок для высчитывания прогресс бара
        /// </summary>
         public List<string> foldersWithAcceleratedSearchForTheProgressBar;
        public int Value;
        public int Maximum;
        public CastomProgressBar()
        {
            foldersWithAcceleratedSearchForTheProgressBar = new List<string>();
            Value = 0;
        }


        /// <summary>
        /// Устанавливает максимум у прогресс бара
        /// </summary>
        /// <param name="list">Принимает лист путей, которые перебирает программа</param>
        public void SetMaxProgressBar()
        {
            //foldersWithAcceleratedSearchForTheProgressBar = foldersWithAcceleratedSearchForTheProgressBar.OrderBy(l=>l).ToList();
            Maximum = foldersWithAcceleratedSearchForTheProgressBar.Count;
        }

        public void SetMaxProgressBar(int count)
        {
            Maximum = count;
        }


        /// <summary>
        /// Увеличивает value прогресс бара на 1
        /// </summary>
        /// <param name="path">Принимает путь, по которому проверяется %работы программы</param>
        public void ValueIsUp(string path)
        {
            if(Value<Maximum)
            if (path.Contains(foldersWithAcceleratedSearchForTheProgressBar[Value]))
                Value++;
        }
        public void ValueIsUp()
        {
            Value++;
        }
    }
}

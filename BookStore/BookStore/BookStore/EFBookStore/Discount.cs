using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EFBookStore
{
    public class Discount
    {
        public int Id { get; set; }
       
        public int DiscountOfBook { get; set; } 
        public string Title { get; set; }
        public ICollection<DiscountBook> DiscountBooks { get; set; }

    }
}

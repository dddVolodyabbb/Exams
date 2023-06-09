using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EFBookStore
{
    public class DiscountBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int DisscontId { get; set; }
        public Discount Discount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EFBookStore
{
    public class User
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<ProdavecBook> ProdavecBooks { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}

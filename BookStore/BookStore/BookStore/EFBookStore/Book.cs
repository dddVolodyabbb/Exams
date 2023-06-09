using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EFBookStore
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int VolumeOrPart { get; set; }
        public string FIOAuthor { get; set; }
        public string PublishingHouse { get; set; }
        public int NumberOfPages { get; set; }
        public string Genre { get; set; }
        public int YearOfPublication { get; set; }
        public decimal CostPrice { get; set; }
        public decimal PriceForSale { get; set; }
        public DateTime DateOfublication { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<ProdavecBook> ProdavecBooks { get; set; }
        public ICollection<DiscountBook> DiscountBooks { get; set; }
        public ICollection<Basket> Baskets { get; set; }


        // логин пароль
        // admin admin
        // Prodavec Prodavec
        // Pokypatel Pokypatel
    }
}

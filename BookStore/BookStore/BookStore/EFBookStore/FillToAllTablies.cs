using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Contexts;
using BookStore.EFBookStore;

namespace BookStore
{
    public class FillToAllTablies
    {
        public FillToAllTablies()
        {
        }

        public FillToAllTablies(bool fillToAllTablies)
        {
            if (fillToAllTablies)
                FillDatabaseIfEmptyAsync().ConfigureAwait(false);
        }

        public async Task FillDatabaseIfEmptyAsync()
        {
            //await FillFIOAuthorsIfEmptyAsync().ConfigureAwait(false);
            //await FillGenresIfEmptyAsync().ConfigureAwait(false);
            //await FillPublishingHousesIfEmptyAsync().ConfigureAwait(false);
            await FillUsersIfEmptyAsync().ConfigureAwait(false);
            await FillBooksIfEmptyAsync().ConfigureAwait(false);
            await FillProdavecBookIfEmptyAsync().ConfigureAwait(false);
            await FillSalesIfEmptyAsync().ConfigureAwait(false);
            await FillDiscountIfEmptyAsync().ConfigureAwait(false);
            await FillDiscountBookIfEmptyAsync().ConfigureAwait(false);
        }

        private static async Task FillBooksIfEmptyAsync()
        {
            using (var db = new ContectBookStore())
            {
                var count = await db.Books.CountAsync().ConfigureAwait(false);
                if (count != 0)
                    return;
                db.Books.Add(new Book
                {
                    Title = "Title1",
                    VolumeOrPart = 1,
                    FIOAuthor = "FIO1",
                    PublishingHouse = "PublishingHouse1",
                    Genre = "Genre1",
                    YearOfPublication = 2015,
                    CostPrice = 51,
                    PriceForSale = 351,
                    NumberOfPages = 20,
                    DateOfublication = DateTime.Parse("2022.01.01")
                });
                db.Books.Add(new Book
                {
                    Title = "Title2",
                    VolumeOrPart = 1,
                    FIOAuthor = "FIO2",
                    PublishingHouse = "PublishingHouse2",
                    Genre = "Genre2",
                    YearOfPublication = 2019,
                    CostPrice = 53,
                    PriceForSale = 353,
                    NumberOfPages = 43,
                    DateOfublication = DateTime.Parse("2022.01.01")
                });
                db.Books.Add(new Book
                {
                    Title = "Title3",
                    VolumeOrPart = 1,
                    FIOAuthor = "FIO3",
                    PublishingHouse = "PublishingHouse3",
                    Genre = "Genre3",
                    YearOfPublication = 2020,
                    CostPrice = 67,
                    PriceForSale = 367,
                    NumberOfPages = 342,
                    DateOfublication = DateTime.Parse("2022.01.01")
                });
                db.Books.Add(new Book
                {
                    Title = "Title4",
                    VolumeOrPart = 2,
                    FIOAuthor = "FIO4",
                    PublishingHouse = "PublishingHouse4",
                    Genre = "Genre4",
                    YearOfPublication = 2021,
                    CostPrice = 48,
                    PriceForSale = 348,
                    NumberOfPages = 9,
                    DateOfublication = DateTime.Parse("2022.01.01")
                });
                db.Books.Add(new Book
                {
                    Title = "Title5",
                    VolumeOrPart = 1,
                    FIOAuthor = "FIO5",
                    PublishingHouse = "PublishingHouse5",
                    Genre = "Genre5",
                    YearOfPublication = 2012,
                    CostPrice = 73,
                    PriceForSale = 373,
                    NumberOfPages = 43,
                    DateOfublication = DateTime.Parse("2022.01.01")
                });
                db.Books.Add(new Book
                {
                    Title = "Title6",
                    VolumeOrPart = 1,
                    FIOAuthor = "FIO6",
                    PublishingHouse = "PublishingHouse6",
                    Genre = "Genre6",
                    YearOfPublication = 2010,
                    CostPrice = 67,
                    PriceForSale = 367,
                    NumberOfPages = 25,
                    DateOfublication = DateTime.Parse("2023.02.01")
                });
                db.Books.Add(new Book
                {
                    Title = "Title7",
                    VolumeOrPart = 1,
                    FIOAuthor = "FIO7",
                    PublishingHouse = "PublishingHouse7",
                    Genre = "Genre7",
                    YearOfPublication = 2019,
                    CostPrice = 50,
                    PriceForSale = 350,
                    NumberOfPages = 75,
                    DateOfublication = DateTime.Parse("2023.01.27")
                });
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private static async Task FillUsersIfEmptyAsync()
        {
            using (var db = new ContectBookStore())
            {
                var count = await db.Users.CountAsync().ConfigureAwait(false);
                if (count != 0)
                    return;
                db.Users.Add(new User { FIO = "FIO", Login = "admin", Password = "admin", Role = "admin" });
                db.Users.Add(new User { FIO = "FIO1", Login = "Login1", Password = "12345678", Role = "Prodavec" });
                db.Users.Add(new User { FIO = "FIO2", Login = "Login2", Password = "12345678", Role = "Prodavec" });
                db.Users.Add(new User { FIO = "FIO3", Login = "Login3", Password = "12345678", Role = "Pokypatel" });
                db.Users.Add(new User { FIO = "FIO4", Login = "Login4", Password = "12345678", Role = "Pokypatel" });
                db.Users.Add(new User { FIO = "FIO5", Login = "Login5", Password = "12345678", Role = "Pokypatel" });
                db.Users.Add(new User { FIO = "FIO6", Login = "Login6", Password = "12345678", Role = "Pokypatel" });
                db.Users.Add(new User { FIO = "FIO7", Login = "Login7", Password = "12345678", Role = "Pokypatel" });
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }

        private static async Task FillProdavecBookIfEmptyAsync()
        {
            using (var db = new ContectBookStore())
            {
                var count = await db.prodavecBooks.CountAsync().ConfigureAwait(false);
                if (count != 0)
                    return;

                //var userLogins = Enumerable.Range(1, 8).Select(i => $"User{i}").ToArray();
                //var users = await db.Users
                //    .Where(d => userLogins.Contains(d.Login))
                //    .OrderBy(d => d.Login.Length)
                //    .ThenBy(d => d.Login)
                //    .ToListAsync()
                //    .ConfigureAwait(false);

                //if (users.Count != userLogins.Length)
                //    throw new InvalidOperationException($"Users count must be {userLogins.Length}");

                //var bookTitle = Enumerable.Range(1, 7).Select(i => $"Book{i}").ToArray();
                //var books = await db.Books
                //    .Where(d => bookTitle.Contains(d.Title))
                //    .OrderBy(d => d.Title.Length)
                //    .ThenBy(d => d.Title)
                //    .ToListAsync()
                //    .ConfigureAwait(false);

                //if (books.Count != bookTitle.Length)
                //    throw new InvalidOperationException($"books count must be {bookTitle.Length}");

                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login1").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title1").ConfigureAwait(false) });
                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login1").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title2").ConfigureAwait(false) });
                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login1").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title3").ConfigureAwait(false) });
                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login2").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title4").ConfigureAwait(false) });
                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login2").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title5").ConfigureAwait(false) });
                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login2").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title6").ConfigureAwait(false) });
                db.prodavecBooks.Add(new ProdavecBook() { User = await db.Users.FirstAsync(d => d.Login == "Login2").ConfigureAwait(false), Book = await db.Books.FirstAsync(d => d.Title == "Title7").ConfigureAwait(false) });
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        private static async Task FillSalesIfEmptyAsync()
        {
            using (var db = new ContectBookStore())
            {
                var count = await db.Sales.CountAsync().ConfigureAwait(false);
                if (count != 0)
                    return;
                Random randTitle = new Random(1);
                Random randMonth = new Random(2);
                Random randDay = new Random(3);
                for (int i = 0; i < 60; i++)
                {
                    var title = "Title" + randTitle.Next(1, 6);
                    var date = "2022." + randMonth.Next(1, 13) + "." + randDay.Next(1, 30);
                    db.Sales.Add(new Sale()
                    {
                        Book = await db.Books.FirstAsync(d => d.Title == title).ConfigureAwait(false),
                        DateOfSale = DateTime.Parse(date)
                    });
                }

                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        private static async Task FillDiscountIfEmptyAsync()
        {
            using (var db = new ContectBookStore())
            {
                var count = await db.Discounts.CountAsync().ConfigureAwait(false);
                if (count != 0)
                    return;
                db.Discounts.Add(new Discount() { DiscountOfBook = 10, Title = "Disscount1" });

                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        private static async Task FillDiscountBookIfEmptyAsync()
        {
            using (var db = new ContectBookStore())
            {
                var count = await db.DiscountBooks.CountAsync().ConfigureAwait(false);
                if (count != 0)
                    return;
                db.DiscountBooks.Add(new DiscountBook()
                {
                    Discount = await db.Discounts.FirstAsync(d => d.Title == "Disscount1").ConfigureAwait(false),
                    Book = await db.Books.FirstAsync(d => d.Title == "Title6").ConfigureAwait(false)
                });

                await db.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}

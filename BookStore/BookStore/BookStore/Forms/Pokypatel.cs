using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Contexts;
using BookStore.EFBookStore;

namespace BookStore.Forms
{
    public partial class Pokypatel : Form
    {
        private ContectBookStore db;
        private int filtr = 1;

        public Pokypatel()
        {
            InitializeComponent();
            comboBoxFilterPoisk.SelectedIndex = 0;
            comboBoxFiltr.SelectedIndex = 0;
        }

        private async void buttonBuy_Click(object sender, EventArgs e)
        {
            var title = dataGridViewBooks.CurrentRow.Cells[0].Value.ToString();
            db.Baskets.Add(new Basket()
            {
                User = await db.Users.FirstAsync(d => d.Login == Text).ConfigureAwait(false),
                Book = await db.Books.FirstAsync(d => d.Title == title).ConfigureAwait(false)
            });
            db.SaveChanges();
            await DownloadTableBaskets().ConfigureAwait(false);
        }

        private async void Pokypatel_Load(object sender, EventArgs e)
        {
            db = new ContectBookStore("DBConnectionPokypatel");
            await DownloadTableBooks().ConfigureAwait(false);
            await DownloadTableBaskets().ConfigureAwait(false);
        }

        private async Task DownloadTableBaskets()
        {
            var thisUserBook = await db.Books.SelectMany(b => b.Baskets).Where(b => b.User.Login == Text).ToListAsync()
                .ConfigureAwait(false);
            var bookInThisUser = from book in db.Books
                                 join basket in db.Baskets on book.Id equals basket.BookId
                                 join user in db.Users on basket.UserId equals user.Id
                                 select new
                                 {
                                     Title = book.Title,
                                     Author = book.FIOAuthor,
                                     Genre = book.Genre,
                                     Price = book.PriceForSale,
                                     Login = user.Login
                                 };
            var table = await bookInThisUser.Where(b => b.Login == Text).Select(x => new { x.Title, x.Author, x.Genre, x.Price }).ToListAsync()
                .ConfigureAwait(false);
            Invoke((MethodInvoker)delegate
            {
                dataGridViewBasket.DataSource = table;
            });
        }
        private async Task DownloadTableBooks()
        {
            var table = await db.Books.Select(x => new
            {
                x.Title,
                x.VolumeOrPart,
                x.FIOAuthor,
                x.Genre,
                x.PublishingHouse,
                x.NumberOfPages,
                x.YearOfPublication,
                x.CostPrice,
                x.PriceForSale
            }).ToListAsync().ConfigureAwait(false);
            dataGridViewBooks.Invoke((MethodInvoker)delegate { dataGridViewBooks.DataSource = table; });

        }

        private async void buttonPoisk_Click(object sender, EventArgs e)
        {
            var poisk = textBoxPoisk.Text + "%";
            switch (comboBoxFilterPoisk.SelectedItem.ToString())
            {
                case "Названию":
                    // db.Database.Log = logInfo => FileLogger.Log(logInfo);
                    await Poisk(db.Books.Where(a => DbFunctions.Like(a.Title, poisk))).ConfigureAwait(false);
                    break;

                case "Автору":
                    await Poisk(db.Books.Where(a => DbFunctions.Like(a.FIOAuthor, poisk))).ConfigureAwait(false);
                    break;

                case "Жанру":
                    await Poisk(db.Books.Where(a => DbFunctions.Like(a.Genre, poisk))).ConfigureAwait(false);
                    break;
                default:
                    MessageBox.Show("Что-то почшло не так", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void comboBoxFiltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFiltr.SelectedItem.ToString())
            {
                case "Дня":
                    filtr = 1;
                    break;
                case "Недели":
                    filtr = 7;
                    break;
                case "Месяца":
                    filtr = 30;
                    break;
                case "Года":
                    filtr = 365;
                    break;
            }
        }

        private async void buttonNewBooks_Click(object sender, EventArgs e)
        {
            var dateFrom = DateTime.Now.Date.AddDays(-filtr);
            await Poisk(db.Books.Where(b => b.DateOfublication >= dateFrom)).ConfigureAwait(false);
        }

        private async Task Poisk(IQueryable<Book> linqCommand)
        {
            var table = await linqCommand.Select(x => new
            {
                x.Title,
                x.VolumeOrPart,
                x.FIOAuthor,
                x.Genre,
                x.PublishingHouse,
                x.NumberOfPages,
                x.YearOfPublication,
                x.CostPrice,
                x.PriceForSale
            }).ToListAsync().ConfigureAwait(false);
            dataGridViewBooks.Invoke((MethodInvoker)delegate
            {
                dataGridViewBooks.DataSource = table;
            });
        }

        private async void buttonPopularBooks_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now.AddDays(-filtr);
            var orderByBook = await db.Books.SelectMany(b => b.Sales).Where(s => s.DateOfSale >= date)
                .GroupBy(b => b.Book.Title).OrderByDescending(g => g.Count()).Select(g => new
                {
                    Title= g.Key.ToString()
                }).ToListAsync().ConfigureAwait(false);
           
            Invoke((MethodInvoker)delegate
            {
                dataGridViewBooks.DataSource = orderByBook;
            });
        }

        private async void buttonPopularAuthors_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now.AddDays(-filtr);
            var orderByBook = await db.Books
                .SelectMany(b => b.Sales)
                .Where(s => s.DateOfSale >= date)
                .GroupBy(b => b.Book.FIOAuthor)
                .OrderByDescending(g => g.Count())
                .Select(g => new { Author = g.Key.ToString() })
                .ToListAsync()
                .ConfigureAwait(false);

            Invoke((MethodInvoker)delegate
            {
                dataGridViewBooks.DataSource = orderByBook;
            });
        }

        private async void buttonPopularGenres_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now.AddDays(-filtr);
            var orderByBook = await db.Books.SelectMany(b => b.Sales)
                .Where(s => s.DateOfSale >= date)
                .GroupBy(b => b.Book.Genre)
                .OrderByDescending(g => g.Count())
                .Select(g => new
                {
                    Genre = g.Key.ToString()
                }).ToListAsync().ConfigureAwait(false);
            Invoke((MethodInvoker)delegate
            {
                dataGridViewBooks.DataSource = orderByBook;
            });
        }

        private async void buttonDeleteThis_Click(object sender, EventArgs e)
        {
            if (dataGridViewBasket.SelectedRows.Count > 0)
            {
                var title = dataGridViewBasket.CurrentRow.Cells[0].Value.ToString();
                int book = (db.Books.Where(b => b.Title == title).Select(b => b.Id).ToList())[0];
                Basket bookRemove = await db.Baskets.FirstAsync(d => d.BookId == book).ConfigureAwait(false);
                db.Baskets.Remove(bookRemove);
                db.SaveChanges();
                await DownloadTableBaskets().ConfigureAwait(false);
            }
        }

        private async void buttonAllDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBasket.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridViewBasket.Rows.Count; i++)
                {
                    var title = dataGridViewBasket.Rows[i].Cells[0].Value.ToString();
                    int book = (db.Books.Where(b => b.Title == title).Select(b => b.Id).ToList())[0];
                    Basket bookRemove = await db.Baskets.FirstAsync(d => d.BookId == book).ConfigureAwait(false);
                    db.Baskets.Remove(bookRemove);
                    db.SaveChanges();
                }
                await DownloadTableBaskets().ConfigureAwait(false);
            }
        }

        private async void buttonAllBooks_Click(object sender, EventArgs e)
        {
            await DownloadTableBooks().ConfigureAwait(false);
        }

        private async void buttonPay_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dataGridViewRow in dataGridViewBasket.Rows)
            {
                var titleBook = dataGridViewRow.Cells[0].Value.ToString();
                var book = await db.Books.FirstAsync(d => d.Title == titleBook).ConfigureAwait(false);
                db.Sales.Add(new Sale()
                {
                    Book = book,
                    DateOfSale = DateTime.Now.Date
                });
                db.Baskets.Remove(await db.Baskets.FirstAsync(d => d.Book.Title == titleBook).ConfigureAwait(false));
                await db.SaveChangesAsync().ConfigureAwait(false);
            }

            await DownloadTableBaskets().ConfigureAwait(false);
        }
    }
}



//public class FileLogger
//{
//    public static void Log(string logInfo)
//    {
//        File.AppendAllText("G:\\Logger.txt", logInfo);
//    }
//}


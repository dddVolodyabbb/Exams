using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Contexts;
using BookStore.EFBookStore;

namespace BookStore.Forms
{
    public partial class Prodavec : Form
    {
        private ContectBookStore db;
        public Prodavec()
        {
            InitializeComponent();
        }

        private async void Prodavec_Load(object sender, EventArgs e)
        {
            db = new ContectBookStore("DBConnectionProdavec");
            await DownloadTable().ConfigureAwait(false);
            await DownloadTableDiscaunt().ConfigureAwait(false);
        }

        private async Task DownloadTable()
        {
            var table = await db.Users.Where(a => a.Login == Text).SelectMany(d => d.ProdavecBooks)
                .Select(b => b.Book).Select(x => new
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
                }).ToListAsync().ConfigureAwait(true);
            dataGridViewShop.Invoke((MethodInvoker)delegate
            {
                dataGridViewShop.DataSource = table;
            });
        }

        async Task DownloadTableDiscaunt()
        {
            var linqCommand = from book in db.Books
                              join discountBook in db.DiscountBooks on book.Id equals discountBook.BookId
                              join discount in db.Discounts on discountBook.DisscontId equals discount.Id
                              select new
                              {
                                  TitleDiskont = discount.Title,
                                  Book = book.Title,
                                  Discount = discount.DiscountOfBook
                              };
            var table = await linqCommand.ToListAsync().ConfigureAwait(false);
            Invoke((MethodInvoker)delegate
            {
                dataGridViewDiscount.DataSource = table;
            });

        }

        private async void buttonAddBook_Click(object sender, EventArgs e)
        {
            AddNewBook addNewBook = new AddNewBook();
            addNewBook.Text = "Продать книгу";
            DialogResult result = addNewBook.ShowDialog(this);
            if (result == DialogResult.Cancel)
                return;

            Book book = new Book();
            try
            {
                book.Title = addNewBook.textBoxTitle.Text;
                book.FIOAuthor = addNewBook.textBoxFIOAuthor.Text;
                book.PublishingHouse = addNewBook.textBoxPublishingHouse.Text;
                book.Genre = addNewBook.textBoxGenre.Text;
                book.VolumeOrPart = Convert.ToInt32(addNewBook.textBoxVolumeOrPart.Text);
                book.CostPrice = Convert.ToInt32(addNewBook.textBoxCostPrice.Text);
                book.PriceForSale = Convert.ToInt32(addNewBook.textBoxPriceForSale.Text);
                book.NumberOfPages = Convert.ToInt32(addNewBook.textBoxNumberOfPages.Text);
                book.YearOfPublication = Convert.ToInt32(addNewBook.textBoxYearOfPublication.Text);
                db.Books.Add(book);
                db.prodavecBooks.Add(new ProdavecBook { User = await db.Users.FirstAsync(d => d.Login == Text).ConfigureAwait(false), Book = book });
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            await DownloadTable().ConfigureAwait(false);
        }

        private async void buttonRemoveBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewShop.SelectedRows.Count > 0)
            {
                try
                {
                    var title = dataGridViewShop.CurrentRow.Cells[0].Value.ToString();
                    Book bookRemove = await db.Books.FirstAsync(d => d.Title == title).ConfigureAwait(false);
                    db.Books.Remove(bookRemove);
                    db.SaveChanges();
                    await DownloadTable().ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private async void buttonAddDiscont_Click(object sender, EventArgs e)
        {
            AddDiscount addDiscount = new AddDiscount();
            var table = await db.Books.Select(b => new { b.Title, b.FIOAuthor, b.Genre, b.PriceForSale }).ToListAsync().ConfigureAwait(false);
            Invoke((MethodInvoker)delegate
            {
                addDiscount.dataGridViewBook.DataSource = table;
                addDiscount.Text = "Новая скидка";
                DialogResult result = addDiscount.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
            });
            Discount discount = new Discount();
            try
            {
                discount.Title = addDiscount.textBoxTitleDiscount.Text;
                discount.DiscountOfBook = int.Parse(addDiscount.textBoxDiscount.Text);
                db.Discounts.Add(discount);
                db.SaveChanges();
                var titleBook = addDiscount.dataGridViewBook.CurrentRow.Cells[0].Value.ToString();
                var selectBook = await db.Books.FirstAsync(d => d.Title == titleBook).ConfigureAwait(false);
                db.DiscountBooks.Add(new DiscountBook()
                {
                    Discount = discount,
                    Book = selectBook
                });
                await PriceAdjustment(discount, selectBook).ConfigureAwait(false);
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            await DownloadTableDiscaunt().ConfigureAwait(false);
            await DownloadTable().ConfigureAwait(false);
        }

        private async Task PriceAdjustment(Discount discount, Book book)
        {
            var bookPrice = book.PriceForSale;
            book.PriceForSale = bookPrice * (((decimal)100 - discount.DiscountOfBook)/100);
        }

        private async Task BackPriceAdjustment(Discount discount, Book book)
        {
            var bookPrice = book.PriceForSale;
            book.PriceForSale = (100 * bookPrice) / ((decimal)100 - discount.DiscountOfBook);
        }
        private async void buttonDeletedDiscount_Click(object sender, EventArgs e)
        {
            
             db.Database.Log = logInfo => FileLogger.Log(logInfo);
            try
            {
                var selectDiscountTitle = dataGridViewDiscount.CurrentRow.Cells[0].Value.ToString();
                var selectBooTittle = dataGridViewDiscount.CurrentRow.Cells[1].Value.ToString();
                var selectBook = await db.Books.FirstAsync(d => d.Title == selectBooTittle).ConfigureAwait(false);
                var discount = await db.Discounts.FirstAsync(d => d.Title == selectDiscountTitle).ConfigureAwait(false);
                await BackPriceAdjustment(discount, selectBook).ConfigureAwait(false);
                db.Discounts.Remove(discount);
                db.SaveChanges();
                await DownloadTableDiscaunt().ConfigureAwait(false);
                await DownloadTable().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class FileLogger
        {
            public static void Log(string logInfo)
            {
                File.AppendAllText("G:\\Logger.txt", logInfo);
            }
        }
    }
}

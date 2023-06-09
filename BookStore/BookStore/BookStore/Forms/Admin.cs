using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Contexts;


namespace BookStore.Forms
{
    public partial class Admin : Form
    {
        private ContectBookStore db;
        public Admin()
        {
            InitializeComponent();
        }

        private async void Admin_Load(object sender, EventArgs e)
        {
            db = new ContectBookStore("DBConnectionAdmin");
            await db.Books.LoadAsync().ConfigureAwait(false);
            await db.Users.LoadAsync().ConfigureAwait(false);
            await db.prodavecBooks.LoadAsync().ConfigureAwait(false);
            await db.Sales.LoadAsync().ConfigureAwait(false);
            Invoke((MethodInvoker)delegate
            {
                dataGridViewBooks.DataSource = db.Books.Local.ToBindingList();
                dataGridViewUsers.DataSource = db.Users.Local.ToBindingList();
                dataGridViewProdavecBooks.DataSource = db.prodavecBooks.Local.ToBindingList();
                dataGridViewSales.DataSource = db.Sales.Local.ToBindingList();
            });
           
            //dataGridView1.DataSource = db.Books.Select(x => new { x.Title,x.VolumeOrPart, x.FIOAuthor, x.Genre, x.PublishingHouse,x.YearOfPublication, x.CostPrice, x.PriceForSale}).ToArray();
            //.Select(x=>new {x.Title,x.VolumeOrPart, x.FIOAuthor, x.Genre, x.PublishingHouse, x.NumberOfPages,
            //x.YearOfPublication, x.CostPrice, x.PriceForSale});
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db.SaveChangesAsync().ConfigureAwait(false);
                dataGridViewBooks.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

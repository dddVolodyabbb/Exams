using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Contexts;
using BookStore.EFBookStore;
using BookStore.Forms;


namespace BookStore
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FillToAllTablies fillToAllTablies = new FillToAllTablies();
                await fillToAllTablies.FillDatabaseIfEmptyAsync().ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private async void ButtonEntrance_Click(object sender, EventArgs e)
        {
            //Admin g = new Admin();
            //g.Show();
           
            using (var db = new ContectBookStore("DBConnectionEntrance"))
            {
                if (!await db.Users.AnyAsync(a => a.Login == textBoxLogin.Text).ConfigureAwait(false))
                {
                    MessageBox.Show("Не правельно введён логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!await db.Users.AnyAsync(a => a.Password == textBoxPassword.Text).ConfigureAwait(false))
                {
                    MessageBox.Show("Не правельно введён пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await WindowLaunch(db).ConfigureAwait(false);
            }
        }

        private async Task WindowLaunch(ContectBookStore db)
        {
            var user = await db.Users.Where(u => u.Login == textBoxLogin.Text).ToListAsync().ConfigureAwait(false);
            switch (user.Select(u => u.Role).ToArray()[0])
            {
                case "Pokypatel":
                    Pokypatel pokypatelForm = new Pokypatel();
                    pokypatelForm.Text = textBoxLogin.Text;
                    pokypatelForm.ShowDialog();
                    break;
                case "Prodavec":
                    Prodavec prodavecForm = new Prodavec();
                    prodavecForm.Text = textBoxLogin.Text;
                    prodavecForm.ShowDialog();
                    break;
                case "admin":
                    Admin adminForm = new Admin();
                    adminForm.Text = textBoxLogin.Text;
                    adminForm.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}

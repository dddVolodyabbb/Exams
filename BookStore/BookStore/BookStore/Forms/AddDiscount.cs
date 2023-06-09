using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.Forms
{
    public partial class AddDiscount : Form
    {
        public AddDiscount()
        {
            InitializeComponent();
        }

        private void textBoxDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void textBoxDiscount_Leave(object sender, EventArgs e)
        {
            if (int.Parse(textBoxDiscount.Text) > 100)
            {
                textBoxDiscount.Text = "";
                MessageBox.Show("Скидка не может быть выше 100%", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDiscount_Load(object sender, EventArgs e)
        {
           
        }
    }
}

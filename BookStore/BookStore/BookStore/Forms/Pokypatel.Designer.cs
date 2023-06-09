
namespace BookStore.Forms
{
    partial class Pokypatel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.buttonBuy = new System.Windows.Forms.Button();
            this.Libl3 = new System.Windows.Forms.Label();
            this.textBoxPoisk = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFilterPoisk = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonAllBooks = new System.Windows.Forms.Button();
            this.comboBoxFiltr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPopularGenres = new System.Windows.Forms.Button();
            this.buttonPopularAuthors = new System.Windows.Forms.Button();
            this.buttonPopularBooks = new System.Windows.Forms.Button();
            this.buttonNewBooks = new System.Windows.Forms.Button();
            this.buttonPoisk = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonAllDelete = new System.Windows.Forms.Button();
            this.buttonDeleteThis = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.dataGridViewBasket = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBasket)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(16, 125);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.RowHeadersWidth = 51;
            this.dataGridViewBooks.RowTemplate.Height = 24;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(990, 628);
            this.dataGridViewBooks.TabIndex = 0;
            // 
            // buttonBuy
            // 
            this.buttonBuy.Location = new System.Drawing.Point(1105, 641);
            this.buttonBuy.Name = "buttonBuy";
            this.buttonBuy.Size = new System.Drawing.Size(178, 79);
            this.buttonBuy.TabIndex = 1;
            this.buttonBuy.Text = "Купить книгу";
            this.buttonBuy.UseVisualStyleBackColor = true;
            this.buttonBuy.Click += new System.EventHandler(this.buttonBuy_Click);
            // 
            // Libl3
            // 
            this.Libl3.AutoSize = true;
            this.Libl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Libl3.Location = new System.Drawing.Point(9, 14);
            this.Libl3.Name = "Libl3";
            this.Libl3.Size = new System.Drawing.Size(114, 39);
            this.Libl3.TabIndex = 2;
            this.Libl3.Text = "Поиск";
            // 
            // textBoxPoisk
            // 
            this.textBoxPoisk.Location = new System.Drawing.Point(129, 19);
            this.textBoxPoisk.Name = "textBoxPoisk";
            this.textBoxPoisk.Size = new System.Drawing.Size(877, 34);
            this.textBoxPoisk.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "По";
            // 
            // comboBoxFilterPoisk
            // 
            this.comboBoxFilterPoisk.FormattingEnabled = true;
            this.comboBoxFilterPoisk.Items.AddRange(new object[] {
            "Названию",
            "Автору",
            "Жанру"});
            this.comboBoxFilterPoisk.Location = new System.Drawing.Point(129, 59);
            this.comboBoxFilterPoisk.Name = "comboBoxFilterPoisk";
            this.comboBoxFilterPoisk.Size = new System.Drawing.Size(378, 37);
            this.comboBoxFilterPoisk.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1400, 814);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonAllBooks);
            this.tabPage1.Controls.Add(this.comboBoxFiltr);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.buttonPopularGenres);
            this.tabPage1.Controls.Add(this.buttonPopularAuthors);
            this.tabPage1.Controls.Add(this.buttonPopularBooks);
            this.tabPage1.Controls.Add(this.buttonNewBooks);
            this.tabPage1.Controls.Add(this.buttonPoisk);
            this.tabPage1.Controls.Add(this.Libl3);
            this.tabPage1.Controls.Add(this.buttonBuy);
            this.tabPage1.Controls.Add(this.comboBoxFilterPoisk);
            this.tabPage1.Controls.Add(this.dataGridViewBooks);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBoxPoisk);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1392, 772);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Магазин";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonAllBooks
            // 
            this.buttonAllBooks.Location = new System.Drawing.Point(1059, 144);
            this.buttonAllBooks.Name = "buttonAllBooks";
            this.buttonAllBooks.Size = new System.Drawing.Size(266, 60);
            this.buttonAllBooks.TabIndex = 14;
            this.buttonAllBooks.Text = "Все книги";
            this.buttonAllBooks.UseVisualStyleBackColor = true;
            this.buttonAllBooks.Click += new System.EventHandler(this.buttonAllBooks_Click);
            // 
            // comboBoxFiltr
            // 
            this.comboBoxFiltr.FormattingEnabled = true;
            this.comboBoxFiltr.Items.AddRange(new object[] {
            "Дня",
            "Недели",
            "Месяца",
            "Года"});
            this.comboBoxFiltr.Location = new System.Drawing.Point(1059, 546);
            this.comboBoxFiltr.Name = "comboBoxFiltr";
            this.comboBoxFiltr.Size = new System.Drawing.Size(266, 37);
            this.comboBoxFiltr.TabIndex = 13;
            this.comboBoxFiltr.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltr_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1098, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 39);
            this.label2.TabIndex = 12;
            this.label2.Text = "По итогам";
            // 
            // buttonPopularGenres
            // 
            this.buttonPopularGenres.Location = new System.Drawing.Point(1059, 408);
            this.buttonPopularGenres.Name = "buttonPopularGenres";
            this.buttonPopularGenres.Size = new System.Drawing.Size(266, 60);
            this.buttonPopularGenres.TabIndex = 11;
            this.buttonPopularGenres.Text = "Популярные жанры";
            this.buttonPopularGenres.UseVisualStyleBackColor = true;
            this.buttonPopularGenres.Click += new System.EventHandler(this.buttonPopularGenres_Click);
            // 
            // buttonPopularAuthors
            // 
            this.buttonPopularAuthors.Location = new System.Drawing.Point(1059, 342);
            this.buttonPopularAuthors.Name = "buttonPopularAuthors";
            this.buttonPopularAuthors.Size = new System.Drawing.Size(266, 60);
            this.buttonPopularAuthors.TabIndex = 10;
            this.buttonPopularAuthors.Text = "Популярные авторы";
            this.buttonPopularAuthors.UseVisualStyleBackColor = true;
            this.buttonPopularAuthors.Click += new System.EventHandler(this.buttonPopularAuthors_Click);
            // 
            // buttonPopularBooks
            // 
            this.buttonPopularBooks.Location = new System.Drawing.Point(1059, 276);
            this.buttonPopularBooks.Name = "buttonPopularBooks";
            this.buttonPopularBooks.Size = new System.Drawing.Size(266, 60);
            this.buttonPopularBooks.TabIndex = 9;
            this.buttonPopularBooks.Text = "Популярные книги";
            this.buttonPopularBooks.UseVisualStyleBackColor = true;
            this.buttonPopularBooks.Click += new System.EventHandler(this.buttonPopularBooks_Click);
            // 
            // buttonNewBooks
            // 
            this.buttonNewBooks.Location = new System.Drawing.Point(1059, 210);
            this.buttonNewBooks.Name = "buttonNewBooks";
            this.buttonNewBooks.Size = new System.Drawing.Size(266, 60);
            this.buttonNewBooks.TabIndex = 8;
            this.buttonNewBooks.Text = "Новинки";
            this.buttonNewBooks.UseVisualStyleBackColor = true;
            this.buttonNewBooks.Click += new System.EventHandler(this.buttonNewBooks_Click);
            // 
            // buttonPoisk
            // 
            this.buttonPoisk.Location = new System.Drawing.Point(1059, 19);
            this.buttonPoisk.Name = "buttonPoisk";
            this.buttonPoisk.Size = new System.Drawing.Size(266, 79);
            this.buttonPoisk.TabIndex = 6;
            this.buttonPoisk.Text = "Найти";
            this.buttonPoisk.UseVisualStyleBackColor = true;
            this.buttonPoisk.Click += new System.EventHandler(this.buttonPoisk_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonAllDelete);
            this.tabPage2.Controls.Add(this.buttonDeleteThis);
            this.tabPage2.Controls.Add(this.buttonPay);
            this.tabPage2.Controls.Add(this.dataGridViewBasket);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1392, 772);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Корзина";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonAllDelete
            // 
            this.buttonAllDelete.Location = new System.Drawing.Point(1155, 254);
            this.buttonAllDelete.Name = "buttonAllDelete";
            this.buttonAllDelete.Size = new System.Drawing.Size(231, 76);
            this.buttonAllDelete.TabIndex = 3;
            this.buttonAllDelete.Text = "Очистить корзину";
            this.buttonAllDelete.UseVisualStyleBackColor = true;
            this.buttonAllDelete.Click += new System.EventHandler(this.buttonAllDelete_Click);
            // 
            // buttonDeleteThis
            // 
            this.buttonDeleteThis.Location = new System.Drawing.Point(1155, 172);
            this.buttonDeleteThis.Name = "buttonDeleteThis";
            this.buttonDeleteThis.Size = new System.Drawing.Size(231, 76);
            this.buttonDeleteThis.TabIndex = 2;
            this.buttonDeleteThis.Text = "Удалить это";
            this.buttonDeleteThis.UseVisualStyleBackColor = true;
            this.buttonDeleteThis.Click += new System.EventHandler(this.buttonDeleteThis_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(1155, 90);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(231, 76);
            this.buttonPay.TabIndex = 1;
            this.buttonPay.Text = "Купить всё";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // dataGridViewBasket
            // 
            this.dataGridViewBasket.AllowUserToAddRows = false;
            this.dataGridViewBasket.AllowUserToDeleteRows = false;
            this.dataGridViewBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBasket.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewBasket.Name = "dataGridViewBasket";
            this.dataGridViewBasket.RowHeadersWidth = 51;
            this.dataGridViewBasket.RowTemplate.Height = 24;
            this.dataGridViewBasket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBasket.Size = new System.Drawing.Size(1146, 698);
            this.dataGridViewBasket.TabIndex = 0;
            // 
            // Pokypatel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 816);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Pokypatel";
            this.Text = "Pokypatel";
            this.Load += new System.EventHandler(this.Pokypatel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBasket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.Button buttonBuy;
        private System.Windows.Forms.Label Libl3;
        private System.Windows.Forms.TextBox textBoxPoisk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFilterPoisk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonPoisk;
        private System.Windows.Forms.ComboBox comboBoxFiltr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPopularGenres;
        private System.Windows.Forms.Button buttonPopularAuthors;
        private System.Windows.Forms.Button buttonPopularBooks;
        private System.Windows.Forms.Button buttonNewBooks;
        private System.Windows.Forms.Button buttonAllDelete;
        private System.Windows.Forms.Button buttonDeleteThis;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.DataGridView dataGridViewBasket;
        private System.Windows.Forms.Button buttonAllBooks;
    }
}
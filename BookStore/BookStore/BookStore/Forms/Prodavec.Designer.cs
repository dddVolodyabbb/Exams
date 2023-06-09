
namespace BookStore.Forms
{
    partial class Prodavec
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
            this.dataGridViewShop = new System.Windows.Forms.DataGridView();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.buttonRemoveBook = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDeletedDiscount = new System.Windows.Forms.Button();
            this.buttonAddDiscont = new System.Windows.Forms.Button();
            this.dataGridViewDiscount = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShop)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShop
            // 
            this.dataGridViewShop.AllowUserToAddRows = false;
            this.dataGridViewShop.AllowUserToDeleteRows = false;
            this.dataGridViewShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShop.Location = new System.Drawing.Point(6, 3);
            this.dataGridViewShop.Name = "dataGridViewShop";
            this.dataGridViewShop.ReadOnly = true;
            this.dataGridViewShop.RowHeadersWidth = 51;
            this.dataGridViewShop.RowTemplate.Height = 24;
            this.dataGridViewShop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShop.Size = new System.Drawing.Size(1002, 515);
            this.dataGridViewShop.TabIndex = 0;
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(1014, 107);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(285, 95);
            this.buttonAddBook.TabIndex = 1;
            this.buttonAddBook.Text = "Выставить книгу на продажу";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // buttonRemoveBook
            // 
            this.buttonRemoveBook.Location = new System.Drawing.Point(1014, 208);
            this.buttonRemoveBook.Name = "buttonRemoveBook";
            this.buttonRemoveBook.Size = new System.Drawing.Size(284, 95);
            this.buttonRemoveBook.TabIndex = 2;
            this.buttonRemoveBook.Text = "Убрать книгу с продажи";
            this.buttonRemoveBook.UseVisualStyleBackColor = true;
            this.buttonRemoveBook.Click += new System.EventHandler(this.buttonRemoveBook_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1399, 812);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridViewShop);
            this.tabPage1.Controls.Add(this.buttonRemoveBook);
            this.tabPage1.Controls.Add(this.buttonAddBook);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1391, 770);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Магазин";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDeletedDiscount);
            this.tabPage2.Controls.Add(this.buttonAddDiscont);
            this.tabPage2.Controls.Add(this.dataGridViewDiscount);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1391, 770);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Скидки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeletedDiscount
            // 
            this.buttonDeletedDiscount.Location = new System.Drawing.Point(1159, 152);
            this.buttonDeletedDiscount.Name = "buttonDeletedDiscount";
            this.buttonDeletedDiscount.Size = new System.Drawing.Size(178, 76);
            this.buttonDeletedDiscount.TabIndex = 2;
            this.buttonDeletedDiscount.Text = "Удалить скидку";
            this.buttonDeletedDiscount.UseVisualStyleBackColor = true;
            this.buttonDeletedDiscount.Click += new System.EventHandler(this.buttonDeletedDiscount_Click);
            // 
            // buttonAddDiscont
            // 
            this.buttonAddDiscont.Location = new System.Drawing.Point(939, 152);
            this.buttonAddDiscont.Name = "buttonAddDiscont";
            this.buttonAddDiscont.Size = new System.Drawing.Size(178, 76);
            this.buttonAddDiscont.TabIndex = 1;
            this.buttonAddDiscont.Text = "Добавить скидку";
            this.buttonAddDiscont.UseVisualStyleBackColor = true;
            this.buttonAddDiscont.Click += new System.EventHandler(this.buttonAddDiscont_Click);
            // 
            // dataGridViewDiscount
            // 
            this.dataGridViewDiscount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiscount.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewDiscount.Name = "dataGridViewDiscount";
            this.dataGridViewDiscount.RowHeadersWidth = 51;
            this.dataGridViewDiscount.RowTemplate.Height = 24;
            this.dataGridViewDiscount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDiscount.Size = new System.Drawing.Size(912, 581);
            this.dataGridViewDiscount.TabIndex = 0;
            // 
            // Prodavec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 816);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Prodavec";
            this.Text = "Prodavec";
            this.Load += new System.EventHandler(this.Prodavec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShop)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiscount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShop;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.Button buttonRemoveBook;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDeletedDiscount;
        private System.Windows.Forms.Button buttonAddDiscont;
        private System.Windows.Forms.DataGridView dataGridViewDiscount;
    }
}
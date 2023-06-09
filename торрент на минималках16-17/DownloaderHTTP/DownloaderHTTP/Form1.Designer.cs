namespace DownloaderHTTP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFiles = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDownloadFiles = new System.Windows.Forms.Button();
            this.buttonDeletDownloadFile = new System.Windows.Forms.Button();
            this.buttonAddDownloadFile = new System.Windows.Forms.Button();
            this.dataGridViewDownloadFiles = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewAvailableFiles = new System.Windows.Forms.DataGridView();
            this.Files = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageDownload = new System.Windows.Forms.TabPage();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.textBoxPacketSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonChooseDownloadFolder = new System.Windows.Forms.Button();
            this.textBoxCountThread = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDownloadFolder = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownloadFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableFiles)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFiles);
            this.tabControl1.Controls.Add(this.tabPageDownload);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 511);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageFiles
            // 
            this.tabPageFiles.Controls.Add(this.label3);
            this.tabPageFiles.Controls.Add(this.label1);
            this.tabPageFiles.Controls.Add(this.buttonDownloadFiles);
            this.tabPageFiles.Controls.Add(this.buttonDeletDownloadFile);
            this.tabPageFiles.Controls.Add(this.buttonAddDownloadFile);
            this.tabPageFiles.Controls.Add(this.dataGridViewDownloadFiles);
            this.tabPageFiles.Controls.Add(this.dataGridViewAvailableFiles);
            this.tabPageFiles.Location = new System.Drawing.Point(4, 34);
            this.tabPageFiles.Name = "tabPageFiles";
            this.tabPageFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFiles.Size = new System.Drawing.Size(787, 473);
            this.tabPageFiles.TabIndex = 0;
            this.tabPageFiles.Text = "Файлы";
            this.tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Список файлов для загрузки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Доступные файлы";
            // 
            // buttonDownloadFiles
            // 
            this.buttonDownloadFiles.Location = new System.Drawing.Point(263, 15);
            this.buttonDownloadFiles.Name = "buttonDownloadFiles";
            this.buttonDownloadFiles.Size = new System.Drawing.Size(243, 37);
            this.buttonDownloadFiles.TabIndex = 12;
            this.buttonDownloadFiles.Text = "Скачать список файлов";
            this.buttonDownloadFiles.UseVisualStyleBackColor = true;
            this.buttonDownloadFiles.Click += new System.EventHandler(this.buttonDownloadFiles_Click_1);
            // 
            // buttonDeletDownloadFile
            // 
            this.buttonDeletDownloadFile.Location = new System.Drawing.Point(352, 242);
            this.buttonDeletDownloadFile.Name = "buttonDeletDownloadFile";
            this.buttonDeletDownloadFile.Size = new System.Drawing.Size(83, 39);
            this.buttonDeletDownloadFile.TabIndex = 11;
            this.buttonDeletDownloadFile.Text = "<---";
            this.buttonDeletDownloadFile.UseVisualStyleBackColor = true;
            this.buttonDeletDownloadFile.Click += new System.EventHandler(this.buttonDeletDownloadFile_Click_1);
            // 
            // buttonAddDownloadFile
            // 
            this.buttonAddDownloadFile.Location = new System.Drawing.Point(353, 193);
            this.buttonAddDownloadFile.Name = "buttonAddDownloadFile";
            this.buttonAddDownloadFile.Size = new System.Drawing.Size(83, 39);
            this.buttonAddDownloadFile.TabIndex = 10;
            this.buttonAddDownloadFile.Text = "--->";
            this.buttonAddDownloadFile.UseVisualStyleBackColor = true;
            this.buttonAddDownloadFile.Click += new System.EventHandler(this.buttonAddDownloadFile_Click_1);
            // 
            // dataGridViewDownloadFiles
            // 
            this.dataGridViewDownloadFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDownloadFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridViewDownloadFiles.Location = new System.Drawing.Point(441, 83);
            this.dataGridViewDownloadFiles.Name = "dataGridViewDownloadFiles";
            this.dataGridViewDownloadFiles.RowHeadersWidth = 51;
            this.dataGridViewDownloadFiles.RowTemplate.Height = 24;
            this.dataGridViewDownloadFiles.Size = new System.Drawing.Size(341, 398);
            this.dataGridViewDownloadFiles.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Файлы";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 288;
            // 
            // dataGridViewAvailableFiles
            // 
            this.dataGridViewAvailableFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailableFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Files});
            this.dataGridViewAvailableFiles.Location = new System.Drawing.Point(5, 83);
            this.dataGridViewAvailableFiles.Name = "dataGridViewAvailableFiles";
            this.dataGridViewAvailableFiles.RowHeadersWidth = 51;
            this.dataGridViewAvailableFiles.RowTemplate.Height = 24;
            this.dataGridViewAvailableFiles.Size = new System.Drawing.Size(341, 399);
            this.dataGridViewAvailableFiles.TabIndex = 8;
            // 
            // Files
            // 
            this.Files.HeaderText = "Файлы";
            this.Files.MinimumWidth = 6;
            this.Files.Name = "Files";
            this.Files.Width = 287;
            // 
            // tabPageDownload
            // 
            this.tabPageDownload.Location = new System.Drawing.Point(4, 34);
            this.tabPageDownload.Name = "tabPageDownload";
            this.tabPageDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDownload.Size = new System.Drawing.Size(787, 473);
            this.tabPageDownload.TabIndex = 1;
            this.tabPageDownload.Text = "Загрузка";
            this.tabPageDownload.UseVisualStyleBackColor = true;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.textBoxPacketSize);
            this.tabPageSettings.Controls.Add(this.label5);
            this.tabPageSettings.Controls.Add(this.buttonChooseDownloadFolder);
            this.tabPageSettings.Controls.Add(this.textBoxCountThread);
            this.tabPageSettings.Controls.Add(this.label4);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Controls.Add(this.textBoxDownloadFolder);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 34);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Size = new System.Drawing.Size(787, 473);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Настройки";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // textBoxPacketSize
            // 
            this.textBoxPacketSize.Location = new System.Drawing.Point(198, 152);
            this.textBoxPacketSize.Name = "textBoxPacketSize";
            this.textBoxPacketSize.Size = new System.Drawing.Size(100, 30);
            this.textBoxPacketSize.TabIndex = 6;
            this.textBoxPacketSize.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Размер пактов 1-5";
            // 
            // buttonChooseDownloadFolder
            // 
            this.buttonChooseDownloadFolder.Location = new System.Drawing.Point(259, 11);
            this.buttonChooseDownloadFolder.Name = "buttonChooseDownloadFolder";
            this.buttonChooseDownloadFolder.Size = new System.Drawing.Size(198, 33);
            this.buttonChooseDownloadFolder.TabIndex = 4;
            this.buttonChooseDownloadFolder.Text = "Выбрать папку";
            this.buttonChooseDownloadFolder.UseVisualStyleBackColor = true;
            this.buttonChooseDownloadFolder.Click += new System.EventHandler(this.buttonChooseDownloadFolder_Click);
            // 
            // textBoxCountThread
            // 
            this.textBoxCountThread.Location = new System.Drawing.Point(198, 116);
            this.textBoxCountThread.Name = "textBoxCountThread";
            this.textBoxCountThread.Size = new System.Drawing.Size(100, 30);
            this.textBoxCountThread.TabIndex = 3;
            this.textBoxCountThread.Text = "1";
            this.textBoxCountThread.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Кол-во потоков";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Папка скаченных файлов";
            // 
            // textBoxDownloadFolder
            // 
            this.textBoxDownloadFolder.Location = new System.Drawing.Point(10, 50);
            this.textBoxDownloadFolder.Name = "textBoxDownloadFolder";
            this.textBoxDownloadFolder.Size = new System.Drawing.Size(770, 30);
            this.textBoxDownloadFolder.TabIndex = 0;
            this.textBoxDownloadFolder.Text = "E:\\Downloads";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 517);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageFiles.ResumeLayout(false);
            this.tabPageFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDownloadFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailableFiles)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFiles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDownloadFiles;
        private System.Windows.Forms.Button buttonDeletDownloadFile;
        private System.Windows.Forms.Button buttonAddDownloadFile;
        private System.Windows.Forms.DataGridView dataGridViewDownloadFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridViewAvailableFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Files;
        private System.Windows.Forms.TabPage tabPageDownload;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TextBox textBoxCountThread;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDownloadFolder;
        private System.Windows.Forms.Button buttonChooseDownloadFolder;
        private System.Windows.Forms.TextBox textBoxPacketSize;
        private System.Windows.Forms.Label label5;
    }
}


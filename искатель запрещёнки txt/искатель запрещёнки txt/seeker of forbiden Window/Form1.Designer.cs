namespace seeker_of_forbiden_Window
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPathToTheForbiddenWordsDictionary = new System.Windows.Forms.TextBox();
            this.textBoxPathToTheReportFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFolderPathForFilesWithForbiddenWords = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSearchDrectoryPath = new System.Windows.Forms.TextBox();
            this.labelSearchDrectoryPath = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBoxEnteringForbiddenWords = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonEnterPathToTheForbiddenWordsDictionary = new System.Windows.Forms.Button();
            this.buttonChoosePathToTheForbiddenWordsDictionary = new System.Windows.Forms.Button();
            this.buttonChooseSearchDrectoryPath = new System.Windows.Forms.Button();
            this.buttonEnterSearchDrectoryPath = new System.Windows.Forms.Button();
            this.buttonChoosePathToTheReportFile = new System.Windows.Forms.Button();
            this.buttonEnterPathToTheReportFile = new System.Windows.Forms.Button();
            this.buttonChooseFolderPathForFilesWithForbiddenWords = new System.Windows.Forms.Button();
            this.buttonEnterFolderPathForFilesWithForbiddenWords = new System.Windows.Forms.Button();
            this.buttonEnteringForbiddenWords = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.progressBarFileSearch = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBarSearchForBidden = new System.Windows.Forms.ProgressBar();
            this.checkBoxReportOnly = new System.Windows.Forms.CheckBox();
            this.labelTheEnd = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonContinu = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к словарю";
            // 
            // textBoxPathToTheForbiddenWordsDictionary
            // 
            this.textBoxPathToTheForbiddenWordsDictionary.Location = new System.Drawing.Point(265, 26);
            this.textBoxPathToTheForbiddenWordsDictionary.Name = "textBoxPathToTheForbiddenWordsDictionary";
            this.textBoxPathToTheForbiddenWordsDictionary.Size = new System.Drawing.Size(665, 30);
            this.textBoxPathToTheForbiddenWordsDictionary.TabIndex = 1;
            // 
            // textBoxPathToTheReportFile
            // 
            this.textBoxPathToTheReportFile.Location = new System.Drawing.Point(265, 269);
            this.textBoxPathToTheReportFile.Name = "textBoxPathToTheReportFile";
            this.textBoxPathToTheReportFile.Size = new System.Drawing.Size(665, 30);
            this.textBoxPathToTheReportFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Путь к папке с отчётами";
            // 
            // textBoxFolderPathForFilesWithForbiddenWords
            // 
            this.textBoxFolderPathForFilesWithForbiddenWords.Location = new System.Drawing.Point(265, 216);
            this.textBoxFolderPathForFilesWithForbiddenWords.Name = "textBoxFolderPathForFilesWithForbiddenWords";
            this.textBoxFolderPathForFilesWithForbiddenWords.Size = new System.Drawing.Size(665, 30);
            this.textBoxFolderPathForFilesWithForbiddenWords.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 50);
            this.label3.TabIndex = 4;
            this.label3.Text = "Путь к папке с \r\nфайлами с запрещёнкой";
            // 
            // textBoxSearchDrectoryPath
            // 
            this.textBoxSearchDrectoryPath.Location = new System.Drawing.Point(435, 305);
            this.textBoxSearchDrectoryPath.Name = "textBoxSearchDrectoryPath";
            this.textBoxSearchDrectoryPath.Size = new System.Drawing.Size(495, 30);
            this.textBoxSearchDrectoryPath.TabIndex = 7;
            // 
            // labelSearchDrectoryPath
            // 
            this.labelSearchDrectoryPath.AutoSize = true;
            this.labelSearchDrectoryPath.Location = new System.Drawing.Point(264, 305);
            this.labelSearchDrectoryPath.Name = "labelSearchDrectoryPath";
            this.labelSearchDrectoryPath.Size = new System.Drawing.Size(173, 25);
            this.labelSearchDrectoryPath.TabIndex = 6;
            this.labelSearchDrectoryPath.Text = "Путь директории";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 298);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(244, 54);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Поиск в определённой\r\nдиректории";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // textBoxEnteringForbiddenWords
            // 
            this.textBoxEnteringForbiddenWords.Location = new System.Drawing.Point(265, 62);
            this.textBoxEnteringForbiddenWords.Multiline = true;
            this.textBoxEnteringForbiddenWords.Name = "textBoxEnteringForbiddenWords";
            this.textBoxEnteringForbiddenWords.Size = new System.Drawing.Size(665, 148);
            this.textBoxEnteringForbiddenWords.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ввод запрещённых слов";
            // 
            // buttonEnterPathToTheForbiddenWordsDictionary
            // 
            this.buttonEnterPathToTheForbiddenWordsDictionary.Location = new System.Drawing.Point(936, 26);
            this.buttonEnterPathToTheForbiddenWordsDictionary.Name = "buttonEnterPathToTheForbiddenWordsDictionary";
            this.buttonEnterPathToTheForbiddenWordsDictionary.Size = new System.Drawing.Size(104, 30);
            this.buttonEnterPathToTheForbiddenWordsDictionary.TabIndex = 11;
            this.buttonEnterPathToTheForbiddenWordsDictionary.Text = "Ввести";
            this.buttonEnterPathToTheForbiddenWordsDictionary.UseVisualStyleBackColor = true;
            this.buttonEnterPathToTheForbiddenWordsDictionary.Click += new System.EventHandler(this.ButtonEnterPathToTheForbiddenWordsDictionary_Click);
            // 
            // buttonChoosePathToTheForbiddenWordsDictionary
            // 
            this.buttonChoosePathToTheForbiddenWordsDictionary.Location = new System.Drawing.Point(1046, 26);
            this.buttonChoosePathToTheForbiddenWordsDictionary.Name = "buttonChoosePathToTheForbiddenWordsDictionary";
            this.buttonChoosePathToTheForbiddenWordsDictionary.Size = new System.Drawing.Size(104, 30);
            this.buttonChoosePathToTheForbiddenWordsDictionary.TabIndex = 12;
            this.buttonChoosePathToTheForbiddenWordsDictionary.Text = "Выбрать";
            this.buttonChoosePathToTheForbiddenWordsDictionary.UseVisualStyleBackColor = true;
            this.buttonChoosePathToTheForbiddenWordsDictionary.Click += new System.EventHandler(this.ButtonChoosePathToTheForbiddenWordsDictionary_Click);
            // 
            // buttonChooseSearchDrectoryPath
            // 
            this.buttonChooseSearchDrectoryPath.Location = new System.Drawing.Point(1046, 305);
            this.buttonChooseSearchDrectoryPath.Name = "buttonChooseSearchDrectoryPath";
            this.buttonChooseSearchDrectoryPath.Size = new System.Drawing.Size(104, 30);
            this.buttonChooseSearchDrectoryPath.TabIndex = 14;
            this.buttonChooseSearchDrectoryPath.Text = "Выбрать";
            this.buttonChooseSearchDrectoryPath.UseVisualStyleBackColor = true;
            this.buttonChooseSearchDrectoryPath.Click += new System.EventHandler(this.ButtonChooseSearchDrectoryPath_Click);
            // 
            // buttonEnterSearchDrectoryPath
            // 
            this.buttonEnterSearchDrectoryPath.Location = new System.Drawing.Point(936, 305);
            this.buttonEnterSearchDrectoryPath.Name = "buttonEnterSearchDrectoryPath";
            this.buttonEnterSearchDrectoryPath.Size = new System.Drawing.Size(104, 30);
            this.buttonEnterSearchDrectoryPath.TabIndex = 13;
            this.buttonEnterSearchDrectoryPath.Text = "Ввести";
            this.buttonEnterSearchDrectoryPath.UseVisualStyleBackColor = true;
            this.buttonEnterSearchDrectoryPath.Click += new System.EventHandler(this.ButtonEnterSearchDrectoryPath_Click);
            // 
            // buttonChoosePathToTheReportFile
            // 
            this.buttonChoosePathToTheReportFile.Location = new System.Drawing.Point(1046, 269);
            this.buttonChoosePathToTheReportFile.Name = "buttonChoosePathToTheReportFile";
            this.buttonChoosePathToTheReportFile.Size = new System.Drawing.Size(104, 30);
            this.buttonChoosePathToTheReportFile.TabIndex = 16;
            this.buttonChoosePathToTheReportFile.Text = "Выбрать";
            this.buttonChoosePathToTheReportFile.UseVisualStyleBackColor = true;
            this.buttonChoosePathToTheReportFile.Click += new System.EventHandler(this.ButtonChoosePathToTheReportFile_Click);
            // 
            // buttonEnterPathToTheReportFile
            // 
            this.buttonEnterPathToTheReportFile.Location = new System.Drawing.Point(936, 269);
            this.buttonEnterPathToTheReportFile.Name = "buttonEnterPathToTheReportFile";
            this.buttonEnterPathToTheReportFile.Size = new System.Drawing.Size(104, 30);
            this.buttonEnterPathToTheReportFile.TabIndex = 15;
            this.buttonEnterPathToTheReportFile.Text = "Ввести";
            this.buttonEnterPathToTheReportFile.UseVisualStyleBackColor = true;
            this.buttonEnterPathToTheReportFile.Click += new System.EventHandler(this.ButtonEnterPathToTheReportFile_Click);
            // 
            // buttonChooseFolderPathForFilesWithForbiddenWords
            // 
            this.buttonChooseFolderPathForFilesWithForbiddenWords.Location = new System.Drawing.Point(1046, 216);
            this.buttonChooseFolderPathForFilesWithForbiddenWords.Name = "buttonChooseFolderPathForFilesWithForbiddenWords";
            this.buttonChooseFolderPathForFilesWithForbiddenWords.Size = new System.Drawing.Size(104, 30);
            this.buttonChooseFolderPathForFilesWithForbiddenWords.TabIndex = 18;
            this.buttonChooseFolderPathForFilesWithForbiddenWords.Text = "Выбрать";
            this.buttonChooseFolderPathForFilesWithForbiddenWords.UseVisualStyleBackColor = true;
            this.buttonChooseFolderPathForFilesWithForbiddenWords.Click += new System.EventHandler(this.ButtonChooseFolderPathForFilesWithForbiddenWords_Click);
            // 
            // buttonEnterFolderPathForFilesWithForbiddenWords
            // 
            this.buttonEnterFolderPathForFilesWithForbiddenWords.Location = new System.Drawing.Point(936, 216);
            this.buttonEnterFolderPathForFilesWithForbiddenWords.Name = "buttonEnterFolderPathForFilesWithForbiddenWords";
            this.buttonEnterFolderPathForFilesWithForbiddenWords.Size = new System.Drawing.Size(104, 30);
            this.buttonEnterFolderPathForFilesWithForbiddenWords.TabIndex = 17;
            this.buttonEnterFolderPathForFilesWithForbiddenWords.Text = "Ввести";
            this.buttonEnterFolderPathForFilesWithForbiddenWords.UseVisualStyleBackColor = true;
            this.buttonEnterFolderPathForFilesWithForbiddenWords.Click += new System.EventHandler(this.ButtonEnterFolderPathForFilesWithForbiddenWords_Click);
            // 
            // buttonEnteringForbiddenWords
            // 
            this.buttonEnteringForbiddenWords.Location = new System.Drawing.Point(936, 59);
            this.buttonEnteringForbiddenWords.Name = "buttonEnteringForbiddenWords";
            this.buttonEnteringForbiddenWords.Size = new System.Drawing.Size(104, 30);
            this.buttonEnteringForbiddenWords.TabIndex = 19;
            this.buttonEnteringForbiddenWords.Text = "Ввести";
            this.buttonEnteringForbiddenWords.UseVisualStyleBackColor = true;
            this.buttonEnteringForbiddenWords.Click += new System.EventHandler(this.ButtonEnteringForbiddenWords_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(435, 394);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(310, 56);
            this.buttonStart.TabIndex = 20;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // progressBarFileSearch
            // 
            this.progressBarFileSearch.Location = new System.Drawing.Point(17, 506);
            this.progressBarFileSearch.Name = "progressBarFileSearch";
            this.progressBarFileSearch.Size = new System.Drawing.Size(1133, 23);
            this.progressBarFileSearch.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(522, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 25);
            this.label4.TabIndex = 22;
            this.label4.Text = "Поиск файлов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 559);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 25);
            this.label6.TabIndex = 24;
            this.label6.Text = "Поиск запрещёнки";
            // 
            // progressBarSearchForBidden
            // 
            this.progressBarSearchForBidden.Location = new System.Drawing.Point(17, 587);
            this.progressBarSearchForBidden.Name = "progressBarSearchForBidden";
            this.progressBarSearchForBidden.Size = new System.Drawing.Size(1133, 23);
            this.progressBarSearchForBidden.TabIndex = 23;
            // 
            // checkBoxReportOnly
            // 
            this.checkBoxReportOnly.AutoSize = true;
            this.checkBoxReportOnly.Location = new System.Drawing.Point(17, 358);
            this.checkBoxReportOnly.Name = "checkBoxReportOnly";
            this.checkBoxReportOnly.Size = new System.Drawing.Size(272, 29);
            this.checkBoxReportOnly.TabIndex = 25;
            this.checkBoxReportOnly.Text = "Зацензурить запрещёнку";
            this.checkBoxReportOnly.UseVisualStyleBackColor = true;
            this.checkBoxReportOnly.CheckedChanged += new System.EventHandler(this.CheckBoxReportOnly_CheckedChanged);
            // 
            // labelTheEnd
            // 
            this.labelTheEnd.AutoSize = true;
            this.labelTheEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTheEnd.Location = new System.Drawing.Point(520, 636);
            this.labelTheEnd.Name = "labelTheEnd";
            this.labelTheEnd.Size = new System.Drawing.Size(127, 39);
            this.labelTheEnd.TabIndex = 26;
            this.labelTheEnd.Text = "Готово";
            this.labelTheEnd.Visible = false;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(751, 394);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 31);
            this.buttonPause.TabIndex = 27;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonContinu
            // 
            this.buttonContinu.Location = new System.Drawing.Point(832, 394);
            this.buttonContinu.Name = "buttonContinu";
            this.buttonContinu.Size = new System.Drawing.Size(142, 31);
            this.buttonContinu.TabIndex = 28;
            this.buttonContinu.Text = "Продолжить";
            this.buttonContinu.UseVisualStyleBackColor = true;
            this.buttonContinu.Click += new System.EventHandler(this.buttonContinu_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(980, 394);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 31);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "Остановить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonContinu);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.labelTheEnd);
            this.Controls.Add(this.checkBoxReportOnly);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBarSearchForBidden);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBarFileSearch);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonEnteringForbiddenWords);
            this.Controls.Add(this.buttonChooseFolderPathForFilesWithForbiddenWords);
            this.Controls.Add(this.buttonEnterFolderPathForFilesWithForbiddenWords);
            this.Controls.Add(this.buttonChoosePathToTheReportFile);
            this.Controls.Add(this.buttonEnterPathToTheReportFile);
            this.Controls.Add(this.buttonChooseSearchDrectoryPath);
            this.Controls.Add(this.buttonEnterSearchDrectoryPath);
            this.Controls.Add(this.buttonChoosePathToTheForbiddenWordsDictionary);
            this.Controls.Add(this.buttonEnterPathToTheForbiddenWordsDictionary);
            this.Controls.Add(this.textBoxEnteringForbiddenWords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxSearchDrectoryPath);
            this.Controls.Add(this.labelSearchDrectoryPath);
            this.Controls.Add(this.textBoxFolderPathForFilesWithForbiddenWords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPathToTheReportFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPathToTheForbiddenWordsDictionary);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPathToTheForbiddenWordsDictionary;
        private System.Windows.Forms.TextBox textBoxPathToTheReportFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFolderPathForFilesWithForbiddenWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearchDrectoryPath;
        private System.Windows.Forms.Label labelSearchDrectoryPath;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBoxEnteringForbiddenWords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonEnterPathToTheForbiddenWordsDictionary;
        private System.Windows.Forms.Button buttonChoosePathToTheForbiddenWordsDictionary;
        private System.Windows.Forms.Button buttonChooseSearchDrectoryPath;
        private System.Windows.Forms.Button buttonEnterSearchDrectoryPath;
        private System.Windows.Forms.Button buttonChoosePathToTheReportFile;
        private System.Windows.Forms.Button buttonEnterPathToTheReportFile;
        private System.Windows.Forms.Button buttonChooseFolderPathForFilesWithForbiddenWords;
        private System.Windows.Forms.Button buttonEnterFolderPathForFilesWithForbiddenWords;
        private System.Windows.Forms.Button buttonEnteringForbiddenWords;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ProgressBar progressBarFileSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBarSearchForBidden;
        private System.Windows.Forms.CheckBox checkBoxReportOnly;
        private System.Windows.Forms.Label labelTheEnd;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonContinu;
        private System.Windows.Forms.Button buttonCancel;
    }
}


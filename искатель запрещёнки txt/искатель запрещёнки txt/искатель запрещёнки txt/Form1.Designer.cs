﻿
namespace искатель_запрещёнки_txt
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
            this.buttonCmd = new System.Windows.Forms.Button();
            this.buttonWindow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCmd
            // 
            this.buttonCmd.Location = new System.Drawing.Point(12, 64);
            this.buttonCmd.Name = "buttonCmd";
            this.buttonCmd.Size = new System.Drawing.Size(160, 60);
            this.buttonCmd.TabIndex = 0;
            this.buttonCmd.Text = "Комндной строке";
            this.buttonCmd.UseVisualStyleBackColor = true;
            this.buttonCmd.Click += new System.EventHandler(this.buttonCmd_Click);
            // 
            // buttonWindow
            // 
            this.buttonWindow.Location = new System.Drawing.Point(198, 64);
            this.buttonWindow.Name = "buttonWindow";
            this.buttonWindow.Size = new System.Drawing.Size(160, 60);
            this.buttonWindow.TabIndex = 1;
            this.buttonWindow.Text = "Окне";
            this.buttonWindow.UseVisualStyleBackColor = true;
            this.buttonWindow.Click += new System.EventHandler(this.buttonWindow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Запускать в...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWindow);
            this.Controls.Add(this.buttonCmd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCmd;
        private System.Windows.Forms.Button buttonWindow;
        private System.Windows.Forms.Label label1;
    }
}


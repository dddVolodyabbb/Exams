
namespace BookStore
{
    partial class Authorization
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
            this.ButtonEntrance = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.LablePassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonEntrance
            // 
            this.ButtonEntrance.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonEntrance.Location = new System.Drawing.Point(287, 289);
            this.ButtonEntrance.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonEntrance.Name = "ButtonEntrance";
            this.ButtonEntrance.Size = new System.Drawing.Size(267, 107);
            this.ButtonEntrance.TabIndex = 0;
            this.ButtonEntrance.Text = "Войти";
            this.ButtonEntrance.UseVisualStyleBackColor = true;
            this.ButtonEntrance.Click += new System.EventHandler(this.ButtonEntrance_Click);
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login.Location = new System.Drawing.Point(344, 46);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(163, 58);
            this.Login.TabIndex = 1;
            this.Login.Text = "Логин";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(183, 107);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(488, 34);
            this.textBoxLogin.TabIndex = 2;
            this.textBoxLogin.Text = "Login4";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(183, 205);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(488, 34);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.Text = "12345678";
            // 
            // LablePassword
            // 
            this.LablePassword.AutoSize = true;
            this.LablePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LablePassword.Location = new System.Drawing.Point(330, 144);
            this.LablePassword.Name = "LablePassword";
            this.LablePassword.Size = new System.Drawing.Size(200, 58);
            this.LablePassword.TabIndex = 3;
            this.LablePassword.Text = "Пароль";
            // 
            // Authorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 497);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.LablePassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.ButtonEntrance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Authorization";
            this.Text = "Authorization";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonEntrance;
        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label LablePassword;
    }
}


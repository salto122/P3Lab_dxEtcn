
namespace WindowsFormsApp1
{
    partial class Register
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
            this.LogPassword = new System.Windows.Forms.TextBox();
            this.LogLogin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LogLoginButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RegLogin = new System.Windows.Forms.TextBox();
            this.RegPassword1 = new System.Windows.Forms.TextBox();
            this.RegPassword2 = new System.Windows.Forms.TextBox();
            this.RegRodo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RegButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogPassword
            // 
            this.LogPassword.Location = new System.Drawing.Point(0, 74);
            this.LogPassword.Name = "LogPassword";
            this.LogPassword.PasswordChar = '.';
            this.LogPassword.Size = new System.Drawing.Size(137, 23);
            this.LogPassword.TabIndex = 9;
            // 
            // LogLogin
            // 
            this.LogLogin.Location = new System.Drawing.Point(0, 30);
            this.LogLogin.Name = "LogLogin";
            this.LogLogin.Size = new System.Drawing.Size(137, 23);
            this.LogLogin.TabIndex = 8;
            this.LogLogin.Text = "Login";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Login:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hasło:";
            // 
            // LogLoginButton
            // 
            this.LogLoginButton.AccessibleDescription = "";
            this.LogLoginButton.AccessibleName = "";
            this.LogLoginButton.Location = new System.Drawing.Point(0, 103);
            this.LogLoginButton.Name = "LogLoginButton";
            this.LogLoginButton.Size = new System.Drawing.Size(75, 23);
            this.LogLoginButton.TabIndex = 8;
            this.LogLoginButton.Text = "Zaloguj";
            this.LogLoginButton.UseVisualStyleBackColor = true;
            this.LogLoginButton.Click += new System.EventHandler(this.LogLoginButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LogLoginButton);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.LogLogin);
            this.panel2.Controls.Add(this.LogPassword);
            this.panel2.Location = new System.Drawing.Point(436, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 405);
            this.panel2.TabIndex = 3;
            // 
            // RegLogin
            // 
            this.RegLogin.Location = new System.Drawing.Point(0, 31);
            this.RegLogin.Name = "RegLogin";
            this.RegLogin.Size = new System.Drawing.Size(137, 23);
            this.RegLogin.TabIndex = 0;
            this.RegLogin.Text = "Login";
            // 
            // RegPassword1
            // 
            this.RegPassword1.Location = new System.Drawing.Point(0, 75);
            this.RegPassword1.Name = "RegPassword1";
            this.RegPassword1.PasswordChar = '.';
            this.RegPassword1.Size = new System.Drawing.Size(137, 23);
            this.RegPassword1.TabIndex = 1;
            // 
            // RegPassword2
            // 
            this.RegPassword2.Location = new System.Drawing.Point(0, 119);
            this.RegPassword2.Name = "RegPassword2";
            this.RegPassword2.PasswordChar = '.';
            this.RegPassword2.Size = new System.Drawing.Size(137, 23);
            this.RegPassword2.TabIndex = 2;
            // 
            // RegRodo
            // 
            this.RegRodo.AutoSize = true;
            this.RegRodo.Location = new System.Drawing.Point(0, 148);
            this.RegRodo.Name = "RegRodo";
            this.RegRodo.Size = new System.Drawing.Size(96, 19);
            this.RegRodo.TabIndex = 3;
            this.RegRodo.Text = "Zgoda RODO";
            this.RegRodo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Powtórz hasło:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hasło:";
            // 
            // RegButton
            // 
            this.RegButton.Location = new System.Drawing.Point(0, 173);
            this.RegButton.Name = "RegButton";
            this.RegButton.Size = new System.Drawing.Size(75, 23);
            this.RegButton.TabIndex = 7;
            this.RegButton.Text = "Zarejestruj";
            this.RegButton.UseVisualStyleBackColor = true;
            this.RegButton.Click += new System.EventHandler(this.RegButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RegButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RegRodo);
            this.panel1.Controls.Add(this.RegPassword2);
            this.panel1.Controls.Add(this.RegPassword1);
            this.panel1.Controls.Add(this.RegLogin);
            this.panel1.Location = new System.Drawing.Point(12, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 406);
            this.panel1.TabIndex = 2;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Register";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox LogLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LogLoginButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox RegLogin;
        private System.Windows.Forms.TextBox RegPassword1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox RegRodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RegButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox RegPassword2;
        private System.Windows.Forms.TextBox LogPassword;
    }
}
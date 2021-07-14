using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace WindowsFormsApp1 {
    public partial class Register : Form {
        public Register() {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e) {}       
        
        private void Register_Click(object sender, EventArgs e) {}

        private void RegButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegLogin.Text)) {
                MessageBox.Show("Pole nie może być puste, podaj login");
            } else if(UserExists(RegLogin.Text)) {
                MessageBox.Show("Ta nazwa jest już zajęta");
            } else if(string.IsNullOrWhiteSpace(RegPassword1.Text)) {
                MessageBox.Show("Pole nie może być puste, podaj hasło");
            } else if(string.IsNullOrWhiteSpace(RegPassword2.Text)) {
                MessageBox.Show("Pole nie może być puste, powtórz hasło");
            } else if(RegPassword1.Text != RegPassword2.Text) {
                MessageBox.Show("Hasła nie są takie same");
            } else if(!RegRodo.Checked) {
                MessageBox.Show("Zaakceptuj RODO");
            } else {
                User.AddUser(new User(RegLogin.Text, RegPassword1.Text));

                MessageBox.Show("Pomyślnie utworzono konto");
            }
        }

        private void LogLoginButton_Click(object sender, EventArgs e) {
            if(User.Users.Any(value => value.Username == LogLogin.Text && value.Password == LogPassword.Text)) {
                MessageBox.Show("Zalogowano pomyślnie");
            } else if(UserExists(LogLogin.Text)) {
                MessageBox.Show("Niepoprawne hasło");
            } else {
                MessageBox.Show("Podany użytkownik nie istnieje");
            }
        }

        static bool UserExists(string login) {
            if(User.Users.Exists(x => x.Username.Contains(login))) {
                return true;
            }

            return false;
        }
    }
}

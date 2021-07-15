using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2 {
    public class User {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Admin { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Class { get; set; }

        public User(string name, string surname, bool admin) {
            Name = name;
            Surname = surname;
            Admin = admin;
        }

        public User(System.Int32 ID, System.String Name, System.String Surname, System.Boolean Admin, System.String Password, System.String Login, System.String Class) {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Admin = Admin;
            this.Password = Password;
            this.Login = Login;
            this.Class = Class;
        }

        public User(System.String Class) {
            this.Class = Class;
        }

        public User(System.String Name, System.String Surname) {
            this.Name = Name;
            this.Surname = Surname;

        }
    }
}

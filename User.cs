using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    class User {
        public static List<User> Users = new List<User>();
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password) {
            this.Username = username;
            this.Password = password;
        }

        public static void AddUser(User user) {
            Users.Add(user);
        }
    }
}

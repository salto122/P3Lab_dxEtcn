using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;


namespace WpfApp2
{
    class DB {
        private SqlConnection OpenConnection() {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            return con;
        }

        public IEnumerable<User> LoginUser(string login, string password) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<User>(
                   "SELECT * FROM Users WHERE Login = @NAME AND Password = @PASSWORD",
                   new {
                       NAME = login,
                       PASSWORD = password
                   }
               );
            }
        }

        public IEnumerable<Classes> GetClasses() {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<Classes>("SELECT * FROM Classes");
            }
        }        
        
        public IEnumerable<User> GetClass() {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<User>("SELECT Class FROM Users WHERE Admin = 0 GROUP BY(Class)");
            }
        }        
        
        public IEnumerable<User> GetUsers(string optClass) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<User>("SELECT Name, Surname FROM Users WHERE Class = @CLASS",
                    new {
                        CLASS = optClass
                    }
                );
            }
        }

        public IEnumerable<DataGrid> GetGradesClass(string selectedClass = "", string searchClass = "", string searchName = "", string searchSurname = "") {
            string statements = "";

            if (selectedClass != "") {
                statements += " AND Classes.Name = @CLASS";
            }

            if (searchClass != "") {
                statements += " AND Users.Class = @SCLASS";
            }

            if (searchName != "") {
                statements += " AND Users.Name = @NAME";
            }

            if (searchSurname != "") {
                statements += " AND Users.Surname = @SURNAME";
            }

            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<DataGrid>("SELECT Users.Class, Users.Name, Users.Surname, Grade, Wage, Date " +
                    "FROM Users, Grades, Classes " +
                    "WHERE Grades.Student_ID = Users.ID AND Class_ID = Classes.ID" + statements,
                    new { 
                        CLASS = selectedClass,
                        SCLASS = searchClass,
                        NAME = searchName,
                        SURNAME = searchSurname
                    }
                );
            }
        }

        public int AddGrade() {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute("",
                    new {

                    }
                );
            }
        }
    }
}

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
                return _connection.Query<User>("SELECT ID, Name, Surname FROM Users WHERE Class = @CLASS",
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
                return _connection.Query<DataGrid>("SELECT Grades.ID, Users.Class, Users.Name, Users.Surname, Grade, Wage, Date " +
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

        public int AddGrade(string student, int teacher, string classes, string wage, string grade) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute("INSERT INTO Grades VALUES(@STUDENT, @TEACHER, @CLASS, @WAGE, @DATE, @GRADE)",
                    new {
                        STUDENT = student,
                        TEACHER = teacher,
                        CLASS = classes,
                        WAGE = wage,
                        DATE = DateTime.Now,
                        GRADE = grade
                    }
                );
            }
        }

        public int GetLogedData(string login, string password) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.QueryFirstOrDefault<int>(
                   "SELECT ID FROM Users WHERE Login = @NAME AND Password = @PASSWORD AND Admin = 1",
                   new {
                       NAME = login,
                       PASSWORD = password
                   }
               );
            }
        }

        public User LoginUser(string login, string password) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.QueryFirstOrDefault<User>(
                   "SELECT * FROM Users WHERE Login = @NAME AND Password = @PASSWORD",
                   new {
                       NAME = login,
                       PASSWORD = password
                   }
               );
            }
        }

        public int DeleteGrade(int id) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute("DELETE FROM Grades WHERE ID = @ID",
                    new {
                       ID = id
                    }
                );
            }
        }
    }
}

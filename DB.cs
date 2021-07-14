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

        public IEnumerable<DataGrid> GetGradesClass(string selectedClass) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<DataGrid>("SELECT Users.Class, Users.Name, Users.Surname, Classes.Name, Grade, Wage, Date FROM Users, Grades, Classes WHERE Grades.Student_ID = Users.ID AND Class_ID = Classes.ID AND Classes.Name = @CLASS",
                    new { 
                        CLASS = selectedClass
                    }
                );
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using Dapper;

namespace Lab2
{
    public class DB {
        private IDbConnection _connection;
        public DB(string connectionString) {
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Employees> GetEmployees() {
            return _connection.Query<Employees>("SELECT * FROM dbo.Pracownicy");
        }

        public Employees GetEmployee(string id) {
            return _connection.QuerySingle<Employees>("SELECT * FROM dbo.Pracownicy WHERE IDpracownika = @ID", new { ID = id });
        }

        public bool AddOrder(string orderId, string productId, string price, string amount, string discount) {
            return _connection.Execute(
                       "INSERT INTO dbo.PozycjeZamówienia (IDproduktu, IDzamówienia, CenaJednostkowa, Ilość, Rabat) VALUES (@PRODUCTID, @ORDERID, @PRICE, @AMOUNT, @DISCOUNT)",
                       new {
                           PRODUCTID = productId, 
                           ORDERID = orderId, 
                           PRICE = price, 
                           AMOUNT = amount, 
                           DISCOUNT = discount
                       }) == 1;
        }

        public bool DeleteEmployee(string id) {
            return _connection.Execute("DELETE FROM dbo.Pracownicy WHERE IDPracownika = @ID", new {ID = id}) == 1;
        }

        public bool UpdateEmployee(string id, string name) {
            return _connection.Execute("UPDATE dbo.Pracownicy SET Imię = @NAME WHERE IDPracownika = @ID",
                new {NAME = name, ID = id}) == 1;
        }
    }
    
    public class Employees {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            var db = new DB(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");

            foreach (var value in db.GetEmployees()) {
                Console.WriteLine($"{value.Id} {value.Name}");
            }
            
            Console.Write("Podaj ID szukanego pracownika ktorego chcesz wyswietlic: ");
            var employeeData = db.GetEmployee(Console.ReadLine());
            Console.WriteLine($"{employeeData.Id} {employeeData.Name}");
            
            Console.Write("Podaj ID zamowienia ktore chcesz dodac: ");
            string orderId = Console.ReadLine();                 
            
            Console.Write("Podaj ID zamowienia ktore chcesz dodac: ");
            string productId = Console.ReadLine();            
            
            Console.Write("Podaj cene ktora chcesz dodac: ");
            string price = Console.ReadLine();
            
            Console.Write("Podaj ilosc ktora chcesz dodac: ");
            string amount = Console.ReadLine();            
            
            Console.Write("Podaj rabat ktory chcesz dodac: ");
            string discount = Console.ReadLine();

            db.AddOrder(orderId, productId, price, amount, discount);
            
            Console.Write("Podaj ID szukanego pracownika którego chcesz usunąć: ");
            db.DeleteEmployee(Console.ReadLine());

            Console.Write("Podaj ID szukanego pracownika któremu chcesz zmienić imie: ");
            string employeeId = Console.ReadLine();
            Console.Write("Podaj imie: ");
            string employeeName = Console.ReadLine();
            db.UpdateEmployee(employeeId, employeeName);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using Dapper;

namespace S4L1{
    class DB {
        private IDbConnection _connection;
        public DB(string connectionString) {
            _connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Employees> GetEmployees()
        {
            return _connection.Query<Employees>("SELECT * FROM dbo.Pracownicy");
        }

        public Employees GetEmployee(string id)
        {
            return _connection.QuerySingle<Employees>("SELECT * FROM dbo.Pracownicy WHERE IDpracownika = @ID", new { ID = id });
        }

        public bool AddOrder(string orderId, string productId, string price, string amount, string discount)
        {
            return _connection.Execute(
                       "INSERT INTO dbo.PozycjeZamówienia (IDproduktu, IDzamówienia, CenaJednostkowa, Ilość, Rabat) VALUES (@PRODUCTID, @ORDERID, @PRICE, @AMOUNT, @DISCOUNT)",
                       new
                       {
                           PRODUCTID = productId,
                           ORDERID = orderId,
                           PRICE = price,
                           AMOUNT = amount,
                           DISCOUNT = discount
                       }) == 1;
        }

        public bool DeleteEmployee(string id)
        {
            return _connection.Execute("DELETE FROM dbo.Pracownicy WHERE IDPracownika = @ID", new { ID = id }) == 1;
        }

        public bool UpdateEmployee(string id, string name)
        {
            return _connection.Execute("UPDATE dbo.Pracownicy SET Imię = @NAME WHERE IDPracownika = @ID",
                new { NAME = name, ID = id }) == 1;
        }
    }
}

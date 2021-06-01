using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace S4L1
{
    class DB {
        private IDbConnection _connection;

        public DB(string connectionString) {
            _connection = new SqlConnection(connectionString);
        }

        
        public IEnumerable<Pracownicy> GetPracownicy() {
            return _connection.Query<Pracownicy>("SELECT * FROM dbo.Pracownicy");
        }        
        
        public int UpdatePracownik(int id, string imie) {
            return _connection.Execute("UPDATE dbo.Pracownicy SET Imię = @NAME WHERE IDPracownika = @ID",
                new {
                    NAME = imie,
                    ID = id
                });
        }        
        
        public int InsertZamowienie(int productId, int orderId, int price, int amount, int discount) {
            return _connection.Execute("INSERT INTO dbo.PozycjeZamówienia(IDproduktu, IDzamówienia, CenaJednostkowa, Ilość, Rabat) VALUES(@PRODUCTID, @ORDERID, @PRICE, @AMOUNT, @DISCOUNT)",
                new {
                    PRODUCTID = productId,
                    ORDERID = orderId,
                    PRICE = price,
                    AMOUNT = amount,
                    DISCOUNT = discount
                });
        }

        public int DeletePracownik(int id)
        {
            return _connection.Execute("DELETE FROM dbo.Pracownicy WHERE IDPracownika = @ID",
            new {
                ID = id
            });
        }
    }
}

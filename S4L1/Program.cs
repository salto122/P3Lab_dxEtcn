﻿using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace S4L1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            
            var queryString = "SELECT * FROM dbo.Pracownicy";
            var command = new SqlCommand(queryString, connection);
            var reader = command.ExecuteReader();
            
            foreach (DbDataRecord value in reader) {
                Console.WriteLine(value.GetString(1) +  " " + value.GetString(2));
            }
            
            Console.Write("Podaj ID szukanego pracownika któremu chcesz zmienić imie: ");
            string employeeId = Console.ReadLine();
            Console.Write("Podaj imie: ");
            string employeeName = Console.ReadLine();
            
            var updateSql = "UPDATE dbo.Pracownicy SET Imię = @NAME WHERE IDPracownika = @ID";
            var updateExec = new SqlCommand(updateSql, connection);
            updateExec.Parameters.Add(new SqlParameter("@ID", employeeId));
            updateExec.Parameters.Add(new SqlParameter("@NAME", employeeName));
            updateExec.ExecuteNonQuery();

            Console.Write("Podaj ID zamowienia: ");
            string orderId = Console.ReadLine();                 
            
            Console.Write("Podaj ID zamowienia: ");
            string productId = Console.ReadLine();            
            
            Console.Write("Podaj cene: ");
            string price = Console.ReadLine();
            
            Console.Write("Podaj ilosc: ");
            string amount = Console.ReadLine();            
            
            Console.Write("Podaj rabat: ");
            string discount = Console.ReadLine();
            
            var insertSql = $"INSERT INTO dbo.PozycjeZamówienia (IDproduktu, IDzamówienia, CenaJednostkowa, Ilość, Rabat) VALUES (@PRODUCTID, @ORDERID, @PRICE, @AMOUNT, @DISCOUNT)";
            var insertExec = new SqlCommand(insertSql, connection);
            insertExec.Parameters.Add(new SqlParameter("@PRODUCTID", productId));
            insertExec.Parameters.Add(new SqlParameter("@ORDERID", orderId));
            insertExec.Parameters.Add(new SqlParameter("@PRICE", price));
            insertExec.Parameters.Add(new SqlParameter("@AMOUNT", amount));
            insertExec.Parameters.Add(new SqlParameter("@DISCOUNT", discount));
            insertExec.ExecuteNonQuery();            
            
            Console.Write("Podaj ID szukanego pracownika którego chcesz usunąć: ");
            employeeId = Console.ReadLine();
            
            var deleteSql = $"DELETE FROM dbo.Pracownicy WHERE IDPracownika = @ID";
            var deleteExec = new SqlCommand(deleteSql, connection);
            deleteExec.Parameters.Add(new SqlParameter("@ID", employeeId));
            deleteExec.ExecuteNonQuery();
            
            connection.Close();
        }
    }
}
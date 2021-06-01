using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using Dapper;

namespace S4L1
{   
    class Program {
        static void Main(string[] args) {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZNorthwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true";
            var db = new DB(connectionString);

            foreach (var value in db.GetEmployees()) {
                Console.WriteLine($"{value.IDpracownika} {value.Imię}");
            }
            
            Console.Write("Podaj ID szukanego pracownika ktorego chcesz wyswietlic: ");
            var employeeData = db.GetEmployee(Console.ReadLine());
            Console.WriteLine($"{employeeData.IDpracownika} {employeeData.Imię}");


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
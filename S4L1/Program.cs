using System;
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
            DB db = new DB(connectionString);
            
            foreach (Pracownicy value in db.GetPracownicy()) {
                Console.WriteLine(value.IDpracownika +  " " + value.Imię);
            }
            
            Console.Write("Podaj ID szukanego pracownika któremu chcesz zmienić imie: ");
            int employeeId = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj imie: ");
            string employeeName = Console.ReadLine();

            db.UpdatePracownik(employeeId, employeeName);

            Console.Write("Podaj ID zamowienia: ");
            int orderId = Int32.Parse(Console.ReadLine());                 
            
            Console.Write("Podaj ID zamowienia: ");
            int productId = Int32.Parse(Console.ReadLine());            
            
            Console.Write("Podaj cene: ");
            int price = Int32.Parse(Console.ReadLine());
            
            Console.Write("Podaj ilosc: ");
            int amount = Int32.Parse(Console.ReadLine());            
            
            Console.Write("Podaj rabat: ");
            int discount = Int32.Parse(Console.ReadLine());

            db.InsertZamowienie(productId, orderId, price, amount, discount);
                    
            
            Console.Write("Podaj ID szukanego pracownika którego chcesz usunąć: ");
            employeeId = Int32.Parse(Console.ReadLine());

            db.DeletePracownik(employeeId);
        }
    }
}
using System;
using Lab3.scaffoldmodel;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args) {
            var db = new ZNorthwindContext();
            db.Add(new MyUsers() { 
                Name = "Adam"
            });

            db.SaveChanges();
        }
    }
}

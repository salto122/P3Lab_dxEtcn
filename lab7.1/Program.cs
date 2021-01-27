using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace lab7
{
    interface IPrintable {
        void Print();
    }
    
    class ExampleClass : ICloneable, IComparable<ExampleClass>, IPrintable {
        public int Id { get; set; }
        public string TextField { set; get; }
        public int[] Tab = new int[10];

        public ExampleClass(int id, string textField) {
            Id = id;
            TextField = textField;
            Random rand = new Random();
            
            for (int i = 0; i < 10; i++) {
                Tab[i] = rand.Next(0, 9);
            }
        }
        
        public ExampleClass() { }
        
        public object Clone()
        {
            var data = new ExampleClass() {
                Id = this.Id,
                TextField = this.TextField, 
                Tab = (int[])this.Tab.Clone()
            };

            return data;
        }

        public void Print() {
            Console.WriteLine($"\n\nID: {this.Id}");
            Console.WriteLine($"Tekst: {this.TextField}");
            Console.Write($"Tabelka:");

            foreach (int value in Tab) {
                Console.Write($" {value}");
            }
        }

        public int CompareTo(ExampleClass other) {
            if (other == null) 
                return 1;
            
            return TextField.CompareTo(other.TextField);
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Random rand = new Random();
            
            string GenText() {
                string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz";
                string tempText = "";
                
                for (int i = 0; i < 10; i++) {
                    int num = rand.Next(0, chars.Length -1);
                    tempText += chars[num];
                }

                return tempText;
            }

            ExampleClass [] exampleClasses = new ExampleClass[100];
            for (int i = 0; i < 100; i++) {
                exampleClasses[i] = new ExampleClass(i, GenText());
                exampleClasses[i].Print();
            }

            List<ExampleClass> classesList = new List<ExampleClass>();
            
            for (int i = 0; i < 100; i++) {
                classesList.Add(exampleClasses[i].Clone() as ExampleClass);
            }
            
            foreach (var value in exampleClasses) {
                Array.Clear(value.Tab, 0, value.Tab.Length);
            }
            
            classesList.Sort();
            
            foreach (var value in classesList) {
                value.Print();
            }
        }
    }
}
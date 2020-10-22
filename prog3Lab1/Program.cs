using System;
using System.Linq;

namespace lab3 {
    internal class Program {
        public static int[][] GenerateTable() {
            var rand = new Random();
            int[][] myTable = new int[rand.Next(2, 6)][];

            for (int i = 0; i < myTable.Length; i++) {
                myTable[i] = new int[rand.Next(2, 6)];

                for (int j = 0; j < myTable[i].Length; j++) {
                    myTable[i][j] = rand.Next(0, 9);
                    Console.Write(myTable[i][j]);
                }

                Console.WriteLine();
            }

            return myTable;
        }

        public static int SumTable(int[][] myTable) {
            int tableSum = 0;

            for (int i = 0; i < myTable.GetLength(0); i++) {
                tableSum += myTable[i].Sum();
            }

            return tableSum;
        }

        public static void TextValidator(string userInput) {
            userInput = userInput.Remove(0, 1).Insert(0,
                userInput.Substring(0, 1).ToUpper());

            if (userInput.Substring(userInput.Length - 1, 1) != ".") {
                userInput = userInput.Insert(userInput.Length, ".");
            }

            Console.WriteLine(userInput);
        }

        public static void Main(string[] args) {
            Console.WriteLine("\n{0}", SumTable(GenerateTable()));

            TextValidator(Console.ReadLine());
        }
    }
}
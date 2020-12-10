using System;

namespace ConsoleApp1
{
    class Lokalizacja
    {
        public int NumerRegalu { get; set; }
        public int NumerPulki { get; set; }
        public int NumerMiejsca { get; set; }

        public Lokalizacja(int numerRegalu, int numerPulki, int numerMiejsca)
        {
            NumerRegalu = numerRegalu;
            NumerPulki = numerPulki;
            NumerMiejsca = numerMiejsca;
        }
    }

    class Ksiazka
    {
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public Lokalizacja lok { get; set; }

        public Ksiazka(string tytul, string autor, int numerRegalu, int numerPulki, int numerMiejsca)
        {
            Tytul = tytul;
            Autor = autor;
            lok = new Lokalizacja(numerRegalu, numerPulki, numerMiejsca);
        }
    }

    class Program
    {
        static void FindBook(string userInput, Ksiazka[,,] spis) {
            for (int i = 0; i < spis.GetLength(0); i++) {
                for (int j = 0; j < spis.GetLength(1); j++) {
                    for (int k = 0; k < spis.GetLength(2); k++) {
                        if (spis[i, j, k].Tytul.Contains(userInput) || spis[i, j, k].Tytul.Contains(userInput)) {
                            Console.WriteLine("Tytuł: {0} Autor: {1} Regał: {2} Pułka: {3} Miejsce: {4}",
                                spis[i, j, k].Tytul, spis[i, j, k].Autor, spis[i, j, k].lok.NumerRegalu,
                                spis[i, j, k].lok.NumerPulki, spis[i, j, k].lok.NumerMiejsca);
                        }
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Ksiazka[,,] spis = new Ksiazka[3, 6, 10];
            
            for (int i = 0; i < spis.GetLength(0); i++) {
                for (int j = 0; j < spis.GetLength(1); j++) {
                    for (int k = 0; k < spis.GetLength(2); k++) {
                        spis[i, j, k] = new Ksiazka((i + 1 * j + 1 * k + 1 * 555).ToString(),
                            (i + 1 * j + 1 * k + 1 * 999).ToString(), i, j, k);

                        Console.WriteLine("Tytul: {0} Autor: {1}", spis[i, j, k].Tytul, spis[i, j, k].Autor);
                    }
                }
            }

            spis[2, 4, 6].Tytul = "astra";
            spis[2, 4, 6].Autor = "duke";
            
            Console.Write("\nPodaj tytuł lub autora książki której szukasz: ");
            
            FindBook(Console.ReadLine(), spis);
        }
    }
}
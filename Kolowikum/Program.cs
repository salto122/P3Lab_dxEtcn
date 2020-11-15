using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Kolowikum {
    class Reklama {
        public int IloscWyswietlen { get; private set; }
        private int MaxWiek { get; }
        private int MinWiek { get; }
        private string Link { get; }
        private bool Plec { get; }

        public Reklama(int minWiek, int maxWiek, string link, bool plec) {
            IloscWyswietlen = 0;
            MaxWiek = maxWiek;
            MinWiek = minWiek;
            Link = link;
            Plec = plec;
        }
        public string Wyswietl() {
            IloscWyswietlen++;
            return Link;
        }

        public bool Filtr(int wiek, bool plec) {
            if (wiek < MaxWiek && wiek > MinWiek && plec == Plec) { return true; }
            else { return false; }
        }
    }
    
    class Program {
        static void Zuzycie(double U, double I, double T) {
            Console.WriteLine($"Zużyto {U * I * T} kWh");
        }

        static int CzyZawiera(string usrInput) {
            if (!usrInput.Contains("ATH")) {
                Console.WriteLine("String nie zawiera AHT");
                return 0;
            } else {
                Console.WriteLine("String zawiera AHT");
                return Regex.Matches(usrInput, "ATH").Count;
            }
        }
        
        static void Main(string[] args) {
            Zuzycie(10, 5, 8);
            Console.WriteLine(CzyZawiera("test test ATH test test ATH test test ATH"));
            
            Reklama rek = new Reklama(18, 60, "test.com", true);
            Console.WriteLine(rek.Wyswietl());
            Console.WriteLine(rek.Filtr(20, true));
            Console.WriteLine(rek.Filtr(14, true));
            Console.WriteLine(rek.Filtr(20, false));
            Console.WriteLine(rek.Filtr(90, false));

        }
    }
}
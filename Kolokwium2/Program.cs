using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Kolokwium2
{
    class Numery {
        private Collection<int> zapisaneNumery = new Collection<int>();

        Random rand = new Random();
        public Numery() {
            for (int i = 0; i < 10; i++) {
                string temp = "";
                for (int j = 0; j < 8; j++) {
                    temp += rand.Next(0, 9);
                }

                zapisaneNumery.Add(Int32.Parse(temp));
            }
            
            foreach (var value in zapisaneNumery) {
                Console.WriteLine(value);
            }
        }

        public object CzyPowtarza() {
            foreach (var tested in zapisaneNumery) {
                int counter = 0;
                
                foreach (var value in zapisaneNumery) {
                    if (tested == value) {
                        counter++;
                        if (counter > 1) {
                            throw new Exception();
                        }
                    } else {
                        return null;
                    }
                }
            }

            return zapisaneNumery;
        }
    }

    class Klient {
        public string Nazwisko { set; get; }
        public string Ulica { set; get; }
        public string Miasto { set; get; }
        public string KodPocztowy { set; get; }

        public Klient(string nazwisko, string ulica, string miasto, string kodPocztowy) {
            Nazwisko = nazwisko;
            Ulica = ulica;
            Miasto = miasto;
            KodPocztowy = kodPocztowy;
        }

        public void WyslijList(string tresc) {
            string path = "C:/List_" + Nazwisko + ".txt";
            File.Create(path).Dispose();
            
            using( TextWriter tw = new StreamWriter(path)) {
                tw.WriteLine($"Miasto: {Miasto}\n" +
                             $"Kod pocztowy: {KodPocztowy}\n" +
                             $"Ulica: {Ulica}\n\n" +
                             $"{tresc}\n\n" +
                             $"Z poważaniem, Firma sp. z o.o.");
                tw.Close();
            }
        }
    }

    public abstract class Wydarzenie {
        public string Data { set; get; }
    }

    public class Bitwa : Wydarzenie {
        public string Przeciwnik1 { set; get; }
        public string Przeciwnik2 { set; get; }
    }

    public class Wynalezienie : Wydarzenie {
        public string NazwaWynalazku { set; get; }
        public string NazwiskoWynalazcy { set; get; }
    }

    public class Narodziny : Wydarzenie {
        public string NazwiskoOsoby { set; get; }
        public string DataSmierci { set; get; }

    }
    
    class Program
    {
        static void Main(string[] args) {
            var noweNumery = new Numery();
            noweNumery.CzyPowtarza();
            
            var nowyKlient = new Klient("Nowak", "Katowicka", "Warszawa", "10-100");
            nowyKlient.WyslijList("test test test raz dwa trzy");
            
            var klient2 = new Klient("Klient2", "Warszawska", "Katowice", "42-200");
            klient2.WyslijList(("Lorem ipsum..."));
        }
    }
}
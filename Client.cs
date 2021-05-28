using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProg
{
    public class Client {
        public int ID_klient { get; set; }
        public string Imie { get; set; }
        public string Nazwiska { get; set; }
        public int Pesele { get; set; }
        public string Adres { get; set; }   
        public string Podpisy { get; set; }

        public Client(string imie, string nazwisko, int pesel, string adres, string podpis) {
            Imie = imie;
            Nazwiska = nazwisko;
            Pesele = pesel;
            Adres = adres;
            Podpisy = podpis;
        }

        public Client(System.Int32 ID_klienta, System.String Imię, System.String Nazwisko, System.Int32 Pesel, System.String Adres_zamieszkania, System.String Podpis) {
            ID_klient = ID_klienta;
            Imie = Imię;
            Nazwiska = Nazwisko;
            Pesele = Pesel;
            Adres = Adres_zamieszkania;
            Podpisy = Podpis;
        }
    }
}

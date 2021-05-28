using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProg
{
    public class KP {
        public int ID_KP { get; set; }
        public int Kwota { get; set; }
        public int ID_Kasy { get; set; }
        public int ID_Klienta { get; set; }
        public DateTime Data { get; set; }
        public string Miejscowosc { get; set; }
        public string Firma_wystawcy { get; set; }
        public string Adres_wystawcy { get; set; }
        public int Nip_wystawcy { get; set; }

        public string Firma_klienta { get; set; }
        public string Adres_klienta { get; set; }
        public int Nip_klienta { get; set; }
        public string Opis { get; set; }
        public string Podpis_przyjmujacego { get; set; }

        public KP(int kwota, int id_kasy, int id_klienta, DateTime data, string miejscowosc, string firma_wystawcy, string adres_wystawcy, int nip_wystawcy, 
            string firma_klienta, string adres_klienta, int nip_klienta, string opis, string podpis_przyjmujacego) {
            Kwota = kwota;
            ID_Kasy = id_kasy;
            ID_Klienta = id_klienta;
            Data = data;
            Miejscowosc = miejscowosc;
            Firma_wystawcy = firma_wystawcy;
            Adres_wystawcy = adres_wystawcy;
            Nip_wystawcy = nip_wystawcy;
            Firma_klienta = firma_klienta;
            Adres_klienta = adres_klienta;
            Nip_klienta = nip_klienta;
            Opis = opis;
            Podpis_przyjmujacego = podpis_przyjmujacego;
        }

        public KP(System.Int32 ID, System.Int32 kwota_wpłaty, System.DateTime data, System.String miejscowość, System.String nazwa_firmy_wystawcy, 
            System.String adres_wystawcy, System.Int32 nip_wystawcy, System.String nazwa_frimy_klienta, System.String adres_klienta, 
            System.Int32 nip_klienta, System.String opis, System.String podpis_przyjmującego, System.Int32 ID_kasy, System.Int32 ID_klienta) {
            ID_KP = ID;
            Kwota = kwota_wpłaty;
            Data = data;
            Miejscowosc = miejscowość;
            Firma_wystawcy = nazwa_firmy_wystawcy;
            Adres_wystawcy = adres_wystawcy;
            Nip_wystawcy = nip_wystawcy;
            Firma_klienta = nazwa_frimy_klienta;
            Adres_klienta = adres_klienta;
            Nip_klienta = nip_klienta;
            Opis = opis;
            Podpis_przyjmujacego = podpis_przyjmującego;
            ID_Kasy = ID_kasy;
            ID_Klienta = ID_klienta;
        }
    }
}

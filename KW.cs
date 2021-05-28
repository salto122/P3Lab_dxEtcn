using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProg {
    public class KW {
        public int ID_KW { get; set; }
        public int ID_Kasy { get; set; }
        public int ID_Klienta { get; set; }
        public string Firma { get; set; }
        public int Nip { get; set; }
        public string Miejscowosc { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }
        public int Kwota { get; set; }
        public string Podpis_placacego { get; set; }
        public string Podpis_przyjmujacego { get; set; }

        public KW(int id_kasy, int id_klienta, string firma, int nip, string miejscowosc, DateTime data, string opis, int kwota, string podpis_placacego, string podpis_przyjmujacego) {
            ID_Kasy = id_kasy;
            ID_Klienta = id_klienta;
            Firma = firma;
            Nip = nip;
            Miejscowosc = miejscowosc;
            Data = data;
            Opis = opis;
            Kwota = kwota;
            Podpis_placacego = podpis_placacego;
            Podpis_przyjmujacego = podpis_przyjmujacego;
        }

        public KW(System.Int32 ID, System.String nazwa_firmy, System.Int32 NIP, System.String miejscowość, System.DateTime data, 
            System.String opis, System.Int32 kwota, System.String podpis_płacącego, System.String podpis_przyjmującego, System.Int32 ID_kasy, 
            System.Int32 ID_klienta) {
            ID_KW = ID;
            Firma = nazwa_firmy;
            Nip = NIP;
            Miejscowosc = miejscowość;
            Data = data;
            Opis = opis;
            Kwota = kwota;
            Podpis_placacego = podpis_płacącego;
            Podpis_przyjmujacego = podpis_przyjmującego;
            ID_Kasy = ID_kasy;
            ID_Klienta = ID_klienta;
        }
    }
}

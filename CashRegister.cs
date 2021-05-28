using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProg
{
    public class CashRegister {
        public int ID_kas { get; set; }
        public string Wlasciciel { get; set; }
        public int Numer_kas { get; set; }

        public CashRegister(string wlasciciel, int numer_kasy) {
            Wlasciciel = wlasciciel;
            Numer_kas = numer_kasy;
        }        
        
        public CashRegister(System.Int32 ID_kasy, System.String Właściciel, System.Int32 Numer_kasy) {
            ID_kas = ID_kasy;
            Wlasciciel = Właściciel;
            Numer_kas = Numer_kasy;
        }
    }
}

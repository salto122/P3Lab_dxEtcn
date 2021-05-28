using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjektProg
{
    public class DB {
        private SqlConnection OpenConnection() {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            con.Open();
            return con;
        }

        public int CreateKW(KW kw){
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute(
                    "INSERT INTO KW (nazwa_firmy, NIP, miejscowość, data, opis, kwota, podpis_płacącego, podpis_przyjmującego, id_kasy, id_klienta) " +
                    "VALUES(@NAZWA_FIRMY, @NIP, @MIEJSCOWOSC, @DATA, @OPIS, @KWOTA, @PODPIS_PLACACEGO, @PODPIS_PRZYJMUJACEGO, @ID_KASY, @ID_KLIENTA);",
                    new {
                        NAZWA_FIRMY = kw.Firma,
                        NIP = kw.Nip,
                        MIEJSCOWOSC = kw.Miejscowosc,
                        DATA = kw.Data,
                        OPIS = kw.Opis,
                        KWOTA = kw.Kwota,
                        PODPIS_PLACACEGO = kw.Podpis_placacego,
                        PODPIS_PRZYJMUJACEGO = kw.Podpis_przyjmujacego,
                        ID_KASY = kw.ID_Kasy,
                        ID_KLIENTA = kw.ID_Klienta
                    }
                );
            }
        }
                
        public IEnumerable<KW> GetKW(string column, string condition) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<KW>("SELECT * FROM dbo.KW WHERE " + column + " = @CONDITION;",
                    new {
                        COLUMN = column,
                        CONDITION = condition
                    }
                );
            }
        }         
        
        public int CreateKP(KP kp) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute(
                    "INSERT INTO KP (kwota_wpłaty, data, miejscowość, nazwa_firmy_wystawcy, adres_wystawcy, nip_wystawcy, nazwa_frimy_klienta, adres_klienta, nip_klienta, opis, podpis_przyjmującego, ID_kasy, ID_klienta) " +
                    "VALUES(@KWOTA, @DATA, @MIEJSCOWOSC, @FIRMA_WYSTAWCY, @ADRES_WYSTAWCY, @NIP_WYSTAWCY, @FIRMA_KLIENTA, @ADRES_KLIENTA, @NIP_KLIENTA, @OPIS, @PODPIS, @ID_KASY, @ID_KLIENTA);",
                    new {
                        KWOTA = kp.Kwota,
                        DATA =  kp.Data,
                        MIEJSCOWOSC = kp.Miejscowosc,
                        FIRMA_WYSTAWCY = kp.Firma_wystawcy,
                        ADRES_WYSTAWCY = kp.Adres_wystawcy,
                        NIP_WYSTAWCY = kp.Nip_wystawcy,
                        FIRMA_KLIENTA = kp.Firma_klienta,
                        ADRES_KLIENTA = kp.Adres_klienta,
                        NIP_KLIENTA = kp.Nip_klienta,
                        OPIS = kp.Opis,
                        PODPIS = kp.Podpis_przyjmujacego,
                        ID_KASY = kp.ID_Kasy,
                        ID_KLIENTA = kp.ID_Klienta
                    }
                );
            }
        }                 
        
        public IEnumerable <CashRegister> GetCashRegister(string column, string condition) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<CashRegister>("SELECT * FROM dbo.Kasa WHERE "+ column +" = @CONDITION;",
                    new {
                        COLUMN = column,
                        CONDITION = condition
                    }
                );
            }
        }   
        
        public int CreateCashRegister(CashRegister cashRegister) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute(
                   "INSERT INTO Kasa (właściciel, numer_kasy) " +
                   "VALUES(@WLASCICIEL, @NUMER_KASY);",
                   new {
                       WLASCICIEL = cashRegister.Wlasciciel,
                       NUMER_KASY = cashRegister.Numer_kas
                   }
               );
            }
        }       
        
        public IEnumerable <Client> GetClient(string column, string condition) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<Client>("SELECT * FROM dbo.Klient WHERE " + column + " = @CONDITION;",
                    new {
                        COLUMN = column,
                        CONDITION = condition
                    }
                );
            }
        }

        public int CreateClient(Client client) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Execute(
                   "INSERT INTO Klient (imię, nazwisko, pesel, adres_zamieszkania, podpis) " +
                   "VALUES(@IMIE, @NAZWISKO, @PESEL, @ADRES_ZAMIESZKANIA, @PODPIS);",
                   new {
                       IMIE = client.Imie,
                       NAZWISKO = client.Nazwiska,
                       PESEL = client.Pesele,
                       ADRES_ZAMIESZKANIA = client.Adres,
                       PODPIS = client.Podpisy
                   }
               );
            }
        }

        public IEnumerable<KP> GetKP(string column, string condition) {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.Query<KP>("SELECT * FROM dbo.KP WHERE " + column + " = @CONDITION;",
                    new {
                        COLUMN = column,
                        CONDITION = condition
                    }
                );
            }
        }

        public int GetAmountRegisters() {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.QuerySingle<int>("SELECT COUNT(*) FROM dbo.Kasa");
            }
        }
        
        public int GetAmountClients() {
            using (SqlConnection _connection = this.OpenConnection()) {
                return _connection.QuerySingle<int>("SELECT COUNT(*) FROM dbo.Klient");
            } 
        }
    }
}

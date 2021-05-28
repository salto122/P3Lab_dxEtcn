using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace ProjektProg {
    public partial class Form1 : Form {
        DB db = new DB();

        public void RefreshLists() {
            IdKasyKP.Items.Clear();
            IdKasyKW.Items.Clear();

            IdKlientaKP.Items.Clear();
            IdKlientaKW.Items.Clear();

            for (int i = 1; i <= db.GetAmountRegisters(); i++) {
                IdKasyKP.Items.Add(i);
                IdKasyKW.Items.Add(i);
            }

            for (int i = 1; i <= db.GetAmountClients(); i++){
                IdKlientaKP.Items.Add(i);
                IdKlientaKW.Items.Add(i);
            }
        }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            RefreshLists();
            Search.Enabled = false;
        }

        private void AddKP_Click(object sender, EventArgs e) {
            int Kwota, NipWystawcy, NipKlienta;

            if(!int.TryParse(kwotaKP.Text, out Kwota)) {
                MessageBox.Show("Kwota może zawierać same liczby");
            } else if(String.IsNullOrEmpty(IdKasyKP.Text) || String.IsNullOrEmpty(IdKlientaKP.Text)) {
                MessageBox.Show("Podaj ID kasy oraz ID klienta");
            } else if(!int.TryParse(NipWystawcyKP.Text, out NipWystawcy) || !int.TryParse(NipKlientaKP.Text, out NipKlienta)) {
                MessageBox.Show("NIP może zawierać tylko liczby");
            } else {
                db.CreateKP(new KP(
                    Kwota, Int32.Parse(IdKasyKP.Text), Int32.Parse(IdKlientaKP.Text), DateTime.Parse(DataKP.Text).Date,
                    MiejscowoscKP.Text, FirmaWystawcyKP.Text, AdresWystawcyKP.Text, NipWystawcy, FirmaKlientaKP.Text, AdresKlientaKp.Text,
                    NipKlienta, OpisKP.Text, PodpisPrzyjmujacegoKP.Text
                ));
            }
        }

        private void AddKW_Click(object sender, EventArgs e) {
            int Nip, Kwota;

            if(String.IsNullOrEmpty(IdKasyKW.Text) || String.IsNullOrEmpty(IdKlientaKW.Text)) {
                MessageBox.Show("Podaj ID kasy oraz ID klienta");
            } else if(!int.TryParse(NipKlientaKW.Text, out Nip)) {
                MessageBox.Show("NIP może zawierać tylko liczby");
            } else if(!int.TryParse(KwotaKW.Text, out Kwota)) {
                MessageBox.Show("Kwota może zawierać same liczby");
            } else {
                db.CreateKW(new KW(
                    Int32.Parse(IdKasyKW.Text), Int32.Parse(IdKlientaKW.Text), FirmaKlientaKW.Text, Nip, MiejscowoscKW.Text,
                    DateTime.Parse(DataKW.Text).Date, OpisKW.Text, Kwota, PodpisPlacacegoKW.Text, PodpisPrzyjmujacegoKW.Text
                ));
            }  
        }

        private void AddDK_Click(object sender, EventArgs e) {
            int Numer;

            if(!int.TryParse(NumerDK.Text, out Numer)) {
                MessageBox.Show("Numer kasy może zawierać same liczby");
            } else {
                db.CreateCashRegister(new CashRegister(
                   WlascicielDK.Text, Numer
                ));
            }

            RefreshLists();
        }

        private void AddDC_Click(object sender, EventArgs e) {
            int Pesel;

            if (!int.TryParse(PeselDC.Text, out Pesel)) {
                MessageBox.Show("Pesel może zawierać same liczby");
            } else {
                db.CreateClient(new Client(
                    ImieDC.Text, NazwiskoDC.Text, Pesel, AdresDC.Text, PodpisDC.Text
                ));
            }

            RefreshLists();
        }

        private void TableList_Click(object sender, EventArgs e) {
            ColumnList.Items.Clear();
            Search.Enabled = false;

            switch (TableList.Text) {
                case "Kasa":
                    ColumnList.Items.Add("ID_kasy");
                    ColumnList.Items.Add("Właściciel");
                    ColumnList.Items.Add("Numer_kasy");
                    break;                
                
                case "Klient":
                    ColumnList.Items.Add("ID_klienta");
                    ColumnList.Items.Add("Imię");
                    ColumnList.Items.Add("Nazwisko");
                    ColumnList.Items.Add("Pesel");
                    ColumnList.Items.Add("Adres_zamieszkania");
                    ColumnList.Items.Add("Podpis");
                    break;                
                
                case "KP":
                    ColumnList.Items.Add("ID");
                    ColumnList.Items.Add("kwota_wpłaty");
                    ColumnList.Items.Add("data");
                    ColumnList.Items.Add("miejscowość");
                    ColumnList.Items.Add("nazwa_firmy_wystawcy");
                    ColumnList.Items.Add("adres_wystawcy");
                    ColumnList.Items.Add("nip_wystawcy");
                    ColumnList.Items.Add("nazwa_frimy_klienta");
                    ColumnList.Items.Add("adres_klienta");
                    ColumnList.Items.Add("nip_klienta");
                    ColumnList.Items.Add("opis");
                    ColumnList.Items.Add("podpis_przyjmującego");
                    ColumnList.Items.Add("ID_kasy");
                    ColumnList.Items.Add("ID_klienta");
                    break;                
                
                case "KW":
                    ColumnList.Items.Add("ID");
                    ColumnList.Items.Add("nazwa_firmy");
                    ColumnList.Items.Add("NIP");
                    ColumnList.Items.Add("miejscowość");
                    ColumnList.Items.Add("data");
                    ColumnList.Items.Add("opis");
                    ColumnList.Items.Add("kwota");
                    ColumnList.Items.Add("podpis_płacącego");
                    ColumnList.Items.Add("podpis_przyjmującego");
                    ColumnList.Items.Add("ID_kasy");
                    ColumnList.Items.Add("ID_klienta");
                    break;
            }
        }

        private void Search_Click(object sender, EventArgs e) {
            if(ColumnList.Text == "ID" || 
                ColumnList.Text == "ID_klienta" || 
                ColumnList.Text == "ID_kasy" ||
                ColumnList.Text == "kwota_wpłaty" ||
                ColumnList.Text == "nip_wystawcy" ||
                ColumnList.Text == "nip_klienta" ||
                ColumnList.Text == "Numer_kasy" ||
                ColumnList.Text == "NIP" ||
                ColumnList.Text == "kwota" ||
                ColumnList.Text == "Pesel") {
                if(new Regex(@"^\d$").IsMatch(SearchBox.Text)){
                    Communicator();
                } else {
                    MessageBox.Show("Podane pole przyjmuje tylko liczby");
                }
            } else {
                Communicator();
            }

            void Communicator() {
                switch (TableList.Text) {
                    case "Kasa":
                        DataView.DataSource = db.GetCashRegister(ColumnList.Text, SearchBox.Text);
                        break;

                    case "Klient":
                        DataView.DataSource = db.GetClient(ColumnList.Text, SearchBox.Text);
                        break;

                    case "KP":
                        DataView.DataSource = db.GetKP(ColumnList.Text, SearchBox.Text);
                        break;

                    case "KW":
                        DataView.DataSource = db.GetKW(ColumnList.Text, SearchBox.Text);
                        break;
                }
            }
        }

        private void ColumnList_Click(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(ColumnList.Text)) {
                Search.Enabled = true;
            }
        }
    }
}

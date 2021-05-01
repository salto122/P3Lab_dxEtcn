using System;

namespace Lab4 {
    class Program {
        static void Main(string[] args) {
            var tph = new TPH();

            tph.Osoba.Add(new Pracownik() { Imie = "Bogusław", Nazwisko = "Łęcina", DataZatrudnienia = DateTime.Now.AddDays(80), DataZwolnienia = null });
            tph.Osoba.Add(new Pracownik() { Imie = "Dominik", Nazwisko = "Jachaś", DataZatrudnienia = DateTime.Now.AddDays(42), DataZwolnienia = null });

            tph.Osoba.Add(new Klient() { Imie = "Sebastian", Nazwisko = "Bąk", NumerTelefonu = "123-456-789", NrRejestracyjny = "YI77ER" });
            tph.Osoba.Add(new Klient() { Imie = "Mariusz", Nazwisko = "Mars", NumerTelefonu = "987-654-321", NrRejestracyjny = "ORZ3L1" });

            tph.SaveChanges();            
            
            var tpt = new TPT();

            tpt.Osoba.Add(new Pracownik() { Imie = "Bogusław", Nazwisko = "Łęcina", DataZatrudnienia = DateTime.Now.AddDays(80), DataZwolnienia = null });
            tpt.Osoba.Add(new Pracownik() { Imie = "Dominik", Nazwisko = "Jachaś", DataZatrudnienia = DateTime.Now.AddDays(42), DataZwolnienia = null });

            tpt.Osoba.Add(new Klient() { Imie = "Sebastian", Nazwisko = "Bąk", NumerTelefonu = "123-456-789", NrRejestracyjny = "YI77ER" });
            tpt.Osoba.Add(new Klient() { Imie = "Mariusz", Nazwisko = "Mars", NumerTelefonu = "987-654-321", NrRejestracyjny = "OBW47" });

            tpt.SaveChanges();
        }
    }
}

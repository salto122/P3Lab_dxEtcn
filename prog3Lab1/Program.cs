using System;

namespace prog3Lab1 {
    public enum Mz {
        Dwa,
        Jedno,
        Brak
    }

    class Program {
        static void Main(string[] args) {
            double a = 0, b = 0, c = 0;

            if (!double.TryParse(Console.ReadLine(), out a) ||
                !double.TryParse(Console.ReadLine(), out b) ||
                !double.TryParse(Console.ReadLine(), out c)) {
                Console.WriteLine("Podano niepoprawne dane");
                return;
            }

            double delta = (Math.Pow(b, 2) - 4 * a * c);
            Console.WriteLine($"Delta: {delta}");
            Mz iloscMiejsc;

            if (delta > 0) {
                iloscMiejsc = Mz.Dwa;
            }
            else if (delta == 0) {
                iloscMiejsc = Mz.Jedno;
            }
            else {
                iloscMiejsc = Mz.Brak;
            }

            Console.WriteLine($"Ilość miejsc zerowych w tej delcie to: {iloscMiejsc}");

            switch (iloscMiejsc) {
                case Mz.Dwa:
                    Console.WriteLine($"x1: {((-b + Math.Sqrt(delta)) / 2 * a)}" +
                                      $"\nx2: {((-b - Math.Sqrt(delta)) / 2 * a)}");
                    break;

                case Mz.Jedno:
                    Console.WriteLine($"x1: {(-b / 2 * a)}");
                    break;
            }
        }
    }
}
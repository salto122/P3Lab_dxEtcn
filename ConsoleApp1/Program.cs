using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Channel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public int LicznikWyswietlen { get; set; }
        public int Subs { get; set; }

        public Channel(int id, string nazwa) {
            Id = id;
            Nazwa = nazwa;
        }

        public void WyswietlFilm() {
            LicznikWyswietlen++;
        }

        public void OpublikujFilm() {
            OpublikowanoFilm?.Invoke(this, EventArgs.Empty);
        }

        public void SubujKanal() {
            Subs++;
        }

        public EventHandler OpublikowanoFilm;
    }
    
    public static class ChannelExtension {
        public static void Wypisz(this Channel chnl) {
            Console.WriteLine($"Nazwa: {chnl.Nazwa}" +
                              $"Ilość wyświetleń: {chnl.LicznikWyswietlen}" +
                              $"Ilość subskrypcji: {chnl.Subs}");
        }
    }

   public class User {
        public int Id { get; set; }
        public string Nazwa { get; set; }

        public void SubskrybujKanal(Channel chnl) {
            chnl.SubujKanal();
            Console.WriteLine($"użytkownik {Nazwa} otrzymał powiadomienie o nowym filmie");
            chnl.OpublikujFilm();
            chnl.OpublikowanoFilm += NowyFilm;
        }

        public User(int id, string nazwa) {
            Id = id;
            Nazwa = nazwa;
        }

        private void NowyFilm(object sender, EventArgs e) {
            Console.WriteLine("Opublikowano nowy film");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Channel newChannal = new Channel(20, "Kanał testowy");
            
            List<User> users = new List<User>();
            users.Add(new User(1,"Arek"));
            users.Add(new User(2,"Marek"));
            users.Add(new User(3,"Jarek"));

            foreach (var value in users) {
                value.SubskrybujKanal(newChannal);
            }
            
            newChannal.Wypisz();
            newChannal.WyswietlFilm();
        }
    }
}
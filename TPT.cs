using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Lab4 {
    public class TPT:DbContext {
        public DbSet<Osoba> Osoba { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pracownik>().ToTable("Pracownicy");
            modelBuilder.Entity<Klient>().ToTable("Klienci");
        }
    }
}

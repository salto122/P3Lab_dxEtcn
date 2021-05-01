using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Lab4 {
    public class TPH : DbContext {
        public DbSet<Osoba> Osoba { get; set; }
    }
}

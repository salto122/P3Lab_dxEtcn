using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.scaffoldmodel
{
    public partial class Kategorie
    {
        public Kategorie()
        {
            Produkties = new HashSet<Produkty>();
        }

        public int Idkategorii { get; set; }
        public string NazwaKategorii { get; set; }
        public string Opis { get; set; }
        public byte[] Rysunek { get; set; }

        public virtual ICollection<Produkty> Produkties { get; set; }
    }
}

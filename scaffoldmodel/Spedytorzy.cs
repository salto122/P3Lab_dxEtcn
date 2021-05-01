﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.scaffoldmodel
{
    public partial class Spedytorzy
    {
        public Spedytorzy()
        {
            Zamówienia = new HashSet<Zamówienium>();
        }

        public int Idspedytora { get; set; }
        public string NazwaFirmy { get; set; }
        public string Telefon { get; set; }

        public virtual ICollection<Zamówienium> Zamówienia { get; set; }
    }
}

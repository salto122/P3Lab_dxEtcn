using System;
using System.Collections.Generic;

#nullable disable

namespace Lab3.scaffoldmodel
{
    public partial class ZUsa
    {
        public string Idklienta { get; set; }
        public string NazwaOdbiorcy { get; set; }
        public string MiastoOdbiorcy { get; set; }
        public string KrajOdbiorcy { get; set; }
        public int Idzamówienia { get; set; }
        public DateTime? DataZamówienia { get; set; }
        public decimal? Cena { get; set; }
    }
}

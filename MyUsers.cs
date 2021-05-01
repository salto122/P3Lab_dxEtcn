using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3{
    public class MyUsers {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}

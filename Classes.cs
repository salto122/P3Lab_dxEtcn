using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Classes {
        public int ID { get; set; }
        public string Name { get; set; }

        public Classes(string name) {
            Name = name;
        }

        public Classes(System.Int32 ID, System.String Name) {
            this.ID = ID;
            this.Name = Name;
        }
    }
}

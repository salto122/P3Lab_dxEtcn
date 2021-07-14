using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Scripts {
        DB db = new DB();

        public int LoginUser(string login, string password) {
            if(db.LoginUser(login, password).Count<User>() > 0) {
                return (2);
            }

            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puente;


namespace control
{

    public class Control_login
    {
        Proceso_login proceso_login = new Proceso_login();

        public bool loginuser(string user, string cont)
        {
            return proceso_login.Login(user,cont);
        }
     

    }

        //}

        //public void validar(string user, string cont)
        //{
        //    pl.validar(user,cont);



        //}


       //    public string Userlogincache1(string t,string u)
       //{
       //     //    try
       //     //    {
       //          Userlogincache1(t, u);
       //     //    }catch
       //     //    {
       //    return Userlogincache.use;
       //    }
          

       // }
        public static class Userlogincache
        {
            public static string use { get; set; }
            public static string con { get; set; }

        }
   // }
}

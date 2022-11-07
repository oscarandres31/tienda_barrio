using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relacion
{

  
   public class  Usuariocache
    {
    

        public static string Nombre{ get; set; }
     

        public static  string Rol{ get; set; }
      

        public static  string Contraseñas{ get; set; }
    

       
      
        public  static string Usuario { get; set; }
       
    }

    public class Recuperar_contraseñas
    {
        public static string Usuario { get; set; }

        public static long Cedula { get; set; }

        public static string Contraseña { get; set; }
    }


}

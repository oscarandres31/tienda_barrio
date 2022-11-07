using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;

namespace control
{

   
    public class Control_contraseña_recuperar
    {
        Proceso_contraseña pc = new Proceso_contraseña();

        public bool Login(string user, string ced)
        {
         
                  return pc.Login(user, ced);

        
        }
        public bool Cambiar_contraseña(string con)
        {
          


            return pc.Cambia_contraseña(con);
        }
    }

    



}

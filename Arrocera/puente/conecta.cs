using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace puente
{
   public class conecta
    {
       

        public static string cadenaconexion = "server=localhost;user id=andremar;port=5432;database=arrocera;password=andrelo31";
        public  static NpgsqlConnection getcn()
        {
          

            NpgsqlConnection con = new NpgsqlConnection(cadenaconexion);
           
            return con;
        }
      


        public void Validar_conexion()
        {
            NpgsqlConnection c= new NpgsqlConnection(cadenaconexion);
            if (c.State== System.Data.ConnectionState.Closed)
            {
                MessageBox.Show("No Estas Conectado");
            }


          //  return false ;
        }





        }
    }
//}

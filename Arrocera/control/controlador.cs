using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using puente;


namespace control
{
   public class controlador
    {

        procesos pro = new procesos();

        public DataTable listar_usuarios()
        {
            return pro.listar_usuarios();
        }


        public void guarda_usuario(long ced, string nom, string usu, string cont,string rol)
        {
            pro.guarda_usuario(ced,nom,usu,cont,rol);
        }

        public void delete_usuario(long ced)
        {
            pro.delete_usuario(ced);
        }




        public void  usuario()
        {
            //puente.procesos p = new procesos();
            //guarda_usuario(_cedula, _nombres, _usuario, _contraseña);


        }








        // NpgsqlConnection con = puente.conecta.getcn();

        //usuarios


        //public class conecta
        //{
        //    public static string cadenaconexion = "server=localhost;user id=andremar;port=5432;database=arrocera;password=318705oag";
        //    public static NpgsqlConnection getcn()
        //    {
        //        // get { return cadenaconexion; }

        //        NpgsqlConnection con = new NpgsqlConnection(cadenaconexion);
        //        return con;
        //    }

        //    }


        //NpgsqlConnection c = conecta.getcn();





    }
}

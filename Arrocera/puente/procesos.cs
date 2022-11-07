using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace puente
{

   
  public  class procesos
    {
       
        // conecta c = new conecta();
        NpgsqlConnection c = conecta.getcn();
        public DataTable listar_usuarios()
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llena_usuarios", c);
             cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public static string getsha256(string str)
        {
            SHA512 sha256 = SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        
        public void guarda_usuario(long ced, string nom, string usu, string cont,string rol)
        {
        string st =  getsha256(cont);
            c.Open();
           // string sql = "insert into usuarios(cedula,nombres,usuario,contraseña,roll) values ('" + ced + "','" + nom + "','" + usu + "', '" + st +"' , '" + rol + "') ";
            NpgsqlCommand cmd = new NpgsqlCommand("guarda_usuario(@ced,@nom,@usu,@con,@ro)", c);
            cmd.CommandType = CommandType.StoredProcedure;
     
            cmd.Parameters.AddWithValue("@ced",ced);
            cmd.Parameters.AddWithValue("@nom", nom);
            cmd.Parameters.AddWithValue("@usu", usu);
            cmd.Parameters.AddWithValue("@con", st);
            cmd.Parameters.AddWithValue("@ro", rol);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuario Guardado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();
        }


        public void delete_usuario(long ced)
        {

            c.Open();
           // string sql = "delete from  usuarios where cedula = '" + ced + "' ";
            NpgsqlCommand cmd = new NpgsqlCommand("delete_usuario(@ce)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ce", ced);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Usuario ELIMINADO Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();
        }

    }
}

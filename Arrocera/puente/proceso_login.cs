using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;
using relacion;






namespace puente
{

  public  class Proceso_login:procesos
    {

        NpgsqlConnection c = puente.conecta.getcn();


        public bool Login(string user, string cont)
        {
           

                string contt = getsha256(cont);
                using
               (var Command = new NpgsqlCommand("consulta2(@usuario,@Con)", c)) {
                    NpgsqlDataReader dr;
                    Command.CommandType = CommandType.StoredProcedure;
                    // Command.Transaction = trans;
                    Command.Parameters.AddWithValue("@usuario", user);
                    Command.Parameters.AddWithValue("@Con", NpgsqlTypes.NpgsqlDbType.Varchar, contt);
                //  Command.CommandType = CommandType.Text;
                 c.Open();
                 dr = Command.ExecuteReader();
                    // Command.Transaction.Commit();
                    //String user;
                    //String cont;
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            user = dr.GetValue(2).ToString();
                            contt = dr.GetString(3);
                            //  usuariocache.usuario = dr.GetString(1);
                            Usuariocache.Contraseñas = dr.GetString(3);
                            Usuariocache.Nombre = dr.GetString(1);
                            Usuariocache.Rol = dr.GetString(4);

                        }
                    dr.Close();
                    return true;
                    }
                    else
                    dr.Close();
                    return false;
                }
            }

 // }


    }



    public static class Userlogincache
    {
        public static string use { get; set; }
        public static string con { get; set; }

    }

}

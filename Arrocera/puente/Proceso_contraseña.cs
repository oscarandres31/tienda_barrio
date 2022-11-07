using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using relacion;
using System.Windows.Forms;

namespace puente
{
  public  class Proceso_contraseña:procesos
    {
        NpgsqlConnection c = puente.conecta.getcn();

        public bool Login(string user, string ced)
        {

            using
           (var Command = new NpgsqlCommand("validacedula(@usuario,@ced) "))
            {

                NpgsqlDataReader dr;
                c.Open();
           
                Command.Connection = c;
              //  Command.CommandText = "select usuario,cedula from usuarios where usuario = '" + user + "' and cedula = '" + ced + "' ";
             
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@usuario", user);
                Command.Parameters.AddWithValue("@ced", NpgsqlTypes.NpgsqlDbType.Bigint, ced);


                dr = Command.ExecuteReader();

                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        user = dr.GetString(2);
                        ced = Convert.ToUInt64(dr.GetValue(0)).ToString();
                    
                        Recuperar_contraseñas.Usuario = dr.GetString(2);
                      Recuperar_contraseñas.Cedula = dr.GetInt64(0);
                  

                    }
                    return true;
                }


                else
                    return false;


            }
            }


        public bool Cambia_contraseña(string con)
        {

            using
           (var Command = new NpgsqlCommand("actualizacontraseña(@con,@usu,@ced)"))
            {
                string contt = getsha256(con);
                NpgsqlDataReader dr;
           
               string u = Recuperar_contraseñas.Usuario;
              long  ce = Recuperar_contraseñas.Cedula;

                Command.Connection = c;
               // Command.CommandText = "update usuarios set contraseña ='" + contt +  "'  where usuario = '" + u + "' and cedula = '" + ce + "' ";
             

                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@con",contt);
                Command.Parameters.AddWithValue("@usu",u);
                Command.Parameters.AddWithValue("@ced", ce);
           



                c.Open();
         dr =
                Command.ExecuteReader();
              
             
                   if (dr.Read())
                  {

                    //Recuperar_contraseñas.Contraseña = dr.GetString(3);

                    //Recuperar_contraseñas.Usuario = dr.GetString(2);
                    //      Recuperar_contraseñas.Cedula = dr.GetInt64(0);
                  
                    MessageBox.Show("Actualizado","CORRECTO",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return true;
                
                                   }


             else
                 return false;


            }

       }

        }
}

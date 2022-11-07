using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace puente
{
   public class Proceso_devoluciones
    {
        NpgsqlConnection c = conecta.getcn();

        public DataTable Llenagri_devolucion( int nu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("busca_factura(@nu)",c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nu", nu);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;




        }

        public DataTable llenagrid_fecha(DateTime da)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("buscar_facturas(@fe)", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fe", da);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;


        }
        public bool Guarda_devolucion(long co, int ca, string rea, string obs, decimal pre, decimal sub)
        {
            c.Close();
            using
                (var cmd = new NpgsqlCommand("guarda_devolucion(@co,@ca,@re,@ob,@pre,@su)"))
            {


                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }

                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@co", co);
                cmd.Parameters.AddWithValue("@ca", ca);
                cmd.Parameters.AddWithValue("@re", rea);
                cmd.Parameters.AddWithValue("@ob", obs);
                cmd.Parameters.AddWithValue("@pre", pre);
                cmd.Parameters.AddWithValue("@su", sub);
              
                cmd.ExecuteNonQuery();
                  MessageBox.Show("Devolucion Guardada Correctamente", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.Close();
            }

            return true;

        }
        public void actualiza_producto(long cod, int can)
        {

            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand("actualiza_devolucion(@co,@ca)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();
            cmd.Parameters.AddWithValue("co", cod);
            cmd.Parameters.AddWithValue("ca", can);

            cmd.ExecuteNonQuery();
            c.Close();
        }
        public DataTable llenagrid_detalle(long co)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llena_detalle_devolucion(@co)", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@co", co);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;


        }

        public bool Eliminar_factura(int num)
        {
            c.Close();
            using
                 (var cmd = new NpgsqlCommand("delete_venta(@nu) "))
            {
                c.Open();
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nu",num);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminado Con Exito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                c.Close();

            }


            return true;
        }
        public void Actualiza_producto_factura(long cod, int can)
        {

            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand("actualiza_producto_compra(@co,@ca)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();
            cmd.Parameters.AddWithValue("co", cod);
            cmd.Parameters.AddWithValue("ca", can);

            cmd.ExecuteNonQuery();
            c.Close();
        }



    }
}

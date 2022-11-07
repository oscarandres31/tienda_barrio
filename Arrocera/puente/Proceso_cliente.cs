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
   public class Proceso_cliente
    {
        NpgsqlConnection c = conecta.getcn();
        public bool Guarda_cliente(string n,long ce,long t,string d)
        {
            c.Close();

            using

                (var cmd = new NpgsqlCommand("guarda_cliente(@ced,@nom,@tel,@dir) "))
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ced", ce);
                cmd.Parameters.AddWithValue("@nom", n);
                cmd.Parameters.AddWithValue("@tel", t);
                cmd.Parameters.AddWithValue("@dir", d);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Guardado Con Exito !", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                  
                            return true;
       

        }
        public bool Guarda_cliente2(string n, long ce, long t, string d)
        {
            c.Close();

            using

                (var cmd = new NpgsqlCommand("guarda_cliente(@ced,@nom,@tel,@dir) "))
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ced", ce);
                cmd.Parameters.AddWithValue("@nom", n);
                cmd.Parameters.AddWithValue("@tel", t);
                cmd.Parameters.AddWithValue("@dir", d);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Guardado Con Exito !", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }
        public bool Update_cliente(string n, long ce, long t, string d)
        {
            c.Close();

            using

                (var cmd = new NpgsqlCommand("update clientes set  nombres=@nom, telefono=@tel,direccion=@dir where cedula = '" + ce + "' "))
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
              //  cmd.Parameters.AddWithValue("@ced", ce);
                cmd.Parameters.AddWithValue("@nom", n);
                cmd.Parameters.AddWithValue("@tel", t);
                cmd.Parameters.AddWithValue("@dir", d);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado Con Exito !", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;


        }
        public DataTable Llenagrid_clientes(long nu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llena_clientes_data(@nu)", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nu", nu);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public DataTable Llenagrid_comprasclientes(long nu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select  cedula_cliente,nombre_cliente,sum(descuentos) as descuentos,sum(subtotal)as total from ventas where cedula_cliente = @nu  group by cedula_cliente,nombre_cliente", c);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@nu", nu);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public bool Delete_cliente( long ce)
        {
            c.Close();

            using

                (var cmd = new NpgsqlCommand("delete_cliente(@ced) "))
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ced", ce);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Eliminado Con Exito !", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return true;
        }
        public DataTable Data_clientes()
        {
            NpgsqlCommand cmd = new NpgsqlCommand("clientes_data()", c);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@nu", nu);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace puente
{
   public class proceso_proveedor
    {
        NpgsqlConnection c = conecta.getcn();
        AutoCompleteStringCollection Source = new AutoCompleteStringCollection();
        public DataTable llenagridproveedor()
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llena_proveedores", c);
             cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        public void guarda_proveedor( string nom,long ced,string emp,string prod,long tel,decimal pre)
        {

            c.Open();
        
            NpgsqlCommand cmd = new NpgsqlCommand("guardar_proveedor", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("nom", nom);
            cmd.Parameters.AddWithValue("ced", ced);
            cmd.Parameters.AddWithValue("emp", emp);
            cmd.Parameters.AddWithValue("pro", prod);
            cmd.Parameters.AddWithValue("tel", tel);
            cmd.Parameters.AddWithValue("pre", pre);
       

            cmd.ExecuteNonQuery();
            MessageBox.Show("Proveedor Guardado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();
        }

        public void actualiza_proveedor(string nom,long ced,string emp,string prod,long tel,decimal pre)
        {

            c.Open();
        
            NpgsqlCommand cmd = new NpgsqlCommand("actualizar_proveedor", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("nom", nom);
            cmd.Parameters.AddWithValue("ced", ced);
            cmd.Parameters.AddWithValue("emp", emp);
            cmd.Parameters.AddWithValue("pro", prod);
            cmd.Parameters.AddWithValue("tel", tel);
            cmd.Parameters.AddWithValue("pre", pre);
        

            cmd.ExecuteNonQuery();
            MessageBox.Show("Proveedor Actualizado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();
        }

        public void delete_proveedor(long ced)
        {
            c.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("delete_proveedor", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("ced", ced);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Proveedor Eliminado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();

        }
        public void autocompleta(TextBox textbo)
        {
            c.Close();
            try
            {

                NpgsqlDataReader dr;
                NpgsqlCommand com;
                c.Open();
                com = new NpgsqlCommand("busca_producto_proveedor",c);
                com.CommandType = CommandType.StoredProcedure;
               // com.Parameters.AddWithValue("")
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    textbo.AutoCompleteCustomSource.Add(dr["articulo"].ToString());
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            c.Close();

        }

        public   bool Buscar_proveedor(long co,string nom,long ced,string em,string pro,long tel,decimal real)
        {
            c.Close();
            using
                (var cmd = new NpgsqlCommand("buscar_proveedor(@ce)"))
            {
                c.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = c;

                cmd.Parameters.AddWithValue("@ce",NpgsqlTypes.NpgsqlDbType.Bigint, co);

                NpgsqlDataReader dr;
                dr = cmd.ExecuteReader();

                if(dr.HasRows)
                {
                    if(dr.Read())
                    {
                      nom = dr.GetString(0);

                       ced = long.Parse(dr.GetValue(1).ToString());
                       em =dr.GetString(2);
                       pro =dr.GetString(3);
                       tel = long.Parse(dr.GetValue(4).ToString());
                       real = decimal.Parse(dr.GetValue(5).ToString());



                    }

                }


                dr.Close();
                c.Close();




            }
 return true;

        }

        public DataTable llenagridproveedor_cedula(long co)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("buscar_proveedor(@ce)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ce", NpgsqlTypes.NpgsqlDbType.Bigint, co);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

    }
}

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
    

  public  class proceso_producto
    {
        NpgsqlConnection c = conecta.getcn();

        public DataTable llenagridproducto()
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llenar_producto", c);
             cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }

        public DataTable llenagridproducto2(long cod)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llenagrid_producto(@co) " , c);
           cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@co", cod);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }




        public void guarda_producto(long cod, string des, string ti,int can, string uni,decimal pre_com,decimal pre_ven,string prov)
        {
           
            c.Close();
       
            NpgsqlCommand cmd = new NpgsqlCommand("guardar_producto", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();
            cmd.Parameters.AddWithValue("cod" ,cod);
            cmd.Parameters.AddWithValue("des", des);
            cmd.Parameters.AddWithValue("tip", ti);
            cmd.Parameters.AddWithValue("can", can);
            cmd.Parameters.AddWithValue("uni", uni);
            cmd.Parameters.AddWithValue("pre_com", pre_com);
            cmd.Parameters.AddWithValue("pre_ven", pre_ven);
            cmd.Parameters.AddWithValue("prov", prov);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Producto Guardado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();
        }

        public void actualiza_producto(long cod, string des, string ti, int can, string uni, decimal pre_com, decimal pre_ven, string prov)
        {
            c.Close();

          
            NpgsqlCommand cmd = new NpgsqlCommand("actualizar_producto", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();
            cmd.Parameters.AddWithValue("cod", cod);
            cmd.Parameters.AddWithValue("des", des);
            cmd.Parameters.AddWithValue("tip", ti);
            cmd.Parameters.AddWithValue("can", can);
            cmd.Parameters.AddWithValue("uni", uni);
            cmd.Parameters.AddWithValue("pre_c", pre_com);
            cmd.Parameters.AddWithValue("pre_ven", pre_ven);
            cmd.Parameters.AddWithValue("pro", prov);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Producto Actualizado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            c.Close();
          
        }

        public void elimina_producto(long cod)
        {
            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand("delete_productos", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();
            cmd.Parameters.AddWithValue("cod ", cod);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Producto Eliminado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            c.Close();
        }

        public void llenacombo(ComboBox cm)
        {

            cm.Items.Clear();

           // String sql;
            NpgsqlCommand cmd = new NpgsqlCommand("llena_proveedor()",c);
            NpgsqlDataReader dr;
          //  sql = "llena_proveedor()";
            cmd.CommandType = CommandType.StoredProcedure;

           // cmd.Connection = c;
           // cmd.CommandText = sql;
            c.Open();

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cm.Items.Add(dr.GetString(0));
                }


            }
            dr.Close();


        }
    }
}

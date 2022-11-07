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
   public class proceso_apertura
    {
        NpgsqlConnection c = conecta.getcn();
        public bool Abrir(int num, decimal mon, DateTime fec, DateTime hor, string rea)
        {
            using
          (var cmd = new NpgsqlCommand("guarda_caja(@num,@mon,@fec,@hor,@rea) "))

            {
            c.Open();

            cmd.Connection = c;
            cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@num", num);
            cmd.Parameters.AddWithValue("@mon", mon);
            cmd.Parameters.AddWithValue("@fec", fec);
            cmd.Parameters.AddWithValue("@hor", NpgsqlTypes.NpgsqlDbType.Time, hor);
            cmd.Parameters.AddWithValue("@rea", rea);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Guardado con exito", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            return true;
           
        }
        public DataTable llenagrid()
        {

            NpgsqlCommand cmd = new NpgsqlCommand("llenaapertura", c);
            cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;


        }

        public DataTable llenagrid_detalle(DateTime f)
        {

            NpgsqlCommand cmd = new NpgsqlCommand("detalle_cajas(@fe)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fe", f);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;


        }
        public void Numero_apertura(TextBox num)
        {
            c.Close();
            int a;
            //   string sql = " ";
            NpgsqlCommand cmd = new NpgsqlCommand("detalle_numero_apertura(@nu)  ", c);
            cmd.CommandType = CommandType.StoredProcedure;
            c.Open();
            cmd.Parameters.AddWithValue("@nu", NpgsqlTypes.NpgsqlDbType.Integer, num.Text);
            // cmd.ExecuteNonQuery();
            //c.Open();
            NpgsqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (dr[0] != System.DBNull.Value)
                {
                    a = Convert.ToInt16(dr[0].ToString());
                    num.Text = (a).ToString();
                }
                else
                {
                    num.Text = 10001.ToString();
                }


            }


            c.Close();
            dr.Close();

        }




    }
}

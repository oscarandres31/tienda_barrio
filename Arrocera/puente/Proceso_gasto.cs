using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;

namespace puente
{
  public  class Proceso_gasto
    {

        NpgsqlConnection c = conecta.getcn();
        public bool Trae_gasto(int num,string raz,decimal gas,DateTime fec,DateTime hor,string autor)
        {
            using
                            (var cmd = new NpgsqlCommand("guarda_gastos(@num,@raz,@gas,@fec,@hor,@autori)"))
            {
                c.Open();

                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@num", num);
                cmd.Parameters.AddWithValue("@raz", raz);
                cmd.Parameters.AddWithValue("@gas", gas);
                cmd.Parameters.AddWithValue("@fec", NpgsqlTypes.NpgsqlDbType.Date, fec);
                cmd.Parameters.AddWithValue("@hor", NpgsqlTypes.NpgsqlDbType.Time, hor);
                cmd.Parameters.AddWithValue("@autori", autor);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Guardado con exito", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);




            }

            return true;

        }

        public DataTable llenagrid()
        {

            NpgsqlCommand cmd = new NpgsqlCommand("llenagasto", c);
           cmd.CommandType = CommandType.StoredProcedure;
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;


        }

        public DataTable Llenagrid_detallgasto(DateTime nu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("detalle_gasto(@nu)", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nu", nu);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        public DataTable Llenagrid_detallgasto_num(int nu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("detalle_gasto_numero(@nu)", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nu", nu);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public void Numero_gasto(TextBox num)
        {
            c.Close();
            int a;
            //   string sql = " ";
            NpgsqlCommand cmd = new NpgsqlCommand("detalle_numerogasto(@nu)  ", c);
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

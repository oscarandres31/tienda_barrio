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
   public class Proceso_compra
    {
        NpgsqlConnection c = conecta.getcn();


public bool Guarda_compra(int nu,long co,string pro,string me,decimal pre,int can,DateTime fec,DateTime ho,long ced,string cli,decimal des,decimal sub,decimal to,decimal pag,decimal dev)
        {
            c.Close();
            using
                (var  cmd = new NpgsqlCommand("guarda_compra(@num,@cod,@prod,@med,@pre,@can,@fec,@hor,@ced,@cli,@des,@sub,@tot,@pag,@dev)"))
            {

                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@num",nu);
                cmd.Parameters.AddWithValue("@cod",co);
                cmd.Parameters.AddWithValue("@prod",pro);
                cmd.Parameters.AddWithValue("@med",me);
                cmd.Parameters.AddWithValue("@pre",pre);
                cmd.Parameters.AddWithValue("@can",can);
                cmd.Parameters.AddWithValue("@fec",NpgsqlTypes.NpgsqlDbType.Date, fec);
                cmd.Parameters.AddWithValue("@hor",NpgsqlTypes.NpgsqlDbType.Time, ho);
                cmd.Parameters.AddWithValue("@ced",ced);
                cmd.Parameters.AddWithValue("@cli",cli);
                cmd.Parameters.AddWithValue("@des",des);
                cmd.Parameters.AddWithValue("@sub",sub);
                cmd.Parameters.AddWithValue("@tot",to);
                cmd.Parameters.AddWithValue("@pag",pag);
                cmd.Parameters.AddWithValue("@dev",dev);

                cmd.ExecuteNonQuery();
            //    MessageBox.Show("Compra Guardada Correctamente", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.Close();
            }
           
            return true;
        
        }



        public void numero_factura(Label num)
        {
            c.Close();
            int a;
          //  string sql = "";
            NpgsqlCommand cmd = new NpgsqlCommand("numero_compraincremento(@nu)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nu", num.Text);
            c.Open();
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
            dr.Close();
            c.Close();
   }



        public void actualiza_producto(long cod, int can)
        {
            c.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("actualiza_producto_compra", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("cod", cod);
            cmd.Parameters.AddWithValue("can", can);

            cmd.ExecuteNonQuery();
            c.Close();
        }

        public void Busca_codigo(TextBox bc, TextBox cod, TextBox pro, TextBox uni, TextBox pre,TextBox ca)
        {

            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand("busca_codigo_compra(@nu)",c);
            NpgsqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nu", bc.Text);
            c.Open();
            dr = cmd.ExecuteReader();
            if (string.IsNullOrWhiteSpace(bc.Text))
            {
                MessageBox.Show("Error no hay codigo que buscar");
            }
            if (dr.HasRows)
            {
                bool verificar = false;
                if (dr.Read())
                {
                    verificar = true;
                    cod.Text = (dr.GetValue(0)).ToString();
                    pro.Text = dr.GetString(1);
                    uni.Text = dr.GetString(2);
                    pre.Text = Convert.ToDecimal(dr.GetValue(3)).ToString();
                    ca.Text = 1.ToString();
                    //dr.Close();
                }
                else
                {
                   verificar = false;
                    dr.Close();
                    c.Close();
                }
                dr.Close();
          }
            else
            {

            }
            dr.Close();
            c.Close();
            }

        public DataTable Llenagrid_detallecompra(int nu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("busca_detalle_compra(@nu)", c);
             cmd.CommandType = CommandType.StoredProcedure;
           
          cmd.Parameters.AddWithValue("@nu", nu);

            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;




        }
        public void Busca_Proveedor(TextBox cod, TextBox bc)
        {
            try
            {
            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand("busca_proveedor(@nu)", c);
                       NpgsqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nu", cod.Text);
                c.Open();
                dr = cmd.ExecuteReader();
                bool verificar = false;
                if (dr.Read())
                {
                    verificar = true;
                    cod.Text = dr.GetValue(1).ToString();
                    bc.Text = dr.GetString(0);
                  
                }
                else
                {
                    verificar = false;
                    dr.Close();
                  //  c.Close();
                }
                //  }
                dr.Close();
                c.Close();
           
            }catch
            {

            }
            c.Close();
        }


    }
}

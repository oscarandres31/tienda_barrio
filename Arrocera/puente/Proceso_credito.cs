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
   public class Proceso_credito: proceso_proveedor
    {
        NpgsqlConnection c = conecta.getcn( );
        AutoCompleteStringCollection Source = new AutoCompleteStringCollection();
        public void LLenanumero(Label num)
        {
            c.Close();
            int a;

            NpgsqlCommand cmd = new NpgsqlCommand("numero_credito(@nu)", c);
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

        public void Autocompleta(TextBox t)
        {
            autocompleta(t);
        }

        public bool guardar_ventas(int num, decimal pag,  int cre, DateTime fec )
        {
            c.Close();

            using
                (var cmd = new NpgsqlCommand("guardar_abono(@nu,@ab,@num,@fe,@s)")
 )
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nu", num);
                cmd.Parameters.AddWithValue("@ab", pag);
                cmd.Parameters.AddWithValue("@num", cre);
                cmd.Parameters.AddWithValue("@fe", fec);
                cmd.Parameters.AddWithValue("@s", "1");
               

                cmd.ExecuteNonQuery();
                MessageBox.Show("Abono Guardado Con Exito", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                c.Close();
            }
            return true;
        }

        public bool Actualiza_credito(int num,decimal cor)
        {
            c.Close();

            using
                (var cmd = new NpgsqlCommand("actualizar_credito_abono(@nu,@c)")
 )
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nu", num);
                cmd.Parameters.AddWithValue("@c", cor);
                cmd.ExecuteNonQuery();
                c.Close();
            }
            return true;

        }
            



public DataTable llenagridpago(long num)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("buscar_creditos_cliente(@n)",c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@n", num);
            NpgsqlDataAdapter dp = new NpgsqlDataAdapter(cmd);
            DataTable dt =new DataTable();
            dp.Fill(dt);
            return dt;
        }

   public DataTable LLenagrid_fechalimite(DateTime fe)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("llenagrid_cuentas(@fe)", c);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fe", fe);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }


        //-------aqui va modulo credito cliente-------

        public void LLenanumero_credito(Label num)
        {
            c.Close();
            int a;

            NpgsqlCommand cmd = new NpgsqlCommand("numero_credito_cliente(@nu)", c);
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

            NpgsqlCommand cmd = new NpgsqlCommand("actualiza_producto_venta", c);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("cod", cod);
            cmd.Parameters.AddWithValue("can", can);

            cmd.ExecuteNonQuery();
            c.Close();
        }
        private int existencias;
        public int existencia
        {
            get
            {
                return existencias;
            }
            set
            {
                existencias = value;
            }
        }
        public void Busca_codigo(TextBox bc, TextBox cod, TextBox pro, TextBox uni, TextBox pre, TextBox exis)
        {
            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand("busca_codigo_venta(@co) ", c);
            c.Open();
            NpgsqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@co", bc.Text);
            // cmd.Connection = c;
            dr = cmd.ExecuteReader();
            if (string.IsNullOrWhiteSpace(bc.Text))
            {
                MessageBox.Show("Error no hay codigo que buscar");
            }
            else
            {
                bool verificar = false;
                if (dr.Read())
                {
                    verificar = true;
                    cod.Text = dr.GetValue(0).ToString();
                    pro.Text = dr.GetString(1);
                    uni.Text = dr.GetString(3);
                    pre.Text = Convert.ToDecimal(dr.GetValue(4)).ToString();
                    existencia = Convert.ToInt32(dr.GetValue(2));
                    exis.Text = existencias.ToString();
                    // exi.Text = "1";
                    //  txtcan.Focus();

                }
                else if (Convert.ToUInt32(dr.GetValue(4)) <= 0)
                {
                    verificar = false;
                    MessageBox.Show("no hay existencias");
                    dr.Close();
                }

                else
                {
                    dr.Close();
                }
                dr.Close();
            }
            dr.Close();
            c.Close();
           
        }

        public void Busca_Producto( TextBox cod, TextBox pro, TextBox uni, TextBox pre, TextBox exis)
        {

            c.Close();
            NpgsqlCommand cmd = new NpgsqlCommand(" busca_producto(@n)", c);
            NpgsqlDataReader dr;
           // cmd.CommandType = CommandType.Text;
          cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddWithValue("@n", pro.Text);
            // cmd.Connection = c;
            c.Open();
            dr = cmd.ExecuteReader();
            //if (string.IsNullOrWhiteSpace(pro.Text))
            //{
            //    MessageBox.Show("Error no hay codigo que buscar");
            //}
            //else
            //{
            bool verificar = false;
                if (dr.Read())
                {

                    verificar = true;
                    cod.Text = dr.GetValue(0).ToString();
                   pro.Text = dr.GetString(1);
                    uni.Text = dr.GetString(2);
                    pre.Text = Convert.ToDecimal(dr.GetValue(3)).ToString();

                    existencia = Convert.ToInt32(dr.GetValue(4));
                    exis.Text = existencias.ToString();
                    // exi.Text = "1";
                    //   txtcan.Focus();

                }
                else if (Convert.ToUInt32(dr.GetValue(4)) <= 0)
                {
                    verificar = false;
                    MessageBox.Show("no hay existencias");
                    dr.Close();
                }

                else
                {
                dr.Close();
                }
            // }
               dr.Close();
               c.Close();
            
        }
        public bool busca_cliente(TextBox ced, TextBox n, TextBox t)
        {
            c.Close();
            using
             (var cmd = new NpgsqlCommand("busca_cliente(@ce)"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = c;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@ce", ced.Text);
                c.Open();
                NpgsqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (string.IsNullOrWhiteSpace(ced.Text))
                {
                    MessageBox.Show("Error no hay codigo que buscar");
                }
                else
                {
                    bool verificar = false;
                    if (dr.Read())
                    {

                        verificar = true;
                        ced.Text = dr.GetValue(0).ToString();
                        n.Text = dr.GetString(1);
                        t.Text = dr.GetValue(2).ToString();
                    }
                    else
                    {
                        verificar = false;
                        dr.Close();
                        c.Close();
                    }
                   // dr.Close();
                }
                dr.Close();
                c.Close();
                
            }
            return true;
        }
        public bool guardar_ventas(int num, long cod, string nom, string med, decimal pre, int can, DateTime fec,DateTime fecl, DateTime hor, long ced, string nom_cli, long tel,  decimal sub, decimal tot, decimal cob, decimal dev)
        {
            c.Close();

            using
                (var cmd = new NpgsqlCommand("guardar_credito_cliente(@nu,@codig,@nombr,@medi,@prec,@canti,@fech,@fecli,@hora,@cedu,@n,@tele,@de,@subt,@to,@cobr,@sti,@esta,@devv)")
 )
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nu", num);
                cmd.Parameters.AddWithValue("@codig", cod);
                cmd.Parameters.AddWithValue("@nombr", nom);
                cmd.Parameters.AddWithValue("@medi", med);
                cmd.Parameters.AddWithValue("@prec", pre);
                cmd.Parameters.AddWithValue("@canti", can);
                cmd.Parameters.AddWithValue("@fech", fec);
                cmd.Parameters.AddWithValue("@fecli", fecl);
                cmd.Parameters.AddWithValue("@hora", hor);
                cmd.Parameters.AddWithValue("@cedu", ced);
                cmd.Parameters.AddWithValue("@n", nom_cli);
                cmd.Parameters.AddWithValue("@tele", tel);
                cmd.Parameters.AddWithValue("@de", 0);

                cmd.Parameters.AddWithValue("@subt", sub);
                cmd.Parameters.AddWithValue("@to", tot);
                cmd.Parameters.AddWithValue("@cobr", cob);
                cmd.Parameters.AddWithValue("@sti", 1);
                cmd.Parameters.AddWithValue("@esta", "ACTIVO");
                cmd.Parameters.AddWithValue("@devv", dev);
                cmd.ExecuteNonQuery();
                c.Close();
            }
            return true;
        }
        public bool Elimina_Credito(int num)
        {

            c.Close();

            using
                (var cmd = new NpgsqlCommand("delete_credito(@nu)"))
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@nu", num);
                cmd.ExecuteNonQuery();
                c.Close();

            }

                return true;
        }
        }
}

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
    public class proceso_venta: proceso_proveedor
    {
        AutoCompleteStringCollection Source = new AutoCompleteStringCollection();
        NpgsqlConnection c = conecta.getcn();
        //public void guarda_venta(Label num, long cod, string nom, string med, decimal pre, int can, DateTime fec, DateTime hor, long ced, string nom_cli, long tel, decimal des, decimal sub, decimal tot, decimal cob, decimal dev)
        //{
        //    c.Close();
        //    if (c.State == ConnectionState.Closed)
        //    {
        //        c.Open();
        //    }
           

        //    NpgsqlCommand cmd = new NpgsqlCommand("guarda_venta", c);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.Clear();

        //    cmd.Parameters.AddWithValue("num", num.Text);
        //    cmd.Parameters.AddWithValue("cod_pro", cod);
        //    cmd.Parameters.AddWithValue("nom", nom);
        //    cmd.Parameters.AddWithValue("med", med);
        //    cmd.Parameters.AddWithValue("pre", pre);
        //    cmd.Parameters.AddWithValue("can", can);
        //    cmd.Parameters.AddWithValue("fec", fec);
        //    cmd.Parameters.AddWithValue("hor", hor);
        //    cmd.Parameters.AddWithValue("ced_cli", ced);
        //    cmd.Parameters.AddWithValue("nom_cli", nom_cli);
        //    cmd.Parameters.AddWithValue("tel", tel);
        //    cmd.Parameters.AddWithValue("des", des);
        //    cmd.Parameters.AddWithValue("sub", sub);
        //    cmd.Parameters.AddWithValue("tot", tot);
        //    cmd.Parameters.AddWithValue("cob", cob);
        //    cmd.Parameters.AddWithValue("dev", dev);
        //    cmd.ExecuteNonQuery();

        //   // MessageBox.Show("Venta Guardada Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    c.Close();
        //}
        public void Completa(TextBox t)
        {
            autocompleta(t);
        }

        public bool guardar_ventas(int num, long cod, string nom, string med, decimal pre, int can, DateTime fec, DateTime hor, long ced, string nom_cli, long tel, decimal des, decimal sub, decimal tot, decimal cob, decimal dev)
        {
            c.Close();
           
            using
                (var cmd = new NpgsqlCommand("guarda_venta(@nu,@codigo_pro,@nombre_pro,@med,@prec,@cantidad,@fecha,@hora,@cedula,@nombre,@telefono,@desc,@sub,@tot,@cob,@dev)")
 )
            {
                if (c.State == ConnectionState.Closed)
                {
                    c.Open();
                }
                cmd.Connection = c;
                cmd.CommandType = CommandType.StoredProcedure;
          //  cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@nu", num);
            cmd.Parameters.AddWithValue("@codigo_pro", cod);
            cmd.Parameters.AddWithValue("@nombre_pro", nom);
            cmd.Parameters.AddWithValue("@med", med);
            cmd.Parameters.AddWithValue("@prec", pre);
            cmd.Parameters.AddWithValue("@cantidad", can);
            cmd.Parameters.AddWithValue("@fecha", fec);
            cmd.Parameters.AddWithValue("@hora", hor);
            cmd.Parameters.AddWithValue("@cedula", ced);
            cmd.Parameters.AddWithValue("@nombre", nom_cli);
            cmd.Parameters.AddWithValue("@telefono", tel);
            cmd.Parameters.AddWithValue("@desc", des);
            cmd.Parameters.AddWithValue("@sub", sub);
            cmd.Parameters.AddWithValue("@tot", tot);
            cmd.Parameters.AddWithValue("@cob", cob);
            cmd.Parameters.AddWithValue("@dev", dev);

                cmd.ExecuteNonQuery();

           
            c.Close();
            }
            return true;
        }

            public void numero_factura(Label num)
        {
            c.Close();
            int a;
         
            NpgsqlCommand cmd = new NpgsqlCommand("numero_ventaincremento(@nu)", c);
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

        public void nuevo(Label num)
        {
            c.Close();
            int a;
          //  string sql = "numero_ventaincremento(@nu)";
            NpgsqlCommand cmd = new NpgsqlCommand("numero_ventaincremento(@nu)", c);
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
                    num.Text = (a ).ToString();
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

        public void Busca_codigo(TextBox bc ,TextBox cod,TextBox pro,TextBox uni,TextBox pre,TextBox exis,TextBox ca)
        {
            c.Close();
           NpgsqlCommand cmd = new NpgsqlCommand("busca_codigo_venta(@co) ",c);
           NpgsqlDataReader dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@co", bc.Text);
            // cmd.Connection = c;
            c.Open();
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
                cod.Text  = dr.GetValue(0).ToString() ;
                    pro.Text = dr.GetString(1);
                    uni.Text = dr.GetString(3);
                    pre.Text = Convert.ToDecimal(dr.GetValue(4)).ToString();

                 existencia   = Convert.ToInt32(dr.GetValue(2));
                   exis.Text = existencias.ToString();
                    //  ca.Text = 1.ToString();
                  ca.Focus();

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

public bool busca_cliente(TextBox ced,TextBox n,TextBox t)
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

                   
                }
                dr.Close();
                c.Close();
               


            }
            return true;

        }



    }
}

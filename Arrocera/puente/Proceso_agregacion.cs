using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using puente;

namespace puente
{
  public  class Proceso_agregacion: proceso_proveedor
    {
        AutoCompleteStringCollection Source = new AutoCompleteStringCollection();
        NpgsqlConnection c = conecta.getcn();
        proceso_proveedor pp = new proceso_proveedor();
        public void LLenanumero(Label num)
        {
            c.Close();
            int a;

            NpgsqlCommand cmd = new NpgsqlCommand("numero_agregacion(@nu)", c);
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
        public void Autocompletar(TextBox t)
        {
            autocompleta(t);
        }


        public bool Validate_producto(int nu, long co)
        {
            c.Close();
            using
                            (var cmd = new NpgsqlCommand("validar_credito_producto(@n,@codi)"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = c;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@n", nu);
                cmd.Parameters.AddWithValue("@codi", co);

                c.Open();
                NpgsqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (string.IsNullOrWhiteSpace(nu.ToString()))
                {
                    MessageBox.Show("Error no hay codigo que buscar");
                }
                else
                {
                    bool verificar = false;
                    if (dr.Read())
                    {
                        if (dr.HasRows)
                        {


                            verificar = true;
                            nu = Convert.ToInt16(dr.GetValue(0).ToString());
                            co = Convert.ToInt64(dr.GetValue(1).ToString());
                            // t.Text = dr.GetValue(2).ToString();
                        }
                    }
                    else
                    {
                        verificar = false;
                        dr.Close();
                        c.Close();
                    }
                    dr.Close();
                }
                c.Close();
                dr.Close();
            }
            return true;
        }

        public bool Actualiza_agregacion_producto(int nu,long codi,int can,decimal st,decimal t)
        {
                c.Close();
                using
               (var cmd = new NpgsqlCommand("actualiza_credito_agregacion3(@n,@codi,@cant,@su,@t,@r)"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = c;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@n", nu);
                    cmd.Parameters.AddWithValue("@codi", codi);
                   cmd.Parameters.AddWithValue("@cant", can);
                cmd.Parameters.AddWithValue("@su", st);
                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@r", st);
                c.Open();
                cmd.ExecuteNonQuery();
                c.Close();
                }
                    return true;
           
                }
            

        public bool guarda_agregacion(int nug,long coag,string nomag,string meg,decimal preag,int cag,DateTime fg,DateTime hg,long cedg,string nocg,decimal sutg,decimal totg,int numc)
        {
            c.Close();
            using 
                (var cmd = new NpgsqlCommand("guardar_agregacion(@ng,@coa,@noma,@meda,@prea,@cana,@feca,@hor,@cea,@nom,@tele,@desc,@subt,@tota,@std,@nc)"))
                {
                cmd.CommandType = CommandType.StoredProcedure;

                c.Open();
                cmd.Connection = c;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@ng", nug);
                cmd.Parameters.AddWithValue("@coa", coag);
                cmd.Parameters.AddWithValue("@noma", nomag);
                cmd.Parameters.AddWithValue("@meda", meg);
                cmd.Parameters.AddWithValue("@prea", preag);
                cmd.Parameters.AddWithValue("@cana", cag);
                cmd.Parameters.AddWithValue("@feca", fg);
                cmd.Parameters.AddWithValue("@hor", hg);
                cmd.Parameters.AddWithValue("@cea", cedg);
                cmd.Parameters.AddWithValue("@nom", nocg);
                cmd.Parameters.AddWithValue("@tele", 3210000);
                cmd.Parameters.AddWithValue("@desc", 0);
                cmd.Parameters.AddWithValue("@subt", sutg);
                cmd.Parameters.AddWithValue("@tota", totg);
                cmd.Parameters.AddWithValue("@std", 1);
                cmd.Parameters.AddWithValue("@nc", numc);

              
                cmd.ExecuteNonQuery();
              //ssageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.Close();
            }

           


            return true;
           
        }
        public bool Guarda_mas_credito(int nug, long coag, string nomag, string meg, decimal preag, int cag, DateTime fg, DateTime hg, long cedg, string nocg, decimal sutg, decimal totg)
        {
            c.Close();
            using
                (var cmd = new NpgsqlCommand("agregar_pro_mas(@ng,@coa,@noma,@meda,@prea,@cana,@feca,@hor,@cea,@nom,@desc,@subt,@tota,@s,@std)"))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                c.Open();
                cmd.Connection = c;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@ng", nug);
                cmd.Parameters.AddWithValue("@coa", coag);
                cmd.Parameters.AddWithValue("@noma", nomag);
                cmd.Parameters.AddWithValue("@meda", meg);
                cmd.Parameters.AddWithValue("@prea", preag);
                cmd.Parameters.AddWithValue("@cana", cag);
                cmd.Parameters.AddWithValue("@feca", fg);
                cmd.Parameters.AddWithValue("@hor", hg);
                cmd.Parameters.AddWithValue("@cea", cedg);
                cmd.Parameters.AddWithValue("@nom", nocg);
             //cmd.Parameters.AddWithValue("@tele", 3210000);
                cmd.Parameters.AddWithValue("@desc", 0);
                cmd.Parameters.AddWithValue("@subt", sutg);
                cmd.Parameters.AddWithValue("@tota", totg);
               // cmd.Parameters.AddWithValue("@cob", cob);
                cmd.Parameters.AddWithValue("@s",1);
                cmd.Parameters.AddWithValue("@std", "ACTIVO");
               // cmd.Parameters.AddWithValue("@res", res);


                cmd.ExecuteNonQuery();
                //MessageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                c.Close();
            }




            return true;

        }




        //----para actulizar la existencia en inventario---------

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
                    cod.Text = dr.GetValue(0).ToString();
                    pro.Text = dr.GetString(1);
                    uni.Text = dr.GetString(3);
                    pre.Text = Convert.ToDecimal(dr.GetValue(4)).ToString();
                    existencia = Convert.ToInt32(dr.GetValue(2));
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
                dr.Close();
            }
            c.Close();
            dr.Close();
        }

        public bool Buscar_credito(TextBox n, TextBox ced, TextBox t)
        {
            c.Close();
            using
             (var cmd = new NpgsqlCommand("select numero_credito,cedula_clientes,nombres from credito_cliente where numero_credito= '" + n.Text + "' "))
            {
               // cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = c;
                cmd.Parameters.Clear();
               // cmd.Parameters.AddWithValue("@ce", ced.Text);
                c.Open();
                NpgsqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (string.IsNullOrWhiteSpace(n.Text))
                {
                    MessageBox.Show("Error no hay Numero que buscar");
                }
                else
                {
                    bool verificar = false;
                    if (dr.Read())
                    {

                        verificar = true;
                        ced.Text = dr.GetValue(1).ToString();
                       // n.Text = dr.GetString(0);
                        t.Text = dr.GetValue(2).ToString();
                    }
                    else
                    {
                        verificar = false;
                        dr.Close();
                        c.Close();
                    }
                    dr.Close();
                }
                c.Close();
                dr.Close();
            }
            return true;
        }
        public DataTable llenadetalle(int num)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from credito_cliente where numero_credito='" + num + "'",c);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        public DataTable llenadetallecredito(int num)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select * from agregar_producto_credito where numero_venta='" + num + "'", c);
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
    }
}

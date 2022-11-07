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
  public  class Proceso_movimiento
    {
        NpgsqlConnection c = conecta.getcn();

        public void llenalabelservicio(Label l, DateTime d)
        {
          //  c.Close();
            if (c.State == ConnectionState.Closed)
            {
                c.Open();
            }

            String sql;
          NpgsqlCommand cmd = new NpgsqlCommand();
         NpgsqlDataReader dr;
            sql = "buscar2(@fec)" ;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = c;
            cmd.CommandText = sql;
         
            cmd.Parameters.AddWithValue("@fec", d.ToShortDateString());
           // c.Open();
          

            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        l.Text = dr.GetValue(0).ToString();
                      //  c.Close();
                    }
                    else
                    {
                        //l.Text = "0";
                    }

                }


            }
          //  dr.Close();
         c.Close();
        }

public void Llena_gastos(Label la, DateTime da)

        {
           // c.Close();
            String sql;
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlDataReader dr;
            sql = "buscar_gastos(@fech )";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = c;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@fech", da.ToShortDateString());
            c.Open();


            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        la.Text = dr.GetValue(0).ToString();
                       // c.Close();
                    }
                    else
                    {

                    }

                }


            }
          //  dr.Close();
           c.Close();
        }
        public void Llena_compra(Label lab, DateTime dat)
        {
           // c.Close();
            String sql;
            NpgsqlCommand cmd = new NpgsqlCommand();
            NpgsqlDataReader dr;
            sql = "buscar_compra(@fech)";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Connection = c;
            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@fech", dat.ToShortDateString());
            c.Open();


            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        lab.Text = dr.GetValue(0).ToString();
                       // c.Close();
                    }
                    else
                    {

                    }

                }


            }
          //  dr.Close();
           c.Close();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;

using System.Windows.Forms.ComponentModel;
using System.IO;
using System.Drawing.Printing;
using System.Drawing;
using relacion.cache;

namespace puente
{
  public  class Proceso_reporte_venta
    {
     relacion.cache.LLama_reporte r = new relacion.cache.LLama_reporte();
        
        NpgsqlConnection c = conecta.getcn();
        public void llenaticket(DateTime num)
        {
            c.Close();
         //   int nu; long co; string pro; decimal pre; int can;  decimal des; decimal sub; decimal to;
            using
        (var sql = new NpgsqlCommand("reporte_ventas(@fe)"))

            {

                sql.CommandType = CommandType.StoredProcedure;
                sql.Connection = c;
                c.Open();
                sql.Parameters.Clear();
                sql.Parameters.AddWithValue("@fe", num.ToShortDateString());
                //  sql.Parameters.AddWithValue("@co", co);
               // NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql,c);
                NpgsqlDataReader dr;
                dr = sql.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
             LLama_reporte.Numero_factura    = Convert.ToInt16(dr.GetValue(0));
                        LLama_reporte.Codigo_producto = Convert.ToInt64(dr.GetValue(1));
                        LLama_reporte.Nombre_producto = dr.GetString(2);
                       LLama_reporte.precio = Convert.ToDecimal(dr.GetValue(3));
                       LLama_reporte.Cantidad_venta = Convert.ToInt16(dr.GetValue(4));
                        LLama_reporte.Fecha = Convert.ToDateTime(dr.GetValue(5).ToString());
                       LLama_reporte.Descuento = Convert.ToDecimal(dr.GetValue(6));
                        LLama_reporte.Subtotal = Convert.ToDecimal(dr.GetValue(7));
                       LLama_reporte.Total = Convert.ToDecimal(dr.GetValue(8));


                    }
                }
                else
                {

                }
                dr.Close();
                c.Close();



                try
                {


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    c.Close();
                }


              //  return true;
               
               

            }
            
        }
       
    }
}

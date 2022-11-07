using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace relacion.Reportes_Varios
{
   internal static class Reports
    {
        internal static DsReportes Todo(DateTime f)
        {
            DsReportes dsReportes = new DsReportes();
            using (NpgsqlConnection con = new NpgsqlConnection("server = localhost; user id = andremar; port = 5432; database = arrocera; password = andrelo31"))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("reporte_ventas(@fe)", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fe", f.ToShortDateString());

                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
                adp.Fill(dsReportes, "Ventas_diariasss");





            }


               return dsReportes;
        }
       


    }
}

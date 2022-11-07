using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace relacion.Reportes_Varios
{
   internal static class Report_dosFechas
    {
        internal static DsReportes Todo(DateTime f,DateTime fe)
        {
            DsReportes dsReportes = new DsReportes();
            using (NpgsqlConnection con = new NpgsqlConnection("server = localhost; user id = andremar; port = 5432; database = arrocera; password = andrelo31"))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("report_ventas_ganancias_fechas(@fec,@fe)", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fec", f.ToShortDateString());
                cmd.Parameters.AddWithValue("@fe", fe.ToShortDateString());
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
                adp.Fill(dsReportes, "ventas_ganancias");

            }


            return dsReportes;
        }



    }
}

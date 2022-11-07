using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace relacion.Reportes_Varios
{
  internal static  class Reporte_entre_fechas
    {
        internal static DsReportes Todo(DateTime f)
        {
            DsReportes dsReportes = new DsReportes();
            using (NpgsqlConnection con = new NpgsqlConnection("server = localhost; user id = andremar; port = 5432; database = arrocera; password = andrelo31"))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("report_ventas_ganancias(@fec)", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fec", f.ToShortDateString());

                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(cmd);
                adp.Fill(dsReportes, "ventas_ganancias");





            }


            return dsReportes;
        }

    }
}

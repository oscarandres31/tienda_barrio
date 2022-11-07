using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relacion.Reportes_Varios
{
   public static class Puente_ganancias
    {
        public static RptVentas_ganancias rpt(DateTime date)
        {
            DateTime f = new DateTime();
           RptVentas_ganancias obrp = new RptVentas_ganancias();
            DsReportes r = Reporte_entre_fechas.Todo(date);
            obrp.SetDataSource(r);



            return obrp;
        }






    }
}

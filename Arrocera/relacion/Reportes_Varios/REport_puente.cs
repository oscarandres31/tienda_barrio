using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relacion.Reportes_Varios
{
  public static class REport_puente
    {
        public static RptVentas_diarias rpt(DateTime date )
        {
            DateTime f = new DateTime();
            RptVentas_diarias obrp = new RptVentas_diarias();
            DsReportes r = Reports.Todo(date );
            obrp.SetDataSource(r);



            return obrp;
        }


    }
}

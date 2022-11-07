using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relacion.Reportes_Varios
{
   public static class Puente_dosfechas
    {
        public static RptGanancias_Entre_fechas rpt(DateTime date,DateTime fec)
        {
            DateTime f = new DateTime();
            RptGanancias_Entre_fechas obrp = new RptGanancias_Entre_fechas();
            DsReportes r = Report_dosFechas.Todo(date,fec);
            obrp.SetDataSource(r);



            return obrp;
        }


    }
}

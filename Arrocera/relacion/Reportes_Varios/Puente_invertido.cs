using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace relacion.Reportes_Varios
{
  public static  class Puente_invertido
    {

        public static Rptinventario rpt()
        {
            DateTime f = new DateTime();
           Rptinventario obrp = new Rptinventario();
            DsReportes r = Reporte_inventario.Todo();
            obrp.SetDataSource(r);



            return obrp;
        }

    }
}

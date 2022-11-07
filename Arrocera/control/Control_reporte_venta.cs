using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;

namespace control
{
  public  class Control_reporte_venta
    {
        Proceso_reporte_venta pv = new Proceso_reporte_venta();
        public void llenaticket(DateTime d)
        {

             pv.llenaticket(d);
        }
        }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puente;

namespace control
{
  public  class Control_cierre
    {
        Proceso_cierre pc = new Proceso_cierre();
        public void cierre(int num, decimal mon, DateTime fec, DateTime hor, string rea)
        {
            pc.cierre(num,mon,fec,hor,rea);

        }

        public DataTable llenagrid()
        {

         return   pc.llenagrid();

        }
        public void numero_factura(TextBox num)
        {
            pc.numero_factura(num);

        }


        public DataTable llenagrid_detalle(DateTime f)
        {
            return pc.llenagrid_detalle(f);
        }
        }
    }

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
   public class Control_apertura
    {
        proceso_apertura pa = new proceso_apertura();
        public bool Abrir(int num, decimal mon, DateTime fec, DateTime hor, string rea)
        {

            return pa.Abrir(num,mon,fec,hor,rea);
        }

        public DataTable llenagrid()
        {
            return pa.llenagrid();
        }
        public void Numero_apertura(TextBox num)
        {
            pa.Numero_apertura(num);

        }
        public DataTable llenagrid_detalle(DateTime f)
        {
            return pa.llenagrid_detalle(f);
        }
        }
}

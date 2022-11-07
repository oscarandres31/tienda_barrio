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
  public  class Control_gasto
    {

        Proceso_gasto pg = new Proceso_gasto();
        public bool Trae_gasto(int num, string raz, decimal gas, DateTime fec, DateTime hor, string autor)
        {
            return pg.Trae_gasto(num,raz,gas,fec,hor,autor);
        }

        public DataTable llenagrid()
        {
            return pg.llenagrid();
        }
        public DataTable Llenagrid_detallgasto(DateTime nu)
        {
            return pg.Llenagrid_detallgasto(nu.Date);
        }
        public DataTable Llenagrid_detallgasto_num(int nu)
        {
            return pg.Llenagrid_detallgasto_num(nu);
        }
        public void Numero_gasto(TextBox num)
        {
            pg.Numero_gasto(num);

        }
        }
}

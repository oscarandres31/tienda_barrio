using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puente;

namespace control
{
  public  class Control_movimiento
    {

        Proceso_movimiento pm = new Proceso_movimiento();
        public void llenalabelservicio(Label l, DateTime d)
        {
            pm.llenalabelservicio(l,d);
        }

        public void Llena_compra(Label la, DateTime da)
        {
            pm.Llena_compra(la,da);


        }

        public void Llena_gastos(Label lab, DateTime dat)

        {
            pm.Llena_gastos(lab,dat);
        }
        }
    }

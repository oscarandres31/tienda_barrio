using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;
using System.Data;
using System.Windows.Forms;

namespace control
{
   public class control_producto
    {
        proceso_producto p = new proceso_producto();

        public DataTable llenagridproducto()
        {
            return p.llenagridproducto();
        }

        public DataTable llenagridproducto2(long cod)
        {
            return p.llenagridproducto2(cod);
        }

            public void guarda_producto(long cod, string des, string ti, int can, string uni, decimal pre_com, decimal pre_ven, string prov)
        {
            p.guarda_producto(cod, des, ti, can, uni, pre_com, pre_ven, prov);
        }

        public void actualiza_producto(long cod, string des, string ti, int can, string uni, decimal pre_com, decimal pre_ven, string prov)
        {
            p.actualiza_producto(cod, des, ti, can, uni, pre_com, pre_ven, prov);

        }

        public void elimina_producto(long cod)
        {
            p.elimina_producto(cod);


        }

        public void llenacombo(ComboBox cm)
        {
            p.llenacombo(cm);

        }
        }
}

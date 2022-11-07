using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;
using System.Windows.Forms;

namespace control
{

    
    public class control_venta
    {
        proceso_venta pv = new proceso_venta();

        public void guarda_venta(Label num,long cod,string nom, string med, decimal pre, int can, DateTime fec, DateTime hor, long ced, string nom_cli, long tel, decimal des, decimal sub, decimal tot, decimal cob, decimal dev)
        {
           // pv.guarda_venta(num,cod,nom,med,pre,can,fec,hor,ced,nom_cli,tel,des,sub,tot,cob,dev);

        }

        public bool guardar_ventas(int num, long cod, string nom, string med, decimal pre, int can, DateTime fec, DateTime hor, long ced, string nom_cli, long tel, decimal des, decimal sub, decimal tot, decimal cob, decimal dev)
        {
          return  pv.guardar_ventas(num, cod, nom, med, pre, can, fec, hor, ced, nom_cli, tel, des, sub, tot, cob, dev);

        }



            public void numero_factura(Label num)
        {
            pv.numero_factura(num);

        }

        public void actualiza_producto(long cod, int can)
        {
            pv.actualiza_producto(cod, can);

            }


        public void Busca_codigo(TextBox bc,TextBox cod, TextBox pro, TextBox uni, TextBox pre, TextBox exis,TextBox ca)
        {
            pv.Busca_codigo(bc,cod, pro, uni, pre, exis,ca);

        }

        //public int existencia()
        //{

        //}
        public bool busca_cliente(TextBox ced, TextBox n, TextBox t)
        {
            return pv.busca_cliente(ced, n, t);

        }

        public void Auto(TextBox t)
        {
            pv.Completa(t);
        }
        }
}

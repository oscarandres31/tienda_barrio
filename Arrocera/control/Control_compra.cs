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
   public class Control_compra
    {
        Proceso_compra pc = new Proceso_compra();
        public bool Guarda_compra(int nu, long co, string pro, string me, decimal pre, int can, DateTime fec, DateTime ho, long ced, string cli, decimal des, decimal sub, decimal to, decimal pag, decimal dev)
        {
            return pc.Guarda_compra(nu,co,pro,me,pre,can,fec,ho,ced,cli,des,sub,to,pag,dev);
        }


        public void numero_factura(Label num)
        {
            pc.numero_factura(num);

        }

        public void Busca_codigo(TextBox bc, TextBox cod, TextBox pro, TextBox uni, TextBox pre,TextBox ca)
        {
            pc.Busca_codigo(bc,cod,pro,uni,pre,ca);


        }
        public void actualiza_producto(long cod, int can)
        {
            pc.actualiza_producto(cod,can);
        }

        public DataTable Llenagrid_detallecompra(int nu)
        {
            return pc.Llenagrid_detallecompra(nu);


        }

        public void Busca_Proveedor(TextBox cod, TextBox bc)
        {
            pc.Busca_Proveedor(cod, bc);

        }
        }
    }

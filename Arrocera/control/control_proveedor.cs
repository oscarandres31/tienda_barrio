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
  public  class control_proveedor
    {

        proceso_proveedor pp = new proceso_proveedor();
        public DataTable llenagridproveedor()
        {

            return pp.llenagridproveedor();
        }
        public void guarda_proveedor(string nom,long ced,string emp,string prod,long tel,decimal pre)
        {
            pp.guarda_proveedor(nom, ced, emp, prod, tel, pre);

        }


        public void actualiza_proveedor(string nom,long ced,string emp,string prod,long tel,decimal pre)
        {
            pp.actualiza_proveedor(nom,ced,emp,prod,tel,pre);

        }
        public void delete_proveedor(long ced)
        {
            pp.delete_proveedor(ced);
        }
        public void autocompleta(TextBox textbo)
        {
            pp.autocompleta(textbo);

        }
        public bool Buscar_proveedor(long co,string nom, long ced, string em, string pro, long tel, decimal real)
        {
            return pp.Buscar_proveedor(co,nom,ced,em,pro,tel,real);
        }

        public DataTable llenagridproveedor_cedula(long co)
        {
            return pp.llenagridproveedor_cedula(co);
        }
        }
    }

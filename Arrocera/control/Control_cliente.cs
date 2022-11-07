using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;

namespace control
{
  public  class Control_cliente
    {

    Proceso_cliente cc = new Proceso_cliente();
        public bool Guarda_cliente(string n, long ce, long t, string d)
        {
            return cc.Guarda_cliente(n, ce, t, d);

        }
        public bool Guarda_cliente2(string n, long ce, long t, string d)
        {
            return cc.Guarda_cliente2(n, ce, t, d);
        }
            public DataTable Llenagrid_comprasclientes(long nu)
        {
            return cc.Llenagrid_comprasclientes(nu);
        }
            public DataTable Llenagrid_clientes(long nu)
        {
            return cc.Llenagrid_clientes(nu);

        }
        public bool Delete_cliente(long ce)
        {
            return cc.Delete_cliente(ce);

        }

        public DataTable Data_clientes()
        {
            return cc.Data_clientes();
        }
        public bool Update_cliente(string n, long ce, long t, string d)
        {
            return cc.Update_cliente(n,ce,t,d);
        }

        }
}

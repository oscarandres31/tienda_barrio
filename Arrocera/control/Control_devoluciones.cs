using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using puente;

namespace control
{
   public class Control_devoluciones
    {
        Proceso_devoluciones pd = new Proceso_devoluciones();
        public DataTable Llenagri_devolucion(int nu)
        {
            return pd.Llenagri_devolucion(nu);

        }
        public DataTable llenagrid_fecha(DateTime da)
        {
            return pd.llenagrid_fecha(da);
        }

        public bool Guarda_devolucion(long co, int ca, string rea, string obs, decimal pre, decimal sub)
        {
            return pd.Guarda_devolucion(co,ca,rea,obs,pre,sub);
        }

        public void actualiza_producto(long cod, int can)
        {
            pd.actualiza_producto(cod, can);

        }
        public DataTable llenagrid_detalle(long co)
        {
            return pd.llenagrid_detalle(co);

        }

        public bool Eliminar_factura(int num)
        {

            return pd.Eliminar_factura(num);
        }
        public void Actualiza_producto_factura(long cod, int can)
        {
            pd.Actualiza_producto_factura(cod,can);
        }
        }
    }

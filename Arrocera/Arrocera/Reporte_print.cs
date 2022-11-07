using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrocera.Model
{
   public class Reporte_print
    {

        public static int Numero_factura { get; set; }
        public static long Codigo_producto { get; set; }
        public static string Nombre_producto { get; set; }
        public static decimal precio { get; set; }
        public static int Cantidad_venta { get; set; }
        public static decimal Descuento { get; set; }
        public static DateTime Fecha { get; set; }
        public static decimal Subtotal { get; set; }
        public static decimal Total { get; set; }



    }
}

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
  public  class Control_credito
    {
        Proceso_credito pc = new Proceso_credito();
        public void LLenanumero(Label num)
        {
            pc.LLenanumero(num);

        }
        public bool guardar_ventas(int num, decimal pag, int cre, DateTime fec)
        {
            return pc.guardar_ventas(num, pag, cre, fec);
        }

        public DataTable llenagridpago(long num)
        {
            return pc.llenagridpago(num);
        }

        public bool Actualiza_credito(int num,decimal cor)
        {
            return pc.Actualiza_credito(num,cor);

        }
        public DataTable LLenagrid_fechalimite(DateTime fe)
        {
            return pc.LLenagrid_fechalimite(fe);
        }

        //Aqui van los controles de credito cliente
      

        public void LLenanumero_credito(Label num)
        {
            pc.LLenanumero_credito(num);

        }

        public void actualiza_producto(long cod, int can)
        {
            pc.actualiza_producto(cod, can);
        }

        public void Busca_codigo(TextBox bc, TextBox cod, TextBox pro, TextBox uni, TextBox pre, TextBox exis)
        {
            pc.Busca_codigo(bc, cod, pro, uni, pre, exis);
        }
        public bool busca_cliente(TextBox ced, TextBox n, TextBox t)
        {
            return pc.busca_cliente(ced, n,t);
        }
        public bool guardar_ventas(int num, long cod, string nom, string med, decimal pre, int can, DateTime fec, DateTime fecl, DateTime hor, long ced, string nom_cli, long tel, decimal sub, decimal tot, decimal cob,  decimal dev)
        {
            return pc.guardar_ventas(num, cod, nom, med, pre, can, fec, fecl, hor, ced, nom_cli, tel, sub, tot, cob,  dev);
        }


        public bool Elimina_Credito(int num)
        {
            return pc.Elimina_Credito(num);
        }

        public void Autocompleta(TextBox t)
        {
            pc.Autocompleta(t);
        }

        public void Busca_Producto(TextBox cod, TextBox pro, TextBox uni, TextBox pre, TextBox exis)
        {
            pc.Busca_Producto(cod, pro, uni, pre, exis);

        }
        }
    }

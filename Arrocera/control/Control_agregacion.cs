using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using puente;
using System.Data;

namespace control
{
   public class Control_agregacion
    {
       //Control_agregacion ca = new Control_agregacion();
        Proceso_agregacion ca = new Proceso_agregacion();

        public void LLenanumero(Label num)
        {
            ca.LLenanumero(num);
        }
            public bool Validate_producto(int nu, long co)
        {
            return ca.Validate_producto(nu, co);

        }


            public bool guarda_agregacion(int nug, long coag, string nomag, string meg, decimal preag, int cag, DateTime fg, DateTime hg, long cedg, string nocg, decimal sutg, decimal totg, int numc)
        {
            return ca.guarda_agregacion(nug, coag, nomag, meg, preag, cag, fg, hg, cedg, nocg, sutg, totg,  numc);
        }

            public bool Actualiza_agregacion_producto(int nu, long codi, int can,decimal st,decimal t)
        {
            return ca.Actualiza_agregacion_producto(nu,codi,can,st,t);
        }

        public void actualiza_producto(long cod, int can)
        {
            ca.actualiza_producto(cod, can);
        }

            public void Busca_codigo(TextBox bc, TextBox cod, TextBox pro, TextBox uni, TextBox pre, TextBox exis)
        {
          ca.Busca_codigo(bc, cod, pro, uni, pre, exis);
        }


        public bool Buscar_credito(TextBox n, TextBox ced, TextBox t)
        {
            return ca.Buscar_credito(n,ced, t);
        }


        public DataTable llenadetalle(int num)
        {
            return ca.llenadetalle(num);
        }

        public bool Guarda_mas_credito(int nug, long coag, string nomag, string meg, decimal preag, int cag, DateTime fg, DateTime hg, long cedg, string nocg, decimal sutg, decimal totg)
        {
            return ca.Guarda_mas_credito(nug, coag, nomag, meg, preag, cag, fg, hg, cedg, nocg, sutg, totg);
        }



        public void Autocompletar(TextBox t)
        {
            ca.Autocompletar(t);
        }
        public DataTable llenadetallecredito(int num)
        {
            return ca.llenadetallecredito(num);
        }
        }

    }

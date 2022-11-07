using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using control;
using relacion;

namespace Arrocera
{
    public partial class Nuevo_cliente : Form
    {
        private venta padre;
        Control_cliente cl = new Control_cliente();
        venta v = new venta();
        proc p = new proc();
        public Nuevo_cliente(venta ven)
        {
            InitializeComponent();

            padre = ven;
        }

       

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                cl.Guarda_cliente2(txtnom.Text,long.Parse(txtcedu.Text),long.Parse(txttelef.Text),txtdirec.Text);
                padre.txtcliente.Text = txtnom.Text;
                padre.txtcedula.Text = txtcedu.Text;
                padre.txttel.Text = txttelef.Text;
                this.Close();
                if(padre.WindowState == FormWindowState.Minimized)
                {
                    padre.WindowState = FormWindowState.Maximized;
                    padre.Visible = true;
                }
                else
                {
                    padre.WindowState = FormWindowState.Maximized;
                }



            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }

        private void Nuevo_cliente_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void txtcedu_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txttelef_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }
    }
}

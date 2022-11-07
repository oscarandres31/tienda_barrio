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
    public partial class proveedores : Form
    {
        proc p = new proc();
        control_proveedor cp = new control_proveedor();
        AutoCompleteStringCollection Source = new AutoCompleteStringCollection();


        public proveedores()
        {
            InitializeComponent();
        }

        private void proveedores_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cp.llenagridproveedor();
            cp.autocompleta(txtproducto);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            cp.guarda_proveedor( txtnombres.Text  ,long.Parse(txtcedula.Text),txtempresa.Text,txtproducto.Text,long.Parse(txttelefono.Text),decimal.Parse(txtprecio.Text));
            dataGridView1.DataSource = cp.llenagridproveedor();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            cp.actualiza_proveedor(txtnombres.Text, long.Parse(txtcedula.Text), txtempresa.Text, txtproducto.Text, long.Parse(txttelefono.Text), decimal.Parse(txtprecio.Text));
            dataGridView1.DataSource = cp.llenagridproveedor();

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            cp.delete_proveedor(long.Parse(txtcedula.Text));
            dataGridView1.DataSource = cp.llenagridproveedor();

        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //try
            //{

                       if (txtcedula.Text != "")
            {
           dataGridView1.DataSource=     cp.llenagridproveedor_cedula(long.Parse(txtcedula.Text));

               // cp.Buscar_proveedor(long.Parse(txtcedula.Text), txtnombres.Text, long.Parse(txtcedula.Text), txtempresa.Text, txtproducto.Text, long.Parse(txttelefono.Text), decimal.Parse(txtprecio.Text));
            }
            else
            {

            }
            //}catch(Exceptio
            //{
            //    MessageBox.Show(ex.Message);
            //}


            }
    }
}

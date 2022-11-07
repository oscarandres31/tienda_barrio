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
    public partial class detalle_compra : Form
    {
        proc p = new proc();
        Control_compra cc = new Control_compra();
        public detalle_compra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         dataGridView1.DataSource= cc.Llenagrid_detallecompra(int.Parse(textBox1.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }
    }
}

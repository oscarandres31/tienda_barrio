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
    public partial class detalle_devoluciones : Form
    {
        Control_devoluciones cd = new Control_devoluciones();
        proc p = new proc();
        public detalle_devoluciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cd.llenagrid_detalle(long.Parse(textBox1.Text));
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }
    }
}

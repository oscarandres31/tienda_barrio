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
    public partial class Detalle_gastos : Form
    {
        proc p = new proc();
        Control_gasto cg = new Control_gasto();
        public Detalle_gastos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         dataGridView1.DataSource= cg.Llenagrid_detallgasto(dateTimePicker1.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        dataGridView1.DataSource= cg.Llenagrid_detallgasto_num(int.Parse(textBox1.Text));
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }
    }
}

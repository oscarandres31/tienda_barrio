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

namespace Arrocera
{
    public partial class movimientos : Form
    {
        Control_movimiento cm = new Control_movimiento();

        public movimientos()
        {
            InitializeComponent();
        }

        private void movimientos_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            label7.Text = DateTime.Now.ToShortDateString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            cm.llenalabelservicio((label5),Convert.ToDateTime(label7.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cm.Llena_compra((label6), Convert.ToDateTime(label7.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cm.Llena_gastos((label1), Convert.ToDateTime(label7.Text));
        }

        private void label5_TextChanged(object sender, EventArgs e)
        {
            decimal r = Convert.ToDecimal(label5.Text);
            label5.Text = r.ToString("n");
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            decimal l = Convert.ToDecimal(label1.Text);
            label1.Text = l.ToString("n");
        }

        private void label6_TextChanged(object sender, EventArgs e)
        {
            decimal la = Convert.ToDecimal(label6.Text);
            label6.Text = la.ToString("n");
        }
    }
}

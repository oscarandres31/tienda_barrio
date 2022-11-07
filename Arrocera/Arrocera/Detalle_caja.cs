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
    public partial class Detalle_caja : Form
    {

        Control_apertura ca = new Control_apertura();
        Control_cierre cc = new Control_cierre();
        public Detalle_caja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ca.llenagrid_detalle(dateTimePicker1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           dataGridView2.DataSource = cc.llenagrid_detalle(dateTimePicker1.Value);
        }
    }
}

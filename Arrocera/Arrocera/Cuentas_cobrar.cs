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
    public partial class Cuentas_cobrar : Form
    {
        Control_credito cc = new Control_credito();
        public Cuentas_cobrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cc.LLenagrid_fechalimite(dateTimePicker1.Value.Date);
        }
    }
}

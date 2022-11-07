using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using control;

namespace Arrocera
{
    public partial class gastos : Form
    {

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrvalue, int attrsize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        Control_gasto cg = new Control_gasto();

        public gastos()
        {
            InitializeComponent();
        }

        private void gastos_Load(object sender, EventArgs e)
        {
            cg.Numero_gasto(txtnume);

            lblfecha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            dataGridView1.DataSource = cg.llenagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnume.Text == ""    )
            {
                MessageBox.Show("El campo Numero Está Vacio", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else if(txtmonto.Text == "")
            {
                MessageBox.Show("El Campo Monto Está  Vacio", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }else if(txtautor.Text == "")
            {
                MessageBox.Show("El Campo Autorizado Está  Vacio", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }else if (txtrazon.Text == "")
            {
                MessageBox.Show("El Campo Razón Está  Vacio", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }else

            {
if(MessageBox.Show(this,"DEsea Guardar EL Gasto ?","CONFIRMAR",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)+""=="OK")

                { 
            cg.Trae_gasto(int.Parse(txtnume.Text),txtrazon.Text,decimal.Parse(txtmonto.Text),DateTime.Parse(lblfecha.Text),DateTime.Parse(lblhora.Text),txtautor.Text);
            dataGridView1.DataSource = cg.llenagrid();
           // txtnume.Text = "";
            txtmonto.Text = "";
            txtrazon.Text = "";
            txtautor.Text = "";
                }
            }

        }
        private void limpiar()
        {
           // txtnume.Text = "";
            txtmonto.Text = "";
            txtrazon.Text = "";
            txtautor.Text = "";
        }

    }
}

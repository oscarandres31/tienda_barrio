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
    public partial class abrir_caja : Form
    {

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrvalue, int attrsize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }


        Control_apertura ca = new Control_apertura();
        public abrir_caja()
        {
            InitializeComponent();
        }

        private void abrir_caja_Load(object sender, EventArgs e)
        {

            ca.Numero_apertura(textBox1);
            lblfecha.Text = DateTime.Now.ToShortDateString();
            lbltiempo.Text = DateTime.Now.ToShortTimeString();
            dataGridView1.DataSource = ca.llenagrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" && textBox2.Text == ""&& textBox3.Text == "")
            {
                MessageBox.Show("Hay Campos Vacios", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

           
            if (MessageBox.Show(this,"Desea Guardar La Apertura ?","Confirmar",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) + ""=="OK")
            
            {
                Control_apertura ca = new Control_apertura();

                ca.Abrir(Convert.ToInt16(textBox1.Text), Convert.ToDecimal(textBox2.Text), DateTime.Parse(lblfecha.Text), DateTime.Parse(lbltiempo.Text), textBox3.Text);
                    dataGridView1.DataSource = ca.llenagrid();
               // textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            }

        }
    }
}

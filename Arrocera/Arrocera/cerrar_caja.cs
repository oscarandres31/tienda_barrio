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
    public partial class cerrar_caja : Form
    {

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrvalue, int attrsize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
        public cerrar_caja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Guardar El Cierre ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {


                if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                {
                    MessageBox.Show("hay espacios vacios","VERIFIQUE",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {


                    Control_cierre cc = new Control_cierre();

                    cc.cierre(Convert.ToInt16(textBox1.Text), Convert.ToDecimal(textBox2.Text), DateTime.Parse(lblfecha.Text), DateTime.Parse(lbltiempo.Text), textBox3.Text);

                    dataGridView1.DataSource = cc.llenagrid();
                  //  textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    cc.numero_factura((textBox1));
                }
            }
        }

        private void cerrar_caja_Load(object sender, EventArgs e)
        {
            Control_cierre cc = new Control_cierre();
            cc.numero_factura((textBox1));

            lblfecha.Text = DateTime.Now.ToShortDateString();
            lbltiempo.Text = DateTime.Now.ToShortTimeString();
           // Control_cierre cc = new Control_cierre();
            dataGridView1.DataSource = cc.llenagrid();


        }
    }
}

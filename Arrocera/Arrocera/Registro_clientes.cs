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
    public partial class Registro_clientes : Form
    {
        Control_cliente cl = new Control_cliente();
        proc p = new proc();
        public Registro_clientes()
        
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, " Desea Guardar ?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {
                cl.Guarda_cliente(txtnom.Text, long.Parse(txtcedu.Text), long.Parse(txttelef.Text), txtdirec.Text);
                txtcedu.Text = "";
                txtdirec.Text = "";
                txtnom.Text = "";
                txttelef.Text = "";
            }
            }

        private void txtcedu_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txttelef_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this," Desea Actualizar ?","Confirmar",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) + "" == "OK")
            {

            cl.Update_cliente(txtnom.Text, long.Parse(txtcedu.Text), long.Parse(txttelef.Text), txtdirec.Text);
                txtcedu.Text = "";
                txtdirec.Text = "";
                txtnom.Text = "";
                txttelef.Text = "";
            }
        }
    }
}

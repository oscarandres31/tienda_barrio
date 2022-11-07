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
    public partial class clientes : Form
    {
        proc p = new proc();
        Control_cliente cc = new Control_cliente();
        public clientes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text =="")
                {
                MessageBox.Show("El campo Cedula Está Vacio", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = cc.Llenagrid_clientes(long.Parse(textBox2.Text));

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "")
            {
              if (MessageBox.Show("Desea Eliminar El Cliente ?","CONFIRMAR",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) + " "=="OK")
            {
                cc.Delete_cliente(long.Parse(textBox2.Text));
                dataGridView1.DataSource = cc.Data_clientes();
                textBox2.Text = "";
            }
            else
            {
                
            }
            }
            else
            {
                dataGridView1.DataSource = cc.Data_clientes();
            }
        }

        private void clientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cc.Data_clientes();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("El campo Cedula Está Vacio", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView2.DataSource = cc.Llenagrid_comprasclientes(long.Parse(textBox2.Text));
            }
            }

        private void button4_Click(object sender, EventArgs e)
        {
            Registro_clientes rc = new Registro_clientes();
            rc.Show();
        }
        int selectedrow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedrow];
            textBox2.Text = row.Cells[0].Value.ToString();
        }
    }
}

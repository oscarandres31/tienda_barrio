using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using relacion;
using control;

namespace Arrocera
{
    public partial class producto : Form
    {
        proc p = new proc();
        control_producto cp = new control_producto();

        public producto()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if(textBox9.Text != "")
            {
                        dataGridView1.DataSource= cp.llenagridproducto2(long.Parse(textBox9.Text));
            }
            else
            {
                dataGridView1.DataSource = cp.llenagridproducto();
                textBox1.Focus();
            }
        }

        private void producto_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cp.llenagridproducto();
            cp.llenacombo(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El Campo Codigo o producto está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("El Campo cantidad o tipo está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrEmpty(textBox7.Text) )
            {
                MessageBox.Show("los ultimos Campos  están vacios ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(textBox6.Text))
            {
               MessageBox.Show("El Campo unidad está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {

                if (MessageBox.Show(this, "Desea Guardar El Producto", "confirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) + "" == "OK")
                {
                    cp.guarda_producto(long.Parse(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt16(textBox4.Text), (textBox6.Text), Convert.ToDecimal(textBox8.Text), Convert.ToDecimal(textBox7.Text), comboBox1.Text);

                    limpiar();

                    dataGridView1.DataSource = cp.llenagridproducto();
                }

            }
        }

       

        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "==SELECCIONE==";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El Campo Codigo o producto está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("El Campo cantidad o tipo está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBox8.Text) && string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("los ultimos Campos  están vacios ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("El Campo unidad está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {

                if (MessageBox.Show(this, "Desea Actualizar El Producto", "confirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) + "" == "OK")
                {
                    cp.actualiza_producto(long.Parse(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt16(textBox4.Text), (textBox6.Text), Convert.ToDecimal(textBox8.Text), Convert.ToDecimal(textBox7.Text), comboBox1.Text);
                    limpiar();

                    dataGridView1.DataSource = cp.llenagridproducto();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) )
            {
                MessageBox.Show("El Campo Codigo  está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {

          

            if (MessageBox.Show(this, " En Verdad Desea Eliminar El Producto", "confirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) + "" == "OK")
            {
                cp.elimina_producto(long.Parse(textBox1.Text));
                limpiar();

                dataGridView1.DataSource = cp.llenagridproducto();
            }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        int selectedrow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectedrow];
            textBox1.Text = row.Cells[0].Value.ToString();
                      textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox8.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
            textBox6.Text = row.Cells[4].Value.ToString();
        }
    }
}

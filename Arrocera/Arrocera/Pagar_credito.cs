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
    public partial class Pagar_credito : Form
    {
        Control_credito cc = new Control_credito();

        public Pagar_credito()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Pagar_credito_Load(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToShortDateString();
            cc.LLenanumero(label4);
        }

        private void button_nuevo1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Hay Caampos Vacios");
            }
            else
            {
                if (MessageBox.Show(this, "Desea Guardar El Pago?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
                {
                    try
                    {
                        cc.guardar_ventas(int.Parse(label4.Text), decimal.Parse(textBox3.Text), int.Parse(textBox1.Text), DateTime.Parse(label5.Text));
                        cc.Actualiza_credito(int.Parse(textBox1.Text), decimal.Parse(textBox3.Text));
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                       // dataGridView1.Rows.Clear();
                        textBox2.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

           
            if (textBox2.Text != "")
            {
            dataGridView1.DataSource =  cc.llenagridpago(long.Parse(textBox2.Text));
            }
            else
            {

            }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_nuevo1_MouseDown(object sender, MouseEventArgs e)
        {
            button_nuevo1.ButtonColor = Color.BlueViolet;
            button_nuevo1.TextColor = Color.White;
        }

        private void button_nuevo1_MouseLeave(object sender, EventArgs e)
        {
            button_nuevo1.ButtonColor = Color.CornflowerBlue;
            button_nuevo1.TextColor = Color.BlueViolet;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //decimal r;
            //foreach (DataGridViewRow itm in dataGridView1.Rows)
            //{

            //    r = Convert.ToDecimal(itm.Cells[4].Value) + Convert.ToInt32(itm.Cells[7].Value) - Convert.ToDecimal(itm.Cells[5].Value);
            //    itm.Cells[0].Value = r;

            //    if (r == 0)
            //    {
            //        itm.Cells[8].Value = "INACTIVO";

            //    }
            //    else
            //    {

            //    }

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //decimal r;
            //foreach (DataGridViewRow itm in dataGridView1.Rows)
            //{

            //    r = Convert.ToDecimal(itm.Cells[4].Value) + Convert.ToInt32(itm.Cells[7].Value) - Convert.ToDecimal(itm.Cells[5].Value);
            //    itm.Cells[0].Value = r;

            //    if (r == 0)
            //    {
            //        itm.Cells[8].Value = "INACTIVO";

            //    }
            //    else
            //    {

            //    }

            //}
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal r;
                foreach (DataGridViewRow itm in dataGridView1.Rows)
                {

                    r = Convert.ToDecimal(itm.Cells[4].Value) + Convert.ToInt32(itm.Cells[7].Value) - Convert.ToDecimal(itm.Cells[5].Value);
                    itm.Cells[0].Value = r.ToString();

                    //if (r == 0)
                    //{
                    //    itm.Cells[8].Value = "INACTIVO";

                    //}
                    //else
                    //{

                    //}

                }
            }
            catch
            {

            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal r;
                foreach (DataGridViewRow itm in dataGridView1.Rows)
                {

                    r = Convert.ToDecimal(itm.Cells[4].Value) + Convert.ToInt32(itm.Cells[7].Value) - Convert.ToDecimal(itm.Cells[5].Value);
                    itm.Cells[0].Value = r.ToString();

                    if (r == 0)
                    {
                        itm.Cells[8].Value = "INACTIVO";

                    }
                    else
                    {

                    }

                }
            }
            catch
            {

            }
        }
    }
}

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
    public partial class Detalle_credito : Form
    {
        Control_agregacion ca = new Control_agregacion();
        Control_credito cc = new Control_credito();
        public Detalle_credito()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ca.llenadetalle(Convert.ToInt16(textBox1.Text));
            dataGridView2.DataSource = ca.llenadetallecredito(Convert.ToInt16(textBox1.Text));
            costoapagar();
            costoapagar2();
        }
        private void subtotal()
        {
            try
            {
                if (textBox2.Text !="" && textBox3.Text != "")
                {
                    decimal a;

                    a = (decimal.Parse(textBox2.Text) + decimal.Parse(textBox3.Text)) - decimal.Parse(dataGridView1.Rows[0].Cells[15].Value.ToString()) ;
                   textBox4.Text = a.ToString();
                }
                else
                {

                }
            }
            catch
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Deseas Eliminar Este Credito ?", "CONFIRME", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")

            {
                cc.Elimina_Credito(int.Parse(textBox1.Text));
            }
            else
            {

            }
        }
        public void costoapagar()
        {
            decimal costototal = 0;
            int conteo = 0;

            conteo = dataGridView1.RowCount;
            for (int i = 0; i < conteo; i++)
            {
                costototal += decimal.Parse(dataGridView1.Rows[i].Cells[13].Value.ToString());
            }

          textBox2.Text = costototal.ToString();
        }
        public void costoapagar2()
        {
            decimal costototal = 0;
            int conteo = 0;

            conteo = dataGridView2.RowCount;
            for (int i = 0; i < conteo; i++)
            {
                costototal += decimal.Parse(dataGridView2.Rows[i].Cells[12].Value.ToString());
            }

            textBox3.Text = costototal.ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(textBox2.Text);
          textBox2.Text = dec.ToString("n");
            subtotal();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(textBox3.Text);
          textBox3.Text = dec.ToString("n");
            subtotal();
        }

        private void Detalle_credito_Load(object sender, EventArgs e)
        {

        }
    }
}

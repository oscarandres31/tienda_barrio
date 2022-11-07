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
    public partial class devoluciones : Form
    {
        proc p = new proc();
        Control_devoluciones cd = new Control_devoluciones();
        public devoluciones()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {

           
      dataGridView1.DataSource =  cd.Llenagri_devolucion(int.Parse(textBox1.Text));
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cd.llenagrid_fecha(DateTime.Parse(dateTimePicker1.Value.ToShortDateString()));
        }

        int selectrow;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectrow = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selectrow];
            txtcodigo.Text = row.Cells[1].Value.ToString();
            txtcantidad.Text = row.Cells[4].Value.ToString();
            txtprecio.Text = row.Cells[3].Value.ToString();
          //  txtsubtotal.Text = row.Cells[1].Value.ToString();

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {
            if(txtcantidad.Text != "")
                {
                decimal a ;
                a = int.Parse(txtcantidad.Text) * int.Parse(txtprecio.Text);
                txtsubtotal.Text = a.ToString();


            }
            else
            {

            }
        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {
            //decimal d = Convert.ToDecimal(txtprecio.Text);
            //txtprecio.Text = d.ToString("n");
        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            decimal b = Convert.ToDecimal(txtsubtotal.Text);
            txtsubtotal.Text = b.ToString("n");
        }

        private void devoluciones_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtautoriza.Text =="")
            {
                MessageBox.Show("El Campo Autorizado Está Vacio");
                txtautoriza.Focus();
            }else if(txtobserva.Text == "")
            {
                MessageBox.Show("El Campo Observaciones Está Vacio");
                txtobserva.Focus();
            }else if(txtcantidad.Text=="")
            {
                MessageBox.Show("El Campo Cantidad Está Vacio");
                txtcantidad.Focus();
            }
            else
            {

                       if (MessageBox.Show(this, "Desea Guardar La Devolucion?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {

                try
                {
                   
            dataGridView1.DataSource=  cd.Guarda_devolucion(long.Parse(txtcodigo.Text),int.Parse(txtcantidad.Text),txtautoriza.Text,txtobserva.Text,decimal.Parse(txtprecio.Text),decimal.Parse(txtsubtotal.Text));
                    cd.actualiza_producto(long.Parse(txtcodigo.Text),int.Parse(txtcantidad.Text));
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
                }
            }

     
    }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void button_nuevo1_MouseDown(object sender, MouseEventArgs e)
        {
           // button_nuevo1.ButtonColor = Color.Orange;
        }

        private void button_nuevo1_MouseHover(object sender, EventArgs e)
        {
            button_nuevo1.ButtonColor = Color.Orange;
            button_nuevo1.TextColor = Color.MidnightBlue;
            button_nuevo1.BorderColor = Color.SkyBlue;
        }

        private void button_nuevo1_MouseLeave(object sender, EventArgs e)
        {
            button_nuevo1.ButtonColor =Color.SkyBlue;
            button_nuevo1.TextColor = Color.MidnightBlue;
            button_nuevo1.BorderColor = Color.MidnightBlue;
           

        }

        private void button_nuevo1_Click(object sender, EventArgs e)
        {
            try
            {
               if(textBox1.Text == "")
                {
                    MessageBox.Show("EL Campo Numero Factura Está Vacio, Ingresa Un Numero Para Eliminar", "VERIFICA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

               
           
            if (MessageBox.Show(this, "En Verdad Quieres Eliminar Esta Factura ? ","CONFIRMAR",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) + "" == "OK")
            {
            cd.Eliminar_factura(int.Parse(textBox1.Text));
                  foreach(DataGridViewRow d in dataGridView1.Rows)
                        {
                            cd.Actualiza_producto_factura(long.Parse(d.Cells[1].Value.ToString()), int.Parse(d.Cells[4].Value.ToString()));

                        }

                    }
            else
            {
                MessageBox.Show("No Se  Eliminó");
            }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

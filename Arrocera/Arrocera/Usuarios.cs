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

using relacion;






namespace Arrocera
{
    public partial class Usuarios : Form
    {

      
        controlador tr = new controlador();
        proc p = new proc();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,
           int nTopRect,
           int nRightRect,
           int nBottonmRect,
           int nWidthEllipse,
           int nHeightEllipse

            );

        public TextBox AddNewTextbox()
        {
            TextBox txt = new TextBox();
            
            txt.BorderStyle = BorderStyle.None;
            txt.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(20, 2, 150,2 ,30,30));

            return txt;
        }

        public Usuarios()
        {
            InitializeComponent();
            // this.DoubleBuffered = true;
          

        }
      



        
        private void Usuarios_Load(object sender, EventArgs e)
        {


            dataGridView1.DataSource = tr.listar_usuarios();
            llenacombo();
        }

        private void llenacombo()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("ADMINISTRADOR");
            comboBox1.Items.Add("EMPLEADO");
        }



        private void button1_Click(object sender, EventArgs e)
        {
          

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El Campo Cedula está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("El Campo Usuario está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("El Campo Nombres está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("El Campo Contraseña está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (MessageBox.Show(this, "Desea Guardar El Usuario", "confirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) + "" == "OK")
                {
                    //relacion.usuario u = new usuario();
                    //tr.guarda_usuario(long.Parse(textBox1.Text), textBox3.Text, textBox2.Text, textBox4.Text);
                    tr.guarda_usuario(long.Parse(textBox1.Text), textBox3.Text, textBox2.Text, textBox4.Text,comboBox1.Text);
                
                    dataGridView1.DataSource = tr.listar_usuarios();
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    llenacombo();
                }

                else
                {

                }
            }



        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("El Campo Cedula está vacio ", "verifique", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else {

            if (MessageBox.Show(this, "Desea ELIMINAR El Usuario", "confirme", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) + "" == "OK")
            {

                tr.delete_usuario(long.Parse(textBox1.Text));

                dataGridView1.DataSource = tr.listar_usuarios();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

                }
                else
                {

                }
            }

        }

        private void Usuarios_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AddNewTextbox();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }
    }
}

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
    public partial class Recuperar_contraseña : Form
    {
        proc p = new proc();
        public Recuperar_contraseña()
        {
            InitializeComponent();
        }

        private void Recuperar_contraseña_Load(object sender, EventArgs e)
        {

        }
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrvalue, int attrsize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        private void Recuperar_contraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          Control_contraseña_recuperar cl = new Control_contraseña_recuperar();
            var validlogin = cl.Login(textBox1.Text, textBox2.Text);


            if (validlogin == true)
            {

           
                MessageBox.Show("Validacion Correcta  "  + Recuperar_contraseñas.Usuario, "VALIDACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                groupBoxdatos.Visible = false;
                groupBoxcontraseña.Visible = true;
                textBox4.Focus();
             


            }
            else
            {

                MessageBox.Show(" Los Datos Ingresados  Son Incorrectos", "VALIDACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

               textBox1.Text = "";
               textBox2.Text = "";
               textBox1.Focus();
                
            }


    }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Las Contraseñas No Coinciden", "VALIDACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox4.Focus();
            }
            else
            {
                Control_contraseña_recuperar cl = new Control_contraseña_recuperar();
             
                    cl.Cambiar_contraseña(textBox3.Text);
                MessageBox.Show(" CONTRASEÑA ACTUALIZADA ", "VALIDACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Hide();
                    login l = new login();
                    l.Show();
              
                }
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.UseSystemPasswordChar = false;
                textBox4.UseSystemPasswordChar = false;

              textBox3.Focus();
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;

                textBox3.Focus();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }
    }
}

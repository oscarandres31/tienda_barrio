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
    

    public partial class login : Form
    {
        Control_login cl = new Control_login();


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
            
        


        public login()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            txtusu.Focus();


            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        private void login_Load(object sender, EventArgs e)
        {
          
          
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int contador = 3;
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            try
            {

           
                    Control_login cl = new Control_login();
                    var validlogin = cl.loginuser(txtusu.Text,txtcon.Text);
          

                if (validlogin == true)
            {

                Form1 f = new Form1();
                MessageBox.Show("Bienvenid@ " + Usuariocache.Nombre, "VALIDACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f.Show();
              //  f.FormClosed += logout;
                this.Hide();


            }
            else
            {
                contador -= 1;
                MessageBox.Show(" Los Datos Ingresados  Son Incorrectos", "VALIDACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtusu.Text = "";
                txtcon.Text = "";
                txtusu.Focus();

                if(contador == 0)
                {
                    MessageBox.Show(" Has Excedido el limite de intentos Permitidos ==>'3 '  ", "VALIDACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Application.Exit();
                }
           // }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "Verifique" + ex.Message);
            }


                   }

        private void logout(object sender,FormClosedEventArgs e)
        {
            txtusu.Text = "";
            txtcon.Text = "";
            this.Show();
            txtusu.Focus();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtcon.UseSystemPasswordChar = false;
                txtcon.Focus();
            }
            else
            {
                txtcon.UseSystemPasswordChar = true;
                txtcon.Focus();
            }
        }

        private void login_Activated(object sender, EventArgs e)
        {
            txtusu.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Recuperar_contraseña r = new Recuperar_contraseña();
            r.Show();
        }
    }
}

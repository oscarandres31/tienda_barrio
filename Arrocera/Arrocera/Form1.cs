using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using control;
using System.Runtime.InteropServices;
using relacion;

namespace Arrocera
{
    public partial class Form1 : Form
    {
        private Form currentchildform;

      


        public Form1()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Maximized;
            }


        }
        //public void validare()
        //{
        //    control_login.Userlogincache.use = lbluser.Text;
        //    control_login.Userlogincache.con = lblrol.Text;
        //}
        private void Form1_Load(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
             this.WindowState= FormWindowState.Maximized;
            }

            label3.Text = DateTime.Now.ToLongDateString();
            loaduserdata();

        }


       private void loaduserdata()
        {
            lbluser.Text = Usuariocache.Nombre;
            lblrol.Text = Usuariocache.Rol;
            if (Usuariocache.Rol == "EMPLEADO")
            {
                toolStripButton3.Enabled = false;
                toolStripButton8.Enabled = false;
                toolStripButton7.Enabled = false;
            }
        }


        private void openhijo(Form childfom)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();

            }
            currentchildform = childfom;
            childfom.TopLevel = false;
            childfom.FormBorderStyle = FormBorderStyle.None;
            childfom.Dock = DockStyle.Fill;
            panelescritorio.Controls.Add(childfom);
            panelescritorio.Tag = childfom;
            childfom.BringToFront();
            childfom.Show();
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            openhijo(new Usuarios());
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            openhijo(new Creditos());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Salir De La APLICACION ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {

                Application.Exit();
            }
            else
            {

            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openhijo(new venta());
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            openhijo(new producto());
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            openhijo(new proveedores());
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            openhijo(new clientes());
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            openhijo(new Reportes());
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            openhijo(new pagos());
        }
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrvalue, int attrsize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Salir De La APLICACION ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {

                this.Close();
                login l = new login();
                l.Show();
            }
            else
            {

            }
        }

        private void panelescritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (currentchildform != null)
            {
                currentchildform.Close();
            }
        }
    }
}

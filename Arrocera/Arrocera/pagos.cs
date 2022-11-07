using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arrocera
{
    public partial class pagos : Form
    {
        public pagos()
        {
            InitializeComponent();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void abrirCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir_caja ab = new abrir_caja();
            ab.Show();
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrar_caja cc = new cerrar_caja();
            cc.Show();
        }

        private void nuevaCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            compras cm = new compras();
            cm.Show();
        }

        private void detalleCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detalle_compra dc = new detalle_compra();
            dc.Show();
        }

        private void nevaDevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            devoluciones dv = new devoluciones();
            dv.Show();
        }

        private void detalleDeDevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detalle_devoluciones dd = new detalle_devoluciones();
            dd.Show();
        }

        private void gASTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevoGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gastos g = new gastos();
            g.Show();
        }

        private void detalleDeGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalle_gastos dg = new Detalle_gastos();
            dg.Show();
        }

        private void detallesCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalle_caja dc = new Detalle_caja();
            dc.Show();
        }

        private void hoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            movimientos m = new movimientos();
            m.Show();
        }
    }
}

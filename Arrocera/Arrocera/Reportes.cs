using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using control;
using CrystalDecisions.CrystalReports.Engine;
using relacion.Reportes_Varios;

namespace Arrocera
{
    public partial class Reportes : Form
    {

        private ReportClass _report = null;

     
        public Reportes()
        {
            InitializeComponent();
        }

        public Reportes(ReportClass report)
            :this()
        {
            _report = report;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            panel1.BackColor= Color.FromArgb(100, 0, 0, 0);
            crystalReportViewer1.ReportSource = _report;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                RptVentas_diarias rep = REport_puente.rpt(dateTimePicker1.Value);
                crystalReportViewer1.ReportSource = rep;

                crystalReportViewer1.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                RptVentas_ganancias rep = Puente_ganancias.rpt(dateTimePicker4.Value);
                crystalReportViewer1.ReportSource = rep;

                crystalReportViewer1.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                RptGanancias_Entre_fechas rep = Puente_dosfechas.rpt(dateTimePicker2.Value,dateTimePicker3.Value);
                crystalReportViewer1.ReportSource = rep;

                crystalReportViewer1.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Rptinventario rep = Puente_invertido.rpt();
                crystalReportViewer1.ReportSource = rep;

                crystalReportViewer1.Refresh();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using control;
using relacion;

namespace Arrocera
{
    public partial class Creditos : Form
    {
        string[,] listaventa = new string[200, 7];
        int fila = 0;
        int n;
        Control_credito pc = new Control_credito();

        int existencias = 0;
        int valorcantudad = 0;
        proc p = new proc();
        public Creditos()
        {
            InitializeComponent();
            if (txtcedula.Text == "")
            {
                txtcedula.Text = "0000000";
                txttel.Text = "0000000";
                txtcliente.Text = "unico";
            }
        }

        public void costoapagar()
        {
            decimal costototal = 0;
            int conteo = 0;

            conteo = dtgventas.RowCount;
            for (int i = 0; i < conteo; i++)
            {
                costototal += decimal.Parse(dtgventas.Rows[i].Cells[5].Value.ToString());
            }

            lbltotal.Text = costototal.ToString();
        }

        private void pagoCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pagar_credito pc = new Pagar_credito();
            pc.Show();
        }

        private void agregarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_credito ac = new Agregar_credito();
            ac.Show();
        }

        private void cobrarALaFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cuentas_cobrar cc = new Cuentas_cobrar();
            cc.Show();
        }
        private void installedprintedcombo()
        {
            String intalprrint;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                intalprrint = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(intalprrint);
            }

            comboBox1.Text = "Microsoft Print to PDF"; // esta es la impresora predeterminada
        }
        private void Creditos_Load(object sender, EventArgs e)
        {
            lblfacha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            pc.LLenanumero_credito(lblfactura);
            installedprintedcombo();
            pc.Autocompleta(txtproducto);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Cancelar El Credito?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {

                txtdevolver.Text = "0";
                txtprecio.Text = "0";
                txtstock.Text = "";
                txtsubtotal.Text = "0.00";

                txtproducto.Text = "";
                txtcodigo.Text = "";
                txtcliente.Text = " Unico";
                if (txtcedula.Text != " ")
                {
                    txtcedula.Text = "00";
                    txttel.Text = "00 ";
                }
                else
                {

                }

                txtcant.Text = "";
                lbltotal.Text = "0.00";
                txtcobrar.Text = "0";
                txtunidad.Text = "";
                dtgventas.Rows.Clear();
                txtbuscar_codigo.Focus();
            }
        }

        private void btnremover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Remover El Producto De La Celda Seleccionada ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {
                dtgventas.Rows.Remove(dtgventas.CurrentRow);
                costoapagar();
              //  costoapagar_decuentos();
                txtsubtotal.Text = "0.00";
            }
        }

        private void txtcobrar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtdevolver.Text = (double.Parse(txtcobrar.Text) - double.Parse(lbltotal.Text)).ToString();
            }
            catch
            {
                txtdevolver.Text = "0.00";
            }

        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea IMPRIMIR El Credito?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {
                proc.crea_ticket ticket1 = new proc.crea_ticket();
                ticket1.textcentro(" Abaastos El Shaday");
                ticket1.textcentro("************************************");
                ticket1.textoizquierda("Dire : Centro Alegre");
                ticket1.textoizquierda("Tel : 3205458382");
                ticket1.textoizquierda("Maicol Caré");
                ticket1.textoizquierda(" ");
                ticket1.textcentro(" Factura De Credito");
                ticket1.textoizquierda("No Cred : " + lblfactura.Text.ToString());
                ticket1.textoizquierda("Fecha: " + DateTime.Now.ToShortDateString() + " Hora: " + DateTime.Now.ToShortTimeString());
                ticket1.textoizquierda("Le Atendio : " + Usuariocache.Nombre);
                ticket1.textoizquierda("  ");
                proc.crea_ticket.lineaguion();

                proc.crea_ticket.encavezadoventa();
                proc.crea_ticket.lineaguion();

                foreach (DataGridViewRow r in dtgventas.Rows)
                {
                    ticket1.agregarproducto(r.Cells[1].Value.ToString(), decimal.Parse(r.Cells[3].Value.ToString()), int.Parse(r.Cells[4].Value.ToString()), decimal.Parse(r.Cells[5].Value.ToString()));
                }

                proc.crea_ticket.lineaguion();
                ticket1.agregatotales("Sub-total:  ", decimal.Parse(lbltotal.Text));
              //  ticket1.agregatotales("Menos descuento:  ", decimal.Parse(txtdescuento.Text));
                ticket1.agregatotales("Mas isr:  ", decimal.Parse("000"));
                // ticket1.textoizquierda(" ");
                ticket1.agregatotales("Total :   ", decimal.Parse(lbltotal.Text));
                //  ticket1.textoizquierda(" ");
                ticket1.agregatotales("Efectivo entregado:    ", decimal.Parse(txtcobrar.Text));
                ticket1.agregatotales("Efectivo devuelto:     ", decimal.Parse(txtdevolver.Text));

                ticket1.textoizquierda(" ");
                ticket1.textoizquierda("Cliente: " + txtcliente.Text);
                ticket1.textoizquierda("Tel :" + txttel.Text);
                ticket1.textoizquierda(" ");
                ticket1.textcentro("***************************************");
                ticket1.textcentro("*   Gracias Por Preferirnos    *");
                ticket1.textcentro("***************************************");
                ticket1.textoizquierda(" ");

                ticket1.imprimirticket(comboBox1.Text);



            }
        }
        public void agregar()
        {
            try
            {
                if (txtcodigo.Text != "" && txtproducto.Text != "" && txtunidad.Text != "" && txtprecio.Text != "" && txtcant.Text != "")
                {

                    listaventa[fila, 0] = long.Parse(txtcodigo.Text).ToString();
                    listaventa[fila, 1] = txtproducto.Text;
                    listaventa[fila, 2] = txtunidad.Text;
                    listaventa[fila, 3] = decimal.Parse(txtprecio.Text).ToString();
                    listaventa[fila, 4] = int.Parse(txtcant.Text).ToString();
                    listaventa[fila, 5] = (Convert.ToDecimal(txtprecio.Text) * Convert.ToInt16(txtcant.Text)).ToString();        //   listaventa[fila, 6] = decimal.Parse(txtdescuento.Text).ToString();
                    // listaventa[fila, 7] = Int32.Parse(lblfactura.Text).ToString();
                    dtgventas.Rows.Add(listaventa[fila, 0], listaventa[fila, 1], listaventa[fila, 2], decimal.Parse(listaventa[fila, 3]), listaventa[fila, 4], decimal.Parse(listaventa[fila, 5]), listaventa[fila, 6]);
                    fila++;

                }
                //  txtcodigo.Text = txtproducto.Text = txtunidad.Text = txtprecio.Text = txtcant.Text = txtstock.Text = "";
                txtbuscar_codigo.Text = "";
                txtbuscar_codigo.Focus();
            }
            catch
            {

            }
            costoapagar();
           // costoapagar_decuentos();
            txtbuscar_codigo.Text = "";
            //txtbuscar_codigo.Text = "";

        }
        private void dtgventas_SelectionChanged(object sender, EventArgs e)
        {
            decimal m;
            foreach (DataGridViewRow itm in dtgventas.Rows)
            {
                m = Convert.ToDecimal(itm.Cells[3].Value) * Convert.ToInt32(itm.Cells[4].Value);//- Convert.ToDecimal(itm.Cells[6].Value);
                itm.Cells[5].Value = m;
                costoapagar();
              //  costoapagar_decuentos();
            }
        }
        private void subtotal()
        {
            try
            {
                if (txtcant.Text != "")
                {
                    decimal a;

                    a = (decimal.Parse(txtprecio.Text) * Int32.Parse(txtcant.Text));// - Int32.Parse(txtdescuento.Text));
                    txtsubtotal.Text = a.ToString();
                }
                else
                {

                }
            }
            catch
            {

            }
        }

        private void txtcant_TextChanged(object sender, EventArgs e)
        {
            if (txtcant.Text != "")
            {


                valorcantudad = Convert.ToInt16(txtcant.Text);
                existencias = Convert.ToInt16(txtstock.Text);


                if (valorcantudad > existencias)
                {
                    MessageBox.Show("Ingresaste una cantidad mayor a las  existencias del producto");
                }
                else if (existencias >= valorcantudad)
                {

                    subtotal();
                    agregar_instantanea();
                }
                else
                {

                }

            }
            else
            {

            }
        }

        private void Creditos_Activated(object sender, EventArgs e)
        {

            txtbuscar_codigo.Focus();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
         if (  txtcliente.Text == "" && txtcedula.Text == "" && txttel.Text == "" && txtcobrar.Text == "")
            {
                MessageBox.Show("Hay Caampos Vacios");
            }
            else
            {

                if (MessageBox.Show(this, "Desea Guardar El Credito?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
                {


                    try
                    {
                        int i = Convert.ToInt32(lblfactura.Text.ToString());
                        foreach (DataGridViewRow row in dtgventas.Rows)
                        {

                            pc.guardar_ventas(int.Parse(lblfactura.Text), long.Parse(row.Cells["column1"].Value.ToString()), row.Cells["column2"].Value.ToString(), row.Cells["column3"].Value.ToString(), decimal.Parse(row.Cells["column4"].Value.ToString()), int.Parse(row.Cells["column5"].Value.ToString()), DateTime.Parse(lblfacha.Text),DateTime.Parse(dateTimePicker1.Value.ToShortDateString()), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), txtcliente.Text, long.Parse(txttel.Text),
                        decimal.Parse(row.Cells["column6"].Value.ToString()), decimal.Parse(lbltotal.Text), decimal.Parse(txtcobrar.Text), decimal.Parse(txtdevolver.Text));


                        }
                        MessageBox.Show("Credito Guardado Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        actualiza();
                        if (checkBox1.Checked == true)
                        {
                            proc.crea_ticket ticket1 = new proc.crea_ticket();
                            ticket1.textcentro("Abastos El Shaday ");
                            ticket1.textcentro("************************************");

                            ticket1.textoizquierda("Dire : Centro Alegre");
                            ticket1.textoizquierda("Tel : 3205458382");
                            ticket1.textoizquierda("Maicol Caré");
                            ticket1.textoizquierda(" ");
                            ticket1.textcentro(" Factura De Credito");
                            ticket1.textoizquierda("No Cred : " + lblfactura.Text.ToString());
                            ticket1.textoizquierda("Fecha: " + DateTime.Now.ToShortDateString() + " Hora: " + DateTime.Now.ToShortTimeString());
                            ticket1.textoizquierda("Le Atendio : " + Usuariocache.Nombre);
                            ticket1.textoizquierda("  ");
                            proc.crea_ticket.lineaguion();

                            proc.crea_ticket.encavezadoventa();
                            proc.crea_ticket.lineaguion();

                            foreach (DataGridViewRow r in dtgventas.Rows)
                            {
                                ticket1.agregarproducto(r.Cells[1].Value.ToString(), decimal.Parse(r.Cells[3].Value.ToString()), int.Parse(r.Cells[4].Value.ToString()), decimal.Parse(r.Cells[5].Value.ToString()));
                            }

                            proc.crea_ticket.lineaguion();
                            ticket1.agregatotales("Sub-total:  ", decimal.Parse(lbltotal.Text));
                         //   ticket1.agregatotales("Menos descuento:  ", decimal.Parse(txtdescuento.Text));
                            ticket1.agregatotales("Mas isr:  ", decimal.Parse("000"));
                            ticket1.textoizquierda(" ");
                            ticket1.agregatotales("Total :   ", decimal.Parse(lbltotal.Text));
                            ticket1.textoizquierda(" ");
                            ticket1.agregatotales("Primer Abono:    ", decimal.Parse(txtcobrar.Text));
                            ticket1.agregatotales("Resta :     ", decimal.Parse(txtdevolver.Text));

                            ticket1.textoizquierda(" ");
                            ticket1.textoizquierda("Cliente: " + txtcliente.Text);
                            ticket1.textoizquierda("Tel :" + txttel.Text);
                            ticket1.textoizquierda(" ");
                            ticket1.textcentro("***************************************");
                            ticket1.textcentro("*   Gracias Por Preferirnos    *");
                            ticket1.textcentro("***************************************");
                            ticket1.textoizquierda(" ");

                            ticket1.imprimirticket(comboBox1.Text);

                        }
                        else
                        {

                        }
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
        private void actualiza()
        {
            DataGridViewRow fila = new DataGridViewRow();
            foreach (DataGridViewRow row in dtgventas.Rows)
            {

                pc.actualiza_producto(Convert.ToInt64(row.Cells[0].Value.ToString()), Convert.ToInt16(row.Cells[4].Value.ToString()));

            }


        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(txtsubtotal.Text);
            txtsubtotal.Text = dec.ToString("n");
        }

        private void txtdevolver_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(txtdevolver.Text);
            txtdevolver.Text = dec.ToString("n");
        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(lbltotal.Text);
            lbltotal.Text = dec.ToString("n");
        }

        private void dtgventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }

        private void agregar_instantanea()
        {
            try
            {


                //if (txtcant.Text == "")
                //{
                //    MessageBox.Show("Ingrese La cantidad De Productos", " VERIFIQUE ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                //    txtcant.Focus();
                //}
                //else
                //{
                    Boolean exis = false;


                    if (dtgventas.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow itm in dtgventas.Rows)
                        {

                            if (Convert.ToInt64(itm.Cells[0].Value) == Convert.ToInt64(txtcodigo.Text))
                            {

                                exis = true;
                                int o;
                                decimal s, m;
                                o = Convert.ToInt32(itm.Cells[4].Value) + Convert.ToInt32(txtcant.Text);
                                itm.Cells[4].Value = o;

                                //s = Convert.ToInt32(itm.Cells[6].Value) + decimal.Parse(txtdescuento.Text);
                                //itm.Cells[6].Value = s;

                                m = Convert.ToDecimal(itm.Cells[3].Value) * Convert.ToInt32(itm.Cells[4].Value) - Convert.ToDecimal(itm.Cells[6].Value);
                                itm.Cells[5].Value = m;
                                costoapagar();
                               // costoapagar_decuentos();
                                //txtsubtotal.Text = "0";
                                //txtdescuento.Text = "0";
                                //txtcan.Text = " ";
                                //txtproducto.Text = "";
                                //txtprecio.Text = "";
                                //txtsubtotal.Text = "0.00";
                                //txttipo.Text = "";
                                //txtcodigo.Text = "";
                                //txtcodigo.Focus();
                                txtbuscar_codigo.Text = "";
                                txtbuscar_codigo.Focus();
                                // txtcodigo.Text = "0";

                            }

                        }
                        if (exis == false)
                        {
                            agregar();
                        }
                    }
                    else
                    {
                        agregar();
                        txtbuscar_codigo.Focus();
                        txtsubtotal.Text = "0.00";
                    }

                //}
            }
            catch
            {

            }


        }
        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            if (txtcedula.Text == "")
            {
                txtcedula.Text = "00";
                txttel.Text = "00";
                txtcliente.Text = "unico";
            }
            else
            {
                pc.busca_cliente(txtcedula, txtcliente, txttel);
            }
        }

        private void txtbuscar_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txtbuscar_codigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pc.Busca_codigo(txtbuscar_codigo, txtcodigo, txtproducto, txtunidad, txtprecio, txtstock);
                txtcant.Text = 1.ToString();

                if (txtcant.Text != "")
                {
                    valorcantudad = Convert.ToInt16(txtcant.Text);
                    existencias = Convert.ToInt16(txtstock.Text);

                    if (valorcantudad > existencias)
                    {
                        MessageBox.Show("Ingresaste una cantidad mayor a las  existencias del producto");
                    }
                    else if (existencias >= valorcantudad)
                    {
                        subtotal();
                        agregar_instantanea();
                    }
                    else
                    {

                    }
                }
                else
                {

                }

               // agregar_instantanea();
            }
            catch
            {

            }
        
    }

        private void detalleCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalle_credito d = new Detalle_credito();
            d.Show();
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {
            try
            {

                pc.Busca_Producto((txtcodigo), txtproducto, txtunidad, txtprecio, txtstock);
                // txtcant.Text = 1.ToString();

                //if (txtcant.Text != "")
                //{
                //    valorcantudad = Convert.ToInt16(txtcant.Text);
                //    existencias = Convert.ToInt16(txtstock.Text);

                //    if (valorcantudad > existencias)
                //    {
                //        MessageBox.Show("Ingresaste una cantidad mayor a las  existencias del producto");
                //    }
                //    else if (existencias >= valorcantudad)
                //    {
                //        subtotal();
                //    }
                //    else
                //    {

                //    }
                //}
                //else
                //{

                //}

                //agregar_instantanea();

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
           
        }

        private void txtproducto_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {

               
                if (txtcant.Text != "")
                {
                    valorcantudad = Convert.ToInt16(txtcant.Text);
                    existencias = Convert.ToInt16(txtstock.Text);

                    if (valorcantudad > existencias)
                    {
                        MessageBox.Show("Ingresaste una cantidad mayor a las  existencias del producto");
                    }
                    else if (existencias >= valorcantudad)
                    {
                        subtotal();
                    }
                    else
                    {

                    }
                    }
                }
                else
                {

                }
               
               // agregar_instantanea();
            }
            catch
            {

            }
        }
    }
}

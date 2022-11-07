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
    public partial class compras : Form
    {

        string[,] listaventa = new string[200, 7];
        int fila = 0;
      Control_compra cv = new Control_compra();
        int n;
        Control_compra cc = new Control_compra();

        proc p = new proc();

        public compras()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Cancelar La Compra?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {

                txtdevolver.Text = "0";
                txtprecio.Text = "0";
                txtstock.Text = "";
                txtsubtotal.Text = "0.00";
             
                txtproducto.Text = "";
                txtcodigo.Text = "";
                txtcliente.Text ="";
                txtcedula.Text = "";
                txtcant.Text = "";
                lbltotal.Text = "0.00";
                txtcobrar.Text = "0";
                txtunidad.Text = "";
                dtgventas.Rows.Clear();
            }
        }

        private void compras_Load(object sender, EventArgs e)
        {
          cc.numero_factura((lblfactura));

            installedprintedcombo();
           
        }
        public void agregar()
        {
            try
            {
                if (txtcodigo.Text != "" && txtproducto.Text != "" && txtunidad.Text != "" && txtprecio.Text != "" && txtcant.Text != "")
                {

                    listaventa[fila, 0] = Int64.Parse(txtcodigo.Text).ToString();
                    listaventa[fila, 1] = txtproducto.Text;
                    listaventa[fila, 2] = txtunidad.Text;
                    listaventa[fila, 3] = decimal.Parse(txtprecio.Text).ToString();
                    listaventa[fila, 4] = int.Parse(txtcant.Text).ToString();
                    listaventa[fila, 5] = (decimal.Parse(txtprecio.Text) * Int16.Parse(txtcant.Text) - Int32.Parse(txtdescuento.Text)).ToString();
                    listaventa[fila, 6] = 0.ToString();//decimal.Parse(txtdescuento.Text).ToString();
                    // listaventa[fila, 7] = Int32.Parse(lblfactura.Text).ToString();
                    dtgventas.Rows.Add(Int64.Parse(listaventa[fila, 0]), listaventa[fila, 1], listaventa[fila, 2], decimal.Parse(listaventa[fila, 3]), int.Parse(listaventa[fila, 4]), decimal.Parse(listaventa[fila, 5]), decimal.Parse(listaventa[fila, 6]));
                    fila++;



                }
                  txtproducto.Text = txtunidad.Text = txtprecio.Text = txtcant.Text = txtstock.Text = "";
              //  txtcant.Text = "";
               // txtbuscar_codigo.Text = "";
              //  txtbuscar_codigo.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            costoapagar();
            costoapagar_decuentos();
           // txtbuscar_codigo.Text = "";
          
           
        }

        private void costoapagar_decuentos()
        {
            decimal costototal = 0;
            int conteo = 0;

            conteo = dtgventas.RowCount;
            for (int i = 0; i < conteo; i++)
            {
                costototal += decimal.Parse(dtgventas.Rows[i].Cells[6].Value.ToString());
            }

            txtdescuento.Text = costototal.ToString();
        }
        private void costoapagar()
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

        private void btnremover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Remover El Producto De La Celda Seleccionada ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {
                dtgventas.Rows.Remove(dtgventas.CurrentRow);
                costoapagar();

                txtsubtotal.Text = "0.00";
            }
        }

        private void subtotal()
        {
            try
            {
                if (txtcant.Text != "")
                {
                    decimal a;
                    a = (decimal.Parse(txtprecio.Text) * Int32.Parse(txtcant.Text) - Int32.Parse(txtdescuento.Text));
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
                subtotal();
                agregar_instantanea();
                txtbuscar_codigo.Focus();
                txtcant.Text = "";
            }
            else
            {
               txtcant.Text = "";
            }

            //}
            //else
            //{
            //   // txtcant.Text = "0";
            //}
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

        private void dtgventas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }

        private void txtdescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtdescuento.Text == "")
            {
                txtdescuento.Text = "0";
            }
            else
            {
                subtotal();
            }
        }

        //private void txtbuscar_codigo_TextChanged(object sender, EventArgs e)
        //{
        //    bool verifica = false;
        //    try
        //    {
               
        //            cc.Busca_codigo(txtbuscar_codigo, txtcodigo, txtproducto, txtunidad, txtprecio);
        //            txtcant.Text = 1.ToString();

        //        if (txtcant.Text != "")
        //        {
        //            subtotal();
        //        }
        //       else
        //       {
        //         verifica = false;
        //       }

        //        agregar_instantanea();
            
        //    }
        //    catch(Exception ex)
        //    {
              
        //    }



        //}

        //private string cadena4;
        //public void xbox2(string cadena1)
        //{
        //    string cadena2;
        //    cadena2 = cadena1;
        //    string cadena3;

        //    for (int j = 0; cadena2.Length > j; j++)
        //    {
        //        cadena3 = cadena2.Substring(j, 1);
        //        if (cadena3 == "D" || cadena3 == "R")
        //        {

        //        }
        //        else
        //        {
        //            cadena4 = cadena4 + cadena3;
        //        }

        //        if (cadena3 == "R")
        //        {
        //            txtbuscar_codigo.Text = cadena4;
        //        }
        //    }


        //}

        private void agregar_instantanea()
        {
            try
            {
                if (txtcant.Text == "")
                {
                    // MessageBox.Show("Ingrese La cantidad De Productos", " VERIFIQUE ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    // txtcant.Focus();
                }
                else
                {
                    Boolean exis = false;

                    if (dtgventas.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow itm in dtgventas.Rows)
                        {
                           
                            if(Convert.ToInt32(itm.Cells[0].Value) == Convert.ToInt32(txtbuscar_codigo.Text))
                           
                            {
                                exis = true;
                                int o;
                                decimal s, m;
                                o = Convert.ToInt32(itm.Cells[4].Value) + Convert.ToInt32(txtcant.Text);
                                itm.Cells[4].Value = o.ToString();
                                //s = Convert.ToDecimal(itm.Cells[6].Value) + decimal.Parse(txtdescuento.Text);
                                //itm.Cells[6].Value = s;
                                m = Convert.ToDecimal(itm.Cells[3].Value) * Convert.ToInt32(itm.Cells[4].Value) - Convert.ToDecimal(itm.Cells[6].Value);
                                itm.Cells[5].Value = m.ToString();
                                costoapagar();
                                // txtcant.Text = " ";
                                txtbuscar_codigo.Text = "";
                                txtbuscar_codigo.Focus();
                            }
                          
                        }
                        if (exis == false)
                        {
                            agregar();
                            txtbuscar_codigo.Text = "";
                            txtbuscar_codigo.Focus();
                        }
                        }
                   
                    else
                   
                    {
                        agregar();
                        txtbuscar_codigo.Text = "";
                    }

                }
               
            }
            catch(Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void dtgventas_SelectionChanged(object sender, EventArgs e)
        {
            decimal m;
            foreach (DataGridViewRow itm in dtgventas.Rows)
            {
                m = Convert.ToDecimal(itm.Cells[3].Value) * Convert.ToInt32(itm.Cells[4].Value) - Convert.ToDecimal(itm.Cells[6].Value);
                itm.Cells[5].Value = m.ToString();
                costoapagar();
                costoapagar_decuentos();
            }
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea IMPRIMIR La Compra?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {
                //if (MessageBox.Show(this, "Desea IMPRIMIR La Compra?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
                //{
                    proc.crea_ticket ticket1 = new proc.crea_ticket();
                    ticket1.textcentro("Abastos El Shaday ");
                    ticket1.textcentro("************************************");

                    ticket1.textoizquierda("Centro Alegre");
                    ticket1.textoizquierda("Tel : ");
                    ticket1.textoizquierda("Maicol Caré");
                    ticket1.textoizquierda(" ");
                    ticket1.textcentro(" Factura De Compras");
                    ticket1.textoizquierda("No fac : " + lblfactura.Text.ToString());
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
                    ticket1.agregatotales("Menos descuento:  ", decimal.Parse(txtdescuento.Text));
                    ticket1.agregatotales("Mas isr:  ", decimal.Parse("000"));
                    ticket1.textoizquierda(" ");
                    ticket1.agregatotales("Total :   ", decimal.Parse(lbltotal.Text));
                    ticket1.textoizquierda(" ");
                    ticket1.agregatotales("Efectivo entregado:    ", decimal.Parse(txtcobrar.Text));
                    ticket1.agregatotales("Efectivo devuelto:     ", decimal.Parse(txtdevolver.Text));

                    ticket1.textoizquierda(" ");
                    ticket1.textoizquierda("Proveedor: " + txtcliente.Text);
                    ticket1.textoizquierda("Ced :" + txtcedula.Text);
                    ticket1.textoizquierda(" ");
                    ticket1.textcentro("***************************************");
                    ticket1.textcentro("*   Gracias Por Preferirnos    *");
                    ticket1.textcentro("***************************************");
                    ticket1.textoizquierda(" ");

                    ticket1.imprimirticket(comboBox1.Text);



                }
           }

           
        
   private void installedprintedcombo()
        {
            String intalprrint;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                intalprrint = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(intalprrint);
            }

            // comboBox1.Text = "PDFLite"; // esta es la impresora predeterminada
        }


        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtcliente.Text == "" || txtcedula.Text == ""  || txtcobrar.Text == "")
            {
                MessageBox.Show("Hay Caampos Vacios");
            }
            else
            {
                if (MessageBox.Show(this, "Desea Guardar La Compra?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
                {
                    try
                    {
                        int i = Convert.ToInt32(lblfactura.Text.ToString());
                        foreach (DataGridViewRow row in dtgventas.Rows)
                        {
                           cc.Guarda_compra(int.Parse(lblfactura.Text), long.Parse(row.Cells["column1"].Value.ToString()), row.Cells["column2"].Value.ToString(), row.Cells["column3"].Value.ToString(), decimal.Parse(row.Cells["column4"].Value.ToString()), int.Parse(row.Cells["column5"].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), txtcliente.Text, decimal.Parse(row.Cells["column7"].Value.ToString()),
                        decimal.Parse(row.Cells["column6"].Value.ToString()), decimal.Parse(lbltotal.Text), decimal.Parse(txtcobrar.Text), decimal.Parse(txtdevolver.Text));
                        }
                        MessageBox.Show("Compra Guardada Correctamente", " CONFIRMADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualiza();
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
                cc.actualiza_producto(Convert.ToInt64(row.Cells[0].Value.ToString()), Convert.ToInt16(row.Cells[4].Value.ToString()));
            }
        }

        private void compras_Activated(object sender, EventArgs e)
        {
            txtbuscar_codigo.Focus();
        }

        private void compras_KeyDown(object sender, KeyEventArgs e)
        {
            //xbox2(e.KeyCode.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblfacha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();

        }

        private void txtcedula_TextChanged(object sender, EventArgs e)
        {
            if(txtcedula.Text != "") { 
            cc.Busca_Proveedor(txtcedula, txtcliente);
            }
            else
            {

            }
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txtbuscar_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txtbuscar_codigo_TextChanged(object sender, EventArgs e)
        {
            bool verifica = false;
            try
            {
               // if(txtbuscar_codigo.Text != "") { 
                verifica = true;
                cc.Busca_codigo(txtbuscar_codigo, txtcodigo, txtproducto, txtunidad, txtprecio,txtcant);
                   // txtcant.Text = 1.ToString();

                    if (txtcant.Text != "")
                    {
                        subtotal();
                        agregar_instantanea();
                        txtbuscar_codigo.Focus();
                        txtcant.Text = "";
                    }
                    else
                    {
                        verifica = false;
                    }

                   // agregar_instantanea();
                  // txtbuscar_codigo.Text = "";
              //  }
                //else
                //{

                //}
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }
    }
}

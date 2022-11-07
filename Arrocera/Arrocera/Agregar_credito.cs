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
    public partial class Agregar_credito : Form
    {

        Control_agregacion ca = new Control_agregacion();
        proc p = new proc();
        string[,] listaventa = new string[200, 7];
        int fila = 0;
        int n;
        int existencias = 0;
        int valorcantudad = 0;
        public Agregar_credito()
        {
            InitializeComponent();
        }

        private void Agregar_credito_Load(object sender, EventArgs e)
        {
            ca.LLenanumero(lblfactura);
            lblfacha.Text = DateTime.Now.ToShortDateString();
            lblhora.Text = DateTime.Now.ToShortTimeString();
            ca.Autocompletar(txtproducto);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtcliente.Text == "" && txtcedula.Text == "" )
            {
                MessageBox.Show("Hay Campos Vacios");
            }
            else
            {

                if (MessageBox.Show(this, "Desea Guardar La Agregacion ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
                {

                    try
                    {
                        // var validagregar = ca.Validate_producto(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()));

                        //if (dtgventas.Rows.Count > 0)
                        //{
                        Boolean jummm = false;
                            foreach (DataGridViewRow rows in dtgventas.Rows)
                              {
                               // var validagregar = ca.Validate_producto(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()));
                            //if (validagregar == true)
                            //{
                            //    jummm = true;
                                //foreach (DataGridViewRow row in dtgventas.Rows)
                                // {
                               /// ca.Actualiza_agregacion_producto(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(rows.Cells[5].Value.ToString()));
                                    ca.actualiza_producto(Convert.ToInt64(rows.Cells[0].Value), Convert.ToInt16(rows.Cells[4].Value));
                                     ca.guarda_agregacion(int.Parse(lblfactura.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text), int.Parse(textBox1.Text));
                                   // ca.Guarda_mas_credito(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text));
                                    MessageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //  }       
                             //   }

                                //if (validagregar == )
                                //{
                                //    ca.guarda_agregacion(int.Parse(lblfactura.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text), int.Parse(textBox1.Text));
                                //    ca.actualiza_producto(Convert.ToInt64(rows.Cells[0].Value), Convert.ToInt16(rows.Cells[4].Value));

                                //}
                               //else
                               //{
                               //     ca.guarda_agregacion(int.Parse(lblfactura.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text), int.Parse(textBox1.Text));
                               //     ca.actualiza_producto(Convert.ToInt64(rows.Cells[0].Value), Convert.ToInt16(rows.Cells[4].Value));
                               //     ca.Guarda_mas_credito(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text));
                               //     MessageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                               // }
                                //}

                              // }
                                // if (jummm == false)
                                //{
                             
                                  //  ca.guarda_agregacion(int.Parse(lblfactura.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text), int.Parse(textBox1.Text));
                                  //  ca.actualiza_producto(Convert.ToInt64(rows.Cells[0].Value), Convert.ToInt16(rows.Cells[4].Value));
                                  //  ca.Guarda_mas_credito(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text));
                               //     MessageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                              // }
                                //else
                                //{
                                //    ca.guarda_agregacion(int.Parse(lblfactura.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text), int.Parse(textBox1.Text));
                                //    ca.actualiza_producto(Convert.ToInt64(rows.Cells[0].Value), Convert.ToInt16(rows.Cells[4].Value));
                                //    ca.Guarda_mas_credito(int.Parse(textBox1.Text), long.Parse(rows.Cells[0].Value.ToString()), rows.Cells[1].Value.ToString(), rows.Cells[2].Value.ToString(), decimal.Parse(rows.Cells[3].Value.ToString()), int.Parse(rows.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(rows.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text));
                                //    MessageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //}

                            }

                            
                        //}else
                        //{
                        //    foreach (DataGridViewRow row in dtgventas.Rows)
                        //    {
                        //        ca.guarda_agregacion(int.Parse(lblfactura.Text), long.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), decimal.Parse(row.Cells[3].Value.ToString()), int.Parse(row.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(row.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text), int.Parse(textBox1.Text));
                        //        ca.actualiza_producto(Convert.ToInt64(row.Cells[0].Value), Convert.ToInt16(row.Cells[4].Value));
                        //        ca.Guarda_mas_credito(int.Parse(textBox1.Text), long.Parse(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), decimal.Parse(row.Cells[3].Value.ToString()), int.Parse(row.Cells[4].Value.ToString()), DateTime.Parse(lblfacha.Text), DateTime.Parse(lblhora.Text), long.Parse(txtcedula.Text), (txtcliente.Text), decimal.Parse(row.Cells[5].Value.ToString()), decimal.Parse(lbltotal.Text));
                        //        MessageBox.Show("Producto Agregado Con Exito Al Credito", "CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //}

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
               
            }
        }

        private void txtbuscar_codigo_TextChanged(object sender, EventArgs e)
        {
            //if(txtbuscar_codigo.Text != "")
            //{
            try { 
                       ca.Busca_codigo(txtbuscar_codigo,txtcodigo,txtproducto,txtunidad,txtprecio,txtstock);
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
                }
                else
                {

                }
            }
            else
            {

            }

            agregar_instantanea();
        }
            catch
            {

            }
        

            }
            //else
            //{

            //}

       // }

    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
                {
                ca.Buscar_credito(textBox1, txtcedula, txtcliente);
            }
            else
            {

            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Cancelar La Agregacion A Credito?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {

            
                txtprecio.Text = "0";
                txtstock.Text = "";
                txtsubtotal.Text = "0.00";

                txtproducto.Text = "";
                txtcodigo.Text = "";
                txtcliente.Text = " Unico";
                if (txtcedula.Text != " ")
                {
                    txtcedula.Text = "00";
                   
                }
                else
                {

                }

                txtcant.Text = "";
                lbltotal.Text = "0.00";
             
                txtunidad.Text = "";
                dtgventas.Rows.Clear();
                txtbuscar_codigo.Focus();
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

        private void btnremover_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Desea Remover El Producto De La Celda Seleccionada ?", "CONFIRMAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) + "" == "OK")
            {
                dtgventas.Rows.Remove(dtgventas.CurrentRow);
                costoapagar();
              
                txtsubtotal.Text = "0.00";
            }
        }
        public void agregar()
        {
            try
            {
                if (txtcodigo.Text != "" && txtproducto.Text != "" && txtunidad.Text != "" && txtprecio.Text != "" && txtcant.Text != "")
                {

                    listaventa[fila, 0] = Convert.ToInt64(txtcodigo.Text).ToString();
                    listaventa[fila, 1] = txtproducto.Text;
                    listaventa[fila, 2] = txtunidad.Text;
                    listaventa[fila, 3] = decimal.Parse(txtprecio.Text).ToString();
                    listaventa[fila, 4] = int.Parse(txtcant.Text).ToString();
                    listaventa[fila, 5] = (Convert.ToDecimal(txtprecio.Text) * Convert.ToInt16(txtcant.Text)).ToString();        //   listaventa[fila, 6] = decimal.Parse(txtdescuento.Text).ToString();
                    // listaventa[fila, 7] = Int32.Parse(lblfactura.Text).ToString();
                    dtgventas.Rows.Add(Convert.ToInt64(listaventa[fila, 0]), listaventa[fila, 1], listaventa[fila, 2], decimal.Parse(listaventa[fila, 3]), listaventa[fila, 4], decimal.Parse(listaventa[fila, 5]), listaventa[fila, 6]);
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
           
            txtbuscar_codigo.Text = "";
            //txtbuscar_codigo.Text = "";

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
                }
                else
                {

                }
                agregar_instantanea();
            }
            else
            {

            }
        }

        private void dtgventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }

        private void agregar_instantanea()
        {
            try
            {


                if (txtcant.Text == "")
                {
                    MessageBox.Show("Ingrese La cantidad De Productos", " VERIFIQUE ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtcant.Focus();
                }
                else
                {
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

                }
            }
            catch
            {

            }

        }

        private void txtbuscar_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void txtcant_KeyPress(object sender, KeyPressEventArgs e)
        {
            p.solonumeros(e);
        }

        private void lbltotal_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(lbltotal.Text);
            lbltotal.Text = dec.ToString("n");
        }

        private void txtsubtotal_TextChanged(object sender, EventArgs e)
        {
            decimal dec = Convert.ToDecimal(txtsubtotal.Text);
            txtsubtotal.Text = dec.ToString("n");
        }

        private void dtgventas_SelectionChanged(object sender, EventArgs e)
        {
            decimal m;
            foreach (DataGridViewRow itm in dtgventas.Rows)
            {
                m = Convert.ToDecimal(itm.Cells[3].Value) * Convert.ToInt32(itm.Cells[4].Value) ;
                itm.Cells[5].Value = m;
                costoapagar();
              
            }
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Control_credito pc = new Control_credito();

                pc.Busca_Producto((txtcodigo), txtproducto, txtunidad, txtprecio, txtstock);
            }
            catch
            {

            }
        }
    }
}

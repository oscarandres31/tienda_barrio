using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace relacion
{
   public class proc
    {
        public void solonumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        public class crea_ticket
        {
            public static System.Drawing.Font printfont;
            public static StreamReader streamToprint;

            public static StringBuilder line = new StringBuilder();
            string ticket = "";
            string parte1, parte2;

            public static int max = 40;
            int cort;
            private string[] cadenaserver;
            public byte[] serverbyte { get; private set; }

            public static string lineaguion()
            {
                string lineaguionn = "--------------------------------------";
                return line.AppendLine(lineaguionn).ToString();
            }


            public static void encavezadoventa()
            {
                string lineaencavezado = "Articulo           Cant  P.unit   Sub";
                line.AppendLine(lineaencavezado);
            }
            public void textoizquierda(string part1)
            {
                max = part1.Length;
                if (max > 40)
                {
                    cort = max - 40;
                    parte1 = part1.Remove(40, cort);
                }
                else
                {
                    parte1 = part1;
                    line.AppendLine(ticket = parte1);
                }
            }


            public void textoderecha(string part1)
            {
                ticket = "";
                max = part1.Length;
                if (max > 40)
                {
                    cort = max - 40;
                    parte1 = part1.Remove(40, cort);
                }
                else { parte1 = part1; }
                max = 40 - part1.Length;
                for (int u = 0; u < max; u++)
                {
                    ticket += " ";
                }
                line.AppendLine(ticket += parte1 + "\n");
            }
            public void textcentro(string part1)
            {
                ticket = " ";
                max = part1.Length;
                if (max > 40)
                {
                    cort = max - 40;
                    parte1 = part1.Remove(40, cort);
                }
                else { parte1 = part1; }
                max = (int)(40 - parte1.Length) / 2;
                for (int i = 0; i < max; i++)
                {
                    ticket += " ";
                }
                line.AppendLine(ticket += parte1 + "\n");
                ticket += " ";
            }
            // line.AppendLine(ticket += parte1 + "\n" );
            //  }


            public void Textextremos(string part1, string part2)
            {
                max = part1.Length;
                if (max > 18)
                {
                    cort = max - 18;
                    parte1 = part1.Remove(18, cort);
                }
                else { parte1 = part1; }
                ticket = parte1;
                max = part2.Length;
                if (max > 18)
                {
                    cort = max - 18;
                    parte2 = part2.Remove(18, cort);
                }
                else { parte2 = part2; }
                max = 40 - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)
                {
                    ticket = " ";
                }
                line.AppendLine(ticket += parte2 + "\n");
            }


            public void agregatotales(string part1, decimal total)
            {
                max = part1.Length;
                if (max > 25)
                {
                    cort = max - 25;
                    parte1 = part1.Remove(25, cort);
                }
                else { parte1 = part1; }
                ticket = parte1;
                parte2 = "$" + total.ToString();
                max = 40 - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)
                {
                    ticket += "";
                }
                line.AppendLine(ticket += parte2 + "\n");
            }



            public void agregarproducto(string articulo, decimal precio, int cant, decimal subtotal)
            {
                if (cant.ToString().Length <= 3 && precio.ToString("c").Length <= 10 && subtotal.ToString("c").Length <= 11)
                {
                    string elementos = "", espacios = "";
                    bool bandera = false;
                    int nroEspacios = 0;

                    if (articulo.Length > 16)
                    {
                        // nroEspacios = (3 - cant.ToString().Length);
                        //int caracteractual = 0;
                        //for (int longitud = articulo.Length; longitud > 16; longitud -= articulo.Length)
                        //{
                        //    line.AppendLine(articulo.Substring(caracteractual, 16 ));
                        //    caracteractual += 16;
                           
                           

                        //}

                        //line.AppendLine(articulo.Substring(caracteractual, articulo.Length - caracteractual));
                        //// line.AppendLine(elementos += espacios + cant.ToString());
                    //    }
                        //else if (articulo.Length > 16)
                        //{
                            //for (int i = 16; i > (16 - articulo.Length); i++)
                            //{
                            //    espacios += " ";
                            //}
                               elementos +=  espacios;

                            nroEspacios = (3 - cant.ToString().Length);
                        espacios = "";
                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + cant.ToString();
                        nroEspacios = (10 - precio.ToString().Length);
                       espacios = "";

                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }
                        elementos += espacios + precio.ToString();
                        nroEspacios = (11 - subtotal.ToString().Length);
                        espacios = "";

                        for (int i = 0; i < nroEspacios; i++)
                        {
                            espacios += " ";
                        }

                        elementos += espacios + subtotal.ToString();

                        int caracteractual = 0;
                        for (int longtext = articulo.Length; longtext > 16; longtext -= articulo.Length)
                        {
                            if (bandera == false)
                            {
                                line.AppendLine(articulo.Substring(caracteractual, 16) + elementos);
                                bandera = true;
                            }
                            else
                            {
                                line.AppendLine(articulo.Substring(caracteractual, 16));
                            }
                            caracteractual += 16;
                        }
                        line.AppendLine(articulo.Substring(caracteractual, articulo.Length - caracteractual));

                    }
                    else
                {
                    for (int i = 0; i < (16 - articulo.Length); i++)
                    {
                        espacios += " ";
                    }

                    elementos += articulo + espacios;
                    nroEspacios = (3 - cant.ToString().Length);
                    espacios = "";
                    elementos += espacios + cant.ToString();


                    nroEspacios = (10 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + precio.ToString();
                    nroEspacios = (11 - subtotal.ToString().Length);
                    espacios = "";

                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elementos += espacios + subtotal.ToString();
                    line.AppendLine(elementos);
                }
           // }
                }
                else
                {

                }

            }

            public void imprimirticket(string impresora)
            {
                File.WriteAllText("factura.txt", line.ToString());

                line = new StringBuilder();
                try
                {
                    streamToprint = new StreamReader
                    ("factura.txt");

                    try
                    {
                        printfont = new System.Drawing.Font("Arial", 10);
                        PrintDocument pd = new PrintDocument();
                        pd.PrintPage += new PrintPageEventHandler
                        (this.pd_Printage);

                        pd.PrinterSettings.PrinterName = impresora;

                        pd.DocumentName = "factura" + DateTime.Now.ToString();
                        pd.Print();
                    }
                    finally
                    {
                        streamToprint.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }


            public void pd_Printage(object sender, PrintPageEventArgs ev)
            {
                float linesperpage = 0;
                float ypos = 0;
                int count = 0;
                float leftmargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;



                linesperpage = ev.MarginBounds.Height;
                printfont.GetHeight(ev.Graphics);

                while (count < linesperpage &&
                ((line = streamToprint.ReadLine()) != null))
                {
                    ypos = topMargin + (count * printfont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printfont, Brushes.Black, leftmargin, ypos, new StringFormat());
                    count++;
                }
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
        }








    }
}

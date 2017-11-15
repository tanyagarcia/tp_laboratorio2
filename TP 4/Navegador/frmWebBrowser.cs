using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            if (!(this.txtUrl.Text.StartsWith("http://")))
            {
                this.txtUrl.Text = "http://" + this.txtUrl.Text;
            }

            Uri uri = new Uri(this.txtUrl.Text);
            archivos.guardar(this.txtUrl.Text);

            Descargador descargador = new Descargador(uri);
            ProgresoDescargaCallback progresoDescarga = ProgresoDescarga;
            FinDescargaCallback finDescarga = FinDescarga;
            descargador.IniciarDescarga();
            progresoDescarga.Invoke(descargador._progreso);
            finDescarga.Invoke(descargador._html);

            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (descargador._progreso < 100)
                    {
                        progresoDescarga.Invoke(descargador._progreso);
                        if (descargador._progreso == 100)
                        {
                            progresoDescarga.Invoke(descargador._progreso);
                            break;
                        }
                    }
                }
                while (true)
                {
                    if (descargador._html != "")
                    {
                        finDescarga.Invoke(descargador._html);
                        break;
                    }
                }
            });
            thread.Start();

        }

        private void mostrarHistorialMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial frmHistorial = new frmHistorial();
            frmHistorial.ShowDialog();
        }
    }
}

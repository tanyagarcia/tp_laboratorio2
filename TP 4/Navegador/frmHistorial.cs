using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivo = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            List<string> historial;

            if (archivo.leer(out historial) == false)
            {
                MessageBox.Show("Error al cargar archivo");
                this.Close();
            }

            foreach (string direccion in historial)
            {
                lstHistorial.Items.Add(direccion);
            }

        }
    }
}

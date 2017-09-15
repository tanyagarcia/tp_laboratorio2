using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class FrmCalculadora : Form
    {
 
            public FrmCalculadora()
            {
                InitializeComponent();
            }

            private void FrmCalculadora_Load(object sender, EventArgs e)
            {

            }

            private void lblResultado_Click(object sender, EventArgs e)
            {
               
            }

            private void txtOperando1_TextChanged(object sender, EventArgs e)
            { 
 
            }

            private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void txtOperando2_TextChanged(object sender, EventArgs e)
            {
                
            }

            private void btnLimpiar_Click(object sender, EventArgs e)
            {
                txtOperando1.Text = "";
                txtOperando2.Text = "";
                lblResultado.Text = "Resultado";
                cmbOperacion.Text = "Operacion";

            }

            private void btnOperar_Click(object sender, EventArgs e)
            {
                double resultado;
                Numero _numero1 = new Numero(txtOperando1.Text);
                Numero _numero2 = new Numero(txtOperando2.Text);
                resultado = Calculadora.operar(_numero1, _numero2, cmbOperacion.Text);
                lblResultado.Text = resultado.ToString();
            }


        }
}

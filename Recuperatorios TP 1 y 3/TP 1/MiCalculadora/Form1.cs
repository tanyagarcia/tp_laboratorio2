using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.cmbOperador.SelectedIndex = 0;
        }

        private void Limpiar()
        {
            txtNum1.Clear();
            txtNum2.Clear();
            lblResultado.Text = "Resultado";
            cmbOperador.SelectedItem = "+";
            txtNum1.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero Numero1 = new Numero(numero1);
            Numero Numero2 = new Numero(numero2);

            return Calculadora.Operar(Numero1, Numero2, operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (txtNum1.Text != "" && txtNum2.Text != "")
            {
                try
                {
                    lblResultado.Text = Convert.ToString(Operar(txtNum1.Text, txtNum2.Text, cmbOperador.Text));
                }
                catch (DivideByZeroException) { MessageBox.Show("No se puede dividir por cero"); }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Resultado")
            {
                this.lblResultado.Text = (Numero.DecimalBinario(lblResultado.Text));
            }
            else
                MessageBox.Show("No se encontro resultado para convertir");
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Resultado")
            {
                this.lblResultado.Text = (Numero.BinarioDecimal(lblResultado.Text));
            }
            else
                MessageBox.Show("No se encontro resultado para convertir");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtNum1.Focus();
        }
    }

}

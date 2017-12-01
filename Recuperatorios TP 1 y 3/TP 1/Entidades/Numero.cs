using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public double GetNumero { get { return this.numero; } }

        public static string BinarioDecimal(string binario)
        {
            int numero = 0;
            for (int x = binario.Length - 1, y = 0; x >= 0; x--, y++)
            {
                if (binario[x] == '0' || binario[x] == '1')
                    numero += (int)(int.Parse(binario[x].ToString()) * Math.Pow(2, y));
                else
                    return "Valor invalido";
            }
            return Convert.ToString(numero);
        }

        public static string DecimalBinario(double numero)
        {
            string binario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        binario = "0" + binario;
                    }
                    else
                    {
                        binario = "1" + binario;
                    }

                    numero = (int)numero / 2;
                }
            }
            else if (numero == 0)
            {
                binario = "0";
            }
            else
            {
                binario = "Valor invalido";
            }

            return binario;

        }

        public static string DecimalBinario(string numero)
        {
            double v;
            if (double.TryParse(numero, out v))
                return DecimalBinario(v);
            else
                return "Valor invalido";

        }

        public Numero()
        {
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.GetNumero + n2.GetNumero;
        }

        public static double operator - (Numero n1, Numero n2)
        {
            return n1.GetNumero - n2.GetNumero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.GetNumero * n2.GetNumero;
        }

        public static double operator / (Numero n1, Numero n2)
        {
            if(n2.GetNumero ==0)
            {
                throw new DivideByZeroException();
            }
            else
                return n1.GetNumero / n2.GetNumero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numeroRetorno = 0;
            if(double.TryParse(strNumero, out numeroRetorno) == false)
            {
                return 0;
            }

            return numeroRetorno;

        }


        
    }
}

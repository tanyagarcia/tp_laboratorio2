using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor con parámetro string que valida y setea el numero alli contenido
        /// </summary>
        /// <param name="num">el numero a setear</param>
        public Numero(string num)    
        {
            setNumero(num);
        }
            

        /// <summary>
        /// Constructor con parámetro double que valida y setea el numero reutilizando el contructor con parámetro string
        /// </summary>
        /// <param name="num">el numero a setear</param>
        public Numero(double num): this(Convert.ToString(num))
        {
            
        }

        /// <summary>
        /// Devuelve el valor asociado al atributo de la clase
        /// </summary>
        /// <returns>retorna el valor</returns>
        public double getNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Valida el numero ingresado
        /// </summary>
        /// <param name="numero">numero ingresado</param>
        /// <returns>retorna el numero</returns>
        private double validarNumero(string numero)
        {
            double numRetorno;
            if (!double.TryParse(numero, out numRetorno))// TryParse para castear (string a double) y validar el double
            {
                numRetorno = 0;
            }

            return numRetorno;
        }

        /// <summary>
        /// Setea el numero luego de validarlo
        /// </summary>
        /// <param name="numeroASetear">numero a setear</param>
        private void setNumero(string numeroASetear)
        {
            double auxiliarNumASetear;
            auxiliarNumASetear = validarNumero(numeroASetear);
            if (auxiliarNumASetear != 0)
            {
                this.numero = auxiliarNumASetear;
            }

        }


    }
}

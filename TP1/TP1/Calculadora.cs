using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP1
{
    public class Calculadora
    {
        /// <summary>
        /// Realiza la operacion entre operando 1 y operando 2.En caso de división por cero, muestra mensaje de error.
        /// </summary>
        /// <param name="numero1">operando 1</param>
        /// <param name="numero2">operando 2</param>
        /// <param name="operador">operador</param>
        /// <returns>retorna el resultado de la operacion</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado= 0;
            operador = validarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado =  numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if(numero2.getNumero() == 0)
                    {
                        Console.Write(" No se puede dividir por 0 ");
                    }
                    else
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida el operador seleccionado. En caso que no se haya seleccionado ninguno, devuelve operador de suma.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>el operador validado</returns>
        public static string validarOperador(string operador)
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador= "+";
            }

            return operador;
   
        }

       
    }
}

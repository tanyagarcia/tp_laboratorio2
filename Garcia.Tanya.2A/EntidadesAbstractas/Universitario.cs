using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor de instancia. Asigna un valor a legajo
        /// </summary>
        /// <param name="legajo">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        /// <summary>
        /// Compara si el objeto es del tipo de la clase
        /// </summary>
        /// <param name="obj">objeto a comparar</param>
        /// <returns>true si son iguales, false en caso contrario</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo que muestra todos los datos del universitario
        /// </summary>
        /// <returns>los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());// CHEQUEAR
            sb.AppendLine("LEGAJO NUMERO: " + this._legajo.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// Compara si dos universitarios son del mismo tipo y si tienen el mismo legajo o DNI
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>true si son iguales</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compara si dos universitarios no son del mismo tipo y no tienen el mismo legajo
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Univeristario 2</param>
        /// <returns>true si son distintos, false caso contrario</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Metodo abstracto
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
    }
}

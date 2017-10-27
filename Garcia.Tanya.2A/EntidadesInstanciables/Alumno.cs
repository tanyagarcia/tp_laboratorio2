using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        /// <summary>
        /// Constructor por default
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de instancia, asigna valor a claseQueToma
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">tring</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="claseQueToma">EClases</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de instancia, asigna valor a estadoCuenta
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="claseQueToma">EClases</param>
        /// <param name="estadoCuenta">EEstado cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Compara si el alumno toma la clase ingresada y si el estado no es deudor
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">EClases</param>
        /// <returns>true si la comparacion es verdadera, false caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Compara si el alumno no toma la clase ingresada
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">EClases</param>
        /// <returns>true si no toma la clase, false caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._claseQueToma != clase)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Muestra los datos del Alumno
        /// </summary>
        /// <returns>datos de alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo ToString
        /// </summary>
        /// <returns>invoca a metodo MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Retorna el tipo de clase que toma el alumno
        /// </summary>
        /// <returns>cadena que contiene el tipo de clase</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE: " + this._claseQueToma;
        }
    }
}

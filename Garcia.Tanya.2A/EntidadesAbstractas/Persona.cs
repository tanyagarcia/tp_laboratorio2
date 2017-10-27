using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region enumerados
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        #endregion


        private string _apellido;
        private int _dni;
        private string _nombre;
        private ENacionalidad _nacionalidad;

        /// <summary>
        /// Propiedad Apellido: retorna apellido o setea su valor
        /// </summary>
        public string Apellido
        {
            get
            { return this._apellido; }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad DNI: retorna el DNI o setea su valor en tipo int
        /// </summary>
        public int DNI
        {
            get
            { return this._dni; }
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad Nacionalidad: retorna la nacionalidad o setea su valor
        /// </summary>

        public ENacionalidad Nacionalidad
        {
            get
            { return this._nacionalidad; }
            set
            {
                this._nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad Nombre: retorno el nombre o setea su valor
        /// </summary>

        public string Nombre
        {
            get
            { return this._nombre; }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad StringToDni: setea el valor del dni en tipo de dato string
        /// </summary>
        public string StringToDni { set { this._dni = ValidarDni(this._nacionalidad, int.Parse(value)); } }

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de instancia
        /// </summary>
        /// <param name="nombre">nombre de la persona</param>
        /// <param name="apellido">apellido de la persona</param>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia que asigna un valor a dni en formato int
        /// </summary>
        /// <param name="nombre">string nombre de la persona</param>
        /// <param name="apellido">string apellido de la persona</param>
        /// <param name="dni">int dni de la persona</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de instancia que asigna un valor a dni en formato string
        /// </summary>
        /// <param name="nombre">string nombre de la persona</param>
        /// <param name="apellido">string apellido de la persona</param>
        /// <param name="dni">string dni de la persona</param>
        /// <param name="nacionalidad">ENacionalidad nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString. Devuelve todos los datos de la persona
        /// </summary>
        /// <returns>datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} ", this._nombre, this._apellido);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad);
            return sb.ToString();

        }

        /// <summary>
        /// Valida el dni y nacionalidad. Si es correcto lo retorna, sino lanza excepcion
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="dato">int</param>
        /// <returns>dni validado si es correcto, caso contrario lanza excepcion</returns>

        protected int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Extranjero)
                return dato;
            else if (nacionalidad == ENacionalidad.Argentino && dato > 1 && dato < 89999999)
                return dato;
            else
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida el Dni en tipo string
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="dato">string</param>
        /// <returns>dni validado</returns>

        protected int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, (int.Parse(dato)));
        }

        /// <summary>
        /// Validad que el nombre o apellido contengan caracteres validos
        /// </summary>
        /// <param name="dato">string</param>
        /// <returns>devuelve el nombre y apellido si son validos, caso contrario devuelve una cadena vacia</returns>
        protected string ValidarNombreApellido(string dato)
        {
            int i = 0;
            while ((dato[i] < 'a' || dato[i] > 'z') && (dato[i] < 'A' || dato[i] > 'Z'))
            {
                return " ";
            }

            return dato;
        }



    }
}


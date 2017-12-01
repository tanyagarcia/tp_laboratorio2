using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;



namespace EntidadesAbstractas
{
    [XmlInclude(typeof(Persona))]
    [XmlInclude(typeof(Universitario))]

    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        private string _apellido;
        private string _nombre;
        private int _dni;
        private ENacionalidad _nacionalidad;

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {

            set
            {
                this._dni = ValidarDni(this._nacionalidad, value);
            }
        }

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad): this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad): this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1} ", this._nombre, this._apellido);
            sb.Append("NACIONALIDAD: " + this._nacionalidad);
            return sb.ToString();

        }


        /// <summary>
        /// Valida el dni y nacionalidad. Si es correcto lo retorna, sino lanza excepcion
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="dato">int</param>
        /// <returns>dni validado si es correcto, caso contrario lanza excepcion</returns>
        private int ValidarDni (ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 1 && dato < 89999999)
                        return dato;
                    else
                        throw new DniInvalidoException();

                case ENacionalidad.Extranjero:
                    if (dato > 89999999)
                        return dato;
                    else
                        throw new NacionalidadInvalidaException();

            }

            return 0;
        }

        /// <summary>
        /// Valida el Dni en tipo string
        /// </summary>
        /// <param name="nacionalidad">ENacionalidad</param>
        /// <param name="dato">string</param>
        /// <returns>dni validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoOut;
            if (int.TryParse(dato, out datoOut) == true)
            {
                return ValidarDni(nacionalidad, datoOut);
            }

            return 0;
        }

        /// <summary>
        /// Validad que el nombre o apellido contengan caracteres validos
        /// </summary>
        /// <param name="dato">string</param>
        /// <returns>devuelve el nombre y apellido si son validos, caso contrario devuelve una cadena vacia</returns>
        private string ValidarNombreApellido(string dato)
        {
             int i = 0;
            for(i=0; i<dato.Length; i++)
            {
                if(char.IsLetter(dato[i]) || char.IsWhiteSpace(dato[i]))// si el dato en la posicion i es letra o es espacio en blanco, devuelve string
                {
                    return dato;
                }
            }

            return "" ;
        }

    }
}

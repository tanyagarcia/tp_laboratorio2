using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;


        /// <summary>
        /// Constructor estatico que inicializa el atributo _randome
        /// </summary>
        static Profesor()
        {
            Profesor._random = new Random();
        }

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Profesor()
        {

        }
        /// <summary>
        /// Constructo de instancia que inicializa la cola de tipo EClases y le agrega dos clases mediante metodo _randomClases()
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="dni">string</param>
        /// <param name="nacionalidad">ENacionalidad</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>(2);
            this._randomClases();
        }

        /// <summary>
        /// Metodo que agrega dos clases a la cola  de EClases
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
            }
        }

        /// <summary>
        /// Sobreescritura del metodo MostrarDatos() heredado de Universitario que muestra los datos de un profesor
        /// </summary>
        /// <returns>cadena con los datos del profesor y las clases que da</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }


        /// <summary>
        /// Un profesor es igual a un EClase si da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns>true si da la clase, false caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases clases in i._clasesDelDia)
            {
                if (clases == clase)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Un profesor sera distinto de un EClase si no da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">EClase</param>
        /// <returns>true si no da esa clase, false caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Sobreescritura del metodo ParticiparEnClase() que muestra las clases del dia
        /// </summary>
        /// <returns>cadena con los nombres de las clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clases in this._clasesDelDia)
            {
                sb.AppendLine(clases.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del metodo ToString() que invoca a metodo protegido MostrarDatos()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [XmlInclude(typeof(Universitario))]
    [XmlInclude(typeof(Profesor))]

    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        public Profesor()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
        }

        static Profesor()
        {
            Profesor._random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// se le asignan dos clases al azar al profesor
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                int random = Profesor._random.Next(0, 4);
                this._clasesDelDia.Enqueue((Universidad.EClases)random);
            }

        }

        /// <summary>
        /// muestra las clases que da el profesor
        /// </summary>
        protected override string ParticiparEnClase()
        {
            return "Clases del dia: " + this._clasesDelDia.ElementAt(0) + ", " + this._clasesDelDia.ElementAt(1);
        }


        /// <summary>
        /// muestra los datos del profesor
        /// </summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// hace publicos los datos del profesor
        /// </summary>
        /// <returns>retorna un string con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// un profesor es igual a una clase solo si da esa clase
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in profesor._clasesDelDia)
            {
                if (c == clase)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// un profesor es distinto a una clase solo si no da dicha clase
        /// </summary>
        /// <returns>retorna true si es distinto o false caso contrario</returns>
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
        }
    }
}

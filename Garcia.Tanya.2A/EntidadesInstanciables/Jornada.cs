using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        /// <summary>
        /// Constructor por default que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructo de instancia, asigna un valor al atributo _clase e _instructor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;

        }


        /// <summary>
        /// Propiedad que devuelve la lista de alumnos o setea un alumno
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            { return this._alumnos; }
            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve una clase o setea un valor en el atributo
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            { return this._clase; }
            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el instructor o setea un valor en el atributo
        /// </summary>
        public Profesor Instructor
        {
            get
            { return this._instructor; }
            set
            {
                this._instructor = value;
            }
        }

        /// <summary>
        /// Metodo de instancia que guarda una jornada en un archivo
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>true si lo guardo, false caso contrario</returns>
        public static bool Guardar (Jornada jornada)
        {
            return true;
        }


        /// <summary>
        /// Metodo que retorna los datos de la jornada como texto
        /// </summary>
        /// <returns>cadena con datos serializados</returns>
        public static string Leer()
        {
            return "";
        }

        /// <summary>
        /// Una jornada sera igual a un alumno si este participa de la misma
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno i in j._alumnos)
            {
                if (i == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Un jornada sera distinta a un alumno si este no participa de la misma
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada, validando previamente que el alumno no se encuentre en la misma
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            for (int i = 0; i < j._alumnos.Count; i++)
            {
                if (j._alumnos[i] == a)
                    continue;
                else
                    j._alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString()
        /// </summary>
        /// <returns>cadenada con los datos de todos los alumnos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE: " + this._clase.ToString());
            sb.AppendLine("INSTRUCTOR: " + this._instructor);
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }

            return sb.ToString();
        }
    }
}

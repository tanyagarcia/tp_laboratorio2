using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        /// <summary>
        /// hace publicos los datos del alumno
        /// </summary>
        /// <returns>retorna un string con los datos del alumno</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this._clase.ToString(), this._instructor.ToString());
            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("<-------------------------------------------------------------->");
            return sb.ToString();
        }

        /// <summary>
        /// una jornada es igual a un alumno solo si ese alumno participa en la jornada
        /// </summary>
        /// <returns>retorna true si son iguales o false caso contrario</returns>
        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            bool retorno = false;
            for (int i = 0; i < jornada._alumnos.Count; i++)
            {
                if (jornada._alumnos[i].Equals(alumno))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// una jornada es distinto a un alumno solo si ese alumno no participa de dicha jornada
        /// </summary>
        /// <returns>retorna true si son distintos o false caso contrario</returns>
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            return !(jornada == alumno);
        }

        /// <summary>
        /// agrega un alumno a una jornada validando que no este previamente cargado
        /// </summary>
        /// <returns>retorna la jornada con el alumno agregado o no si ya estaba cargado</returns>
        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno)
            {
                jornada._alumnos.Add(alumno);
            }
            else
                throw new AlumnoRepetidoException();
            return jornada;
        }

        /// <summary>
        /// Metodo de instancia que guarda una jornada en un archivo
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>true si lo guardo, false caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto _tex = new Texto();
            return _tex.guardar("Jornada.txt", jornada.ToString());
        }


        /// <summary>
        /// Metodo que retorna los datos de la jornada como texto
        /// </summary>
        /// <returns>cadena con datos serializados</returns>
        public static string Leer()
        {
            string datos = "";
            Texto _tex = new Texto();
            _tex.leer("Jornada.txt", out datos);
            return datos;
        }
    }
}

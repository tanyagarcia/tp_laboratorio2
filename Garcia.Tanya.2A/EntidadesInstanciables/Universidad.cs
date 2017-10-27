using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        /// <summary>
        /// Constructor por default que iniciliza la lista alumnos, la lista jornada y la lista profesores
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        /// <summary>
        /// Propiedad que retorna la lista de alumnos o setea un valor en la misma
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set
            {
                this.alumnos = value;
            }

        }

        /// <summary>
        /// Propiedad que devuelve la lista de profesores o setea un valor en la misma
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set
            {
                this.profesores = value;
            }

        }

        /// <summary>
        /// Propiedad que devuelve la lista de jornadas o setea un valor en la misma
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set
            {
                this.jornada = value;
            }

        }

        /// <summary>
        /// Indizador de la lista de jornadas
        /// </summary>
        /// <param name="i">int indice</param>
        /// <returns>el elemento en esa posicion o agrega un valor en la posicion</returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= this.Jornadas.Count || i < 0)
                    return null;
                else
                    return this.Jornadas[i];
            }
            set
            {
                if (i >= 0 && i < this.Jornadas.Count)
                    this.Jornadas[i] = value;
                else if (i == this.Jornadas.Count)
                {
                    this.Jornadas.Add(value);
                }
            }

        }

        /// <summary>
        /// Guarda los datos de una universidad en un archivo xml
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns>true si pudo guardarlo , false caso contrario</returns>
        public static bool Guardar(Universidad gim)
        {
            return true;
        }

        /// <summary>
        /// Muestra todos los datos de una  universidad
        /// </summary>
        /// <param name="gim">Universidad</param>
        /// <returns>cadena que contiene los datos</returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADAS: ");
            foreach (Jornada j in gim.Jornadas)
            {
                sb.AppendLine(j.ToString());
            }
            

            return sb.ToString();
        }

        /// <summary>
        /// Una universidad sera distinta a un alumno si este no esta inscripta en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si no esta inscripto, false caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Devuelve el primer profesor que tenga no asignada esa clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">EClases</param>
        /// <returns>el primer profesor que no tengo asignada esa clase, si no lo encuentra devuelve null</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor profe = new Profesor();
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                {
                    profe = profesor;
                }
            }

            return profe;
        }

        /// <summary>
        /// Una universidad y un profesor son distintas si este da clases en esa universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si son distintos, false caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Una universidad sera igual a un alumno si este esta inscripta en ella
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumnos</param>
        /// <returns>true si esta inscripto en ella, false caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno b in g.alumnos)
            {
                if (b == a)
                    return true;
            }

            return false;
        }


        /// <summary>
        /// Devuelve el primer profesor que tenga asignada esa clase, sino lanza excepcion SinProfesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">EClases</param>
        /// <returns>true si encuentra al profesor, si no lanza excepcion</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == clase)
                {
                    return profesor;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Una universidad y un profesor son iguales si este da clases en esa universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si da clases en esa universidad, false caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.profesores)
            {
                if (profesor == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Agrega un alumno si este no se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>la universidad con el nuevo alumno o sin este en caso que ya se encontraba en ella</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            foreach (Alumno b in g.alumnos)
            {
                if (b != a)
                {
                    g.alumnos.Add(a);
                }
            }

            return g;
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        ///clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        ///toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">EClases</param>
        /// <returns>Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesor = (g == clase);

            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno unAlumno in g.alumnos)
            {
                if (unAlumno == clase)
                {
                    jornada += unAlumno;
                }
            }
            g.jornada.Add(jornada);
            return g;
        }

        /// <summary>
        /// Agrega un profesor si este no se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>la universidad con el nuevo profesor o sin el en caso que ya se encontraba en ella</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p != i)
                {
                    g.profesores.Add(i);
                }
            }

            return g;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


    }
}

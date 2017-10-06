using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private List<Producto> _productos;
        private int _espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this._productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito concesionaria, ETipo tipoDeChanguito) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", concesionaria._productos.Count, concesionaria._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in concesionaria._productos)
            {
                switch(tipoDeChanguito)
                { 
                   case ETipo.Snacks:
                        if(v is Snacks)
                        sb.AppendLine(((Snacks)v).Mostrar());
                        break;
                    case ETipo.Dulce:
                        if(v is Dulce)
                        sb.AppendLine(((Dulce)v).Mostrar());
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                        sb.AppendLine(((Leche)v).Mostrar());
                        break;
                    case ETipo.Todos:
                        if(v is Snacks)
                        sb.AppendLine(((Snacks)v).Mostrar());
                        if(v is Dulce)
                        sb.AppendLine(((Dulce)v).Mostrar());
                        if(v is Leche)
                        sb.AppendLine(((Leche)v).Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
                if(c._productos.Count ==0)
                {
                        c._productos.Add(p);
                }
                else if(c._productos.Count < c._espacioDisponible)
                {
                    c._productos.Add(p);
                }

            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
           
            int cont = c._productos.Count;
            for (int i = 0; i <= cont; i++)
            {
                if (c._productos[i] == p)
                {
                    c._productos.RemoveAt(i);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}

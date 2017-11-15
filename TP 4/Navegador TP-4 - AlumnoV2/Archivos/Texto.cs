using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }
         
        public bool guardar(string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    while(!file.EndOfStream)
                    {
                        datos.Add(file.ReadLine());
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = default(List<string>);
                return false;
            }
        }
    }
}

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
        string camino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\";

        public bool guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.camino + archivo, true))
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
        public bool leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(this.camino + archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                datos = "";
                return false;
            }
        }
    }
}

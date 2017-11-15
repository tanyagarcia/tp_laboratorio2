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
                StreamWriter file = new StreamWriter(archivo, true);
                file.WriteLine(datos);
                file.Close();
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
                StreamReader file = new StreamReader(archivo);
                while (!file.EndOfStream)
                {
                    datos.Add(file.ReadLine());
                }
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException()
            : base()
        {
            this.mensajeBase = "Mensaje de error: DNI INVALIDO";
        }

        public DniInvalidoException(Exception e)
            : base(e.Message)
        {

        }

        public DniInvalidoException(string message)
            : base(message)
        {

        }

        public DniInvalidoException(string message, Exception e)
           : base(message, e)
        {

        }
    }
}

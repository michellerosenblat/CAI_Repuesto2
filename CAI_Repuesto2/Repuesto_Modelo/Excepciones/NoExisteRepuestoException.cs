using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Excepciones
{
    public class NoExisteRepuestoException : Exception
    {
        public NoExisteRepuestoException(int codRepuesto) : base("No existe repuesto con codigo " + codRepuesto) { }

        public NoExisteRepuestoException() : base("No existen respuestos") { }
    }
}

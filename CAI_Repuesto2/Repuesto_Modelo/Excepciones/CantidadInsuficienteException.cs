using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Excepciones
{
    public class CantidadInsuficienteException : Exception
    {
        public CantidadInsuficienteException(int codRepuesto) : base("No hay cantidad suficiente para el repuesto con codigo " + codRepuesto) { }
    }
}

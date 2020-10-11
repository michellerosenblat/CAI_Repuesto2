using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Excepciones
{
    public class NoExisteCategoriaException : Exception 
    {
        public NoExisteCategoriaException(int codCategoria) : base("No existe categoria con codigo " + codCategoria) { }
    }
}

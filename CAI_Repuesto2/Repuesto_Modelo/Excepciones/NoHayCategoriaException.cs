using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Excepciones
{
    public class NoHayCategoriaException : Exception
    {
        public NoHayCategoriaException() : base("No hay categorias creadas, cree una primero") { }
    }
}

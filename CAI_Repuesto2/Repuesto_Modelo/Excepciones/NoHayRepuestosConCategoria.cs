using Repuesto_Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Excepciones
{
    public class NoHayRepuestosConCategoria : Exception
    {
        public NoHayRepuestosConCategoria(Categoria cat) : base("No hay repuestos con la categoria " + cat.ToString()) { }
    }
}

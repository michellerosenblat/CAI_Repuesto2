using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Entidades
{
    public class Categoria
    {
        private int codigo;
        private string nombre;

        public Categoria(int codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public override bool Equals(object obj)
        {
            return (obj != null && obj is Categoria && this.codigo == ((Categoria)obj).Codigo);
        }
        public override string ToString()
        {
            return "Codigo " + this.codigo + " " + this.nombre;
        }
    }
}

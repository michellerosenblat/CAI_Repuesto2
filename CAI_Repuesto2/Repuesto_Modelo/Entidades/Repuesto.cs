using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repuesto_Modelo.Entidades
{
    public class Repuesto
    {
        private int codigo;
        private string nombre;
        private double precio;
        private int stock;
        private Categoria categoria;

        public Repuesto(int codigo, string nombre, double precio, int stock, Categoria categoria)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.categoria = categoria;
        }

        public override string ToString()
        {
            return codigo + " " + nombre + " Precio: " + precio + " Stock: " + stock;
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
        public int Stock
        {
            get
            {
                return this.stock;
            }
            set
            {
                this.stock = value;
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
        public Categoria Categoria
        {
            get
            {
                return this.categoria;
            }
            set
            {
                this.categoria = value;
            }
        }

        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
    }
}

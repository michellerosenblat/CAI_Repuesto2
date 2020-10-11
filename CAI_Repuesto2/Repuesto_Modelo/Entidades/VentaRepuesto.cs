using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repuesto_Modelo.Excepciones;

namespace Repuesto_Modelo.Entidades
{
    public class VentaRepuesto
    {
        private List<Repuesto> listaProductos;
        private string nombreComercio;
        private string direccion;
        List<Categoria> categoriasDisponibles;

        public VentaRepuesto(string nombre, string direccion)
        {
            this.nombreComercio = nombre;
            this.direccion = direccion;
            listaProductos = new List<Repuesto>();
            categoriasDisponibles = new List<Categoria>();
        }

        public void AgregarRepuesto(Repuesto repuesto)
        {
            listaProductos.Add(repuesto);
        }
        public void AgregarRepuesto(string nombre, double precio, int stock, Categoria categoria)
        {
            AgregarRepuesto(new Repuesto(ProximoCodRepuesto(), nombre, precio, stock, categoria));
        }
                
         public List <Repuesto> TraerPorCategoria(int codCategoria)
         {
            List<Repuesto> repuestosConCategoria;
            Categoria cat = BuscarCategoria(codCategoria);
            repuestosConCategoria = listaProductos.FindAll(r => r.Categoria == cat);
            if (repuestosConCategoria is null)
            {
                throw new NoHayRepuestosConCategoria(cat);
            }
            else
            {
                return repuestosConCategoria;
            }
         }

        public void EliminarStock(int codRepuesto, int cantidad)
        {
            Repuesto repuesto = BuscarRepuesto(codRepuesto);
            if (repuesto.Stock >= cantidad)
            {
                repuesto.Stock -= cantidad;
            }
            else
            {
                throw new CantidadInsuficienteException(codRepuesto);
            }
        }
        public void AgregarStock(int codRepuesto, int cantidad)
        {
            BuscarRepuesto(codRepuesto).Stock += cantidad;
        }
        public void EliminarRepuesto(int codRepuesto)
        {
               listaProductos.Remove(BuscarRepuesto(codRepuesto));
        }
        public void ModificarRepuesto(int codRepuesto, string nombre, double precio)
        {
            Repuesto repuestoAModificar = BuscarRepuesto(codRepuesto);
            repuestoAModificar.Nombre = nombre;
            repuestoAModificar.Precio = precio;
        }
        public Repuesto BuscarRepuesto(int codRepuesto)
        {
            Repuesto repuesto;
            if (listaProductos.Any())
            {
                repuesto= listaProductos.Find(c => c.Codigo == codRepuesto);
            }
            else
            {
                throw new NoExisteRepuestoException(codRepuesto);
            }
            if (repuesto is null)
            {
                throw new NoExisteRepuestoException(codRepuesto);
            }
            else
            {
                return repuesto;
            }
        }
        public Categoria BuscarCategoria(int codCategoria)
        {
            Categoria cat;
            if (categoriasDisponibles.Any())
            {
                cat = categoriasDisponibles.Find(c => c.Codigo == codCategoria);
                 if(cat is null)
                {
                    throw new NoExisteCategoriaException(codCategoria);
                }
                 else
                {
                    return cat;
                }
            }
            else
            {
                throw new NoHayCategoriaException();
            }
        }

        public void AgregarCategoria(string nombreCat)
        {
            categoriasDisponibles.Add(new Categoria(ProximoCodCategoria(), nombreCat));
        }

        public List<Categoria> GetCategorias()
        {
            return categoriasDisponibles;
        }
        public List<Repuesto> GetRepuestos()
        {
            return listaProductos;
        }


        private int ProximoCodCategoria()
        {
            if (categoriasDisponibles.Any())
            {
                return categoriasDisponibles.Max(c => c.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private int ProximoCodRepuesto()
        {
            if (listaProductos.Any())
            {
                return listaProductos.Max(c => c.Codigo) + 1 ;
            }
            else
            {
                return 1;
            }
        }
    }
}

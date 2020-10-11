using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repuesto_Modelo;
using Repuesto_Modelo.Entidades;
using CAI_Repuesto2.Validaciones;
using Repuesto_Modelo.Excepciones;

namespace CAI_Repuesto2
{
    class Program
    {
        static void Main(string[] args)
        {
            VentaRepuesto negocio = new VentaRepuesto("Autopartes", "Warnes 1111");
            int opcionMenu;
            int codRepuesto;
            int codCategoria;
            string nombre;
            double precio;
            int cantidad;
            try
            {
                do
                {
                    DesplegarMenu();
                    opcionMenu = Validacion.PedirInt("opcion de menu deseada");
                    switch (opcionMenu)
                    {
                        case 0:
                            nombre = Validacion.PedirString("nombre de la categoria a agregar");
                            negocio.AgregarCategoria(nombre);
                            break;
                        case 1:
                            nombre = Validacion.PedirString("nombre del repuesto a agregar");
                            precio = Validacion.PedirDouble("precio del repuesto");
                            int stock = Validacion.PedirInt("stock del producto");
                            try
                            {

                                ListarCategoriasDe(negocio);
                               codCategoria = Validacion.PedirInt("el codigo de la categoria a elegir");
                                Categoria categoria = negocio.BuscarCategoria(codCategoria);
                                negocio.AgregarRepuesto(nombre, precio, stock, categoria);

                            }
                            catch (Repuesto_Modelo.Excepciones.NoExisteCategoriaException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Repuesto_Modelo.Excepciones.NoHayCategoriaException ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                            break;
                        case 2:
                            try {
                                ListarRepuestoDe(negocio);
                                codRepuesto = Validacion.PedirInt("código de repuesto a modificar");
                                Repuesto repuestoAModificar = negocio.BuscarRepuesto(codRepuesto);
                                Console.WriteLine(repuestoAModificar.Nombre);
                                nombre = Validacion.PedirStringOEnter("nombre a modificar o enter si no quiere hacerlo", repuestoAModificar.Nombre);
                                precio = Validacion.PedirDoubleOEnter("precio a modificar o enter si no quiere hacerlo", repuestoAModificar.Precio);
                                negocio.ModificarRepuesto(codRepuesto, nombre, precio);
                                Console.WriteLine(negocio.BuscarRepuesto(codRepuesto).ToString());
                            }
                           
                            catch (Repuesto_Modelo.Excepciones.NoExisteRepuestoException ex )
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 3:
                            ListarRepuestoDe(negocio);
                            codRepuesto = Validacion.PedirInt("código de repuesto a eliminar");
                            Repuesto repuestoAEliminar = negocio.BuscarRepuesto(codRepuesto);
                            Console.WriteLine("Esta de acuerdo con eliminar " + repuestoAEliminar.ToString());
                            nombre = Validacion.PedirSoN("S si esta de acuerdo, N si no lo está");
                            switch (nombre)
                            { 
                                case "S":
                                    negocio.EliminarRepuesto(codRepuesto);
                                    break;
                                case "N":
                                    break;
                                    
                            }
                            break;
                        case 4:
                            //Agregar stock
                            try
                            {
                                ListarRepuestoDe(negocio);
                                codRepuesto = Validacion.PedirInt("código de repuesto a agregar stock");
                                cantidad = Validacion.PedirInt("cantidad de stock a agregar");
                                negocio.AgregarStock(codRepuesto, cantidad);
                            }
                            catch (NoExisteRepuestoException ex) {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 5:
                            //borrar stock
                            try
                            {
                                ListarRepuestoDe(negocio);
                                codRepuesto = Validacion.PedirInt("código de repuesto a eliminar stock");
                                cantidad = Validacion.PedirInt("cantidad de stock a eliminar");
                                negocio.EliminarStock(codRepuesto, cantidad);
                            }
                            catch (NoExisteRepuestoException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (CantidadInsuficienteException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 6:
                            try { 
                            ListarCategoriasDe(negocio);
                             codCategoria = Validacion.PedirInt("código de categoria a buscar");
                            List <Repuesto> listaRepuestos = negocio.TraerPorCategoria(codCategoria);
                                ListarRepuestos(listaRepuestos);
                            }
                            catch (NoExisteCategoriaException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (NoHayRepuestosConCategoria ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (NoExisteRepuestoException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        default:
                            break;
                    }
                }
                while (opcionMenu != 7);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void DesplegarMenu()
        {
            Console.WriteLine("Ingrese 0 para agregar categoria");
            Console.WriteLine("Ingrese 1 para agregar repuesto");
            Console.WriteLine("Ingrese 2 para modificar repuesto");
            Console.WriteLine("Ingrese 3 para eliminar repuesto");
            Console.WriteLine("Ingrese 4 para agregar stock");
            Console.WriteLine("Ingrese 5 para eliminar stock");
            Console.WriteLine("Ingrese 6 para buscar repuestos por categoria");
            Console.WriteLine("Ingrese 7 para salir");

        }
        public static void ListarCategoriasDe(VentaRepuesto negocio)
        {
            List<Categoria> categorias = negocio.GetCategorias();
            if (categorias.Any())
            {
                foreach (Categoria c in categorias)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else
            {
                throw new Repuesto_Modelo.Excepciones.NoHayCategoriaException();
            }
        }

        public static void ListarRepuestos(List <Repuesto> rep)
        {
           if (rep.Any())
            {
                foreach (Repuesto r in rep)
                {
                    Console.WriteLine(r.ToString());
                }
            }
            else
            {
                throw new Repuesto_Modelo.Excepciones.NoExisteRepuestoException();
            }
        }

        public static void ListarRepuestoDe(VentaRepuesto negocio)
        {
            List<Repuesto> repuestos = negocio.GetRepuestos();
            if (repuestos.Any())
            {
                foreach (Repuesto c in repuestos)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            else
            {
                throw new Repuesto_Modelo.Excepciones.NoExisteRepuestoException();
            }
        }
    }
}

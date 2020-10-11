using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Repuesto2.Validaciones
{
    public static class Validacion
    {
        public static string PedirString(string mensaje)
        {
            string input = "";
            do
            {
                Console.WriteLine("Ingrese " + mensaje);
                input = Console.ReadLine();
            }
            while (input == "");
            return input;
        }

        public static int PedirInt(string mensaje)
        {
            int input;
            do
            {
                Console.WriteLine("Ingrese " + mensaje);
            }
            while (!int.TryParse(Console.ReadLine(), out input));
            return input;
        }

        public static double PedirDouble(string mensaje)
        {
            double input;
            do
            {
                Console.WriteLine("Ingrese " + mensaje);
            }
            while (!double.TryParse(Console.ReadLine(), out input));
            return input;
        }

        public static string PedirStringOEnter(string mensaje, string inputDefault)
        {
            string input;
            Console.WriteLine("Ingrese " + mensaje);
            input = Console.ReadLine();
            if (input == "")
            {
                input = inputDefault;
            }
            return input;
        }
        public static double PedirDoubleOEnter(string mensaje, double inputDefault)
        {
            string inputAConvertir;
            double input;
            do
            {
                Console.WriteLine("Ingrese " + mensaje);
                inputAConvertir = Console.ReadLine();
            }
            while (!double.TryParse(inputAConvertir, out input) && inputAConvertir != "");
            if (inputAConvertir == "")
            {
                input = inputDefault;
            }
            return input;
        }
        public static string PedirSoN(string mensaje)
        {
            string input = "";
            do
            {
                Console.WriteLine("Ingrese " + mensaje);
                input = Console.ReadLine();
            }
            while (input != "S" || input != "N");
            return input;
        }
    }
}

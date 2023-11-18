using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculateHandler calcHandler;

            Console.WriteLine("Grundrechnungsarten");

            calcHandler = new CalculateHandler(OperatorMethods.Add);
            //calcHandler = OperatorMethods.Modulo;
            double erg = calcHandler(5, 3);

            Console.WriteLine($"erg={erg}");

            Console.ReadLine();
        }
    }
}

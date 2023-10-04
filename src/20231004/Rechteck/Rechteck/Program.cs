using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechteck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            int auswahl;

            Console.WriteLine("Rechteck");
            Console.Write("Laenge Seite a eingeben: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Laenge Seite b eingeben: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nBitte auswaehlen");
            Console.WriteLine("================");
            Console.WriteLine("1 - Flaeche berechnen");
            Console.WriteLine("2 - Umfang berechnen");
            
            Console.Write("\nIhre Wahl: ");
            auswahl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");

            switch (auswahl)
            {
                case 1:
                    int flaeche = a * b;
                    //Console.Clear();
                    Console.WriteLine($"Der Flaecheninhalt betraegt {flaeche} m²");
                    break;

                case 2:
                    int umfang = (a + b) * 2;
                    //Console.Clear();
                    Console.WriteLine($"Der Umfang betraegt {umfang} m");
                    break;

                default:
                    Console.WriteLine("Auswahl ungueltig");
                    break;
            }
            //Console.WriteLine($"Seite a: {a}, Seite b:{b}");
            Console.ReadKey();
        }
    }
}

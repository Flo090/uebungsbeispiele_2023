using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometrischeFiguren
{
    internal class Program
    {
        static void ausgabeHeader(string title)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(new string('*', Console.WindowWidth));
            }

            // Berechnungen Cursor-Position
            int xPosHeader = Console.WindowWidth / 2 - title.Length / 2;
            // Cursor-Position manuell setzen
            Console.SetCursorPosition(xPosHeader, 1);
            Console.Write(title);
            Console.SetCursorPosition(0, 3);
        }
        static void Main(string[] args)
        {
            //****************************************
            //*********Geometrische Figuren***********
            //****************************************
            //
            //  Uebersicht
            //  ==========
            //  1-Parallelogramm
            //  2-Trapez
            //  
            //  Ihre Wahl:
            //  -----------------------------------
            //  Eingabe je nach Geometrischer Figur...
            //  Anschließend Ausgabe Umfang und Flächeninhalt...

            // Parallelogramm
            double parallelogrammSeiteA;
            double parallelogrammSeiteB;
            double parallelogrammHoeheA;
            double parallelogrammFlaeche;
            double parallelogrammUmfang;
            
            // Trapez
            double trapezSeiteA;
            double trapezSeiteB;
            double trapezSeiteC;
            double trapezSeiteD;
            double trapezHoehe;
            double trapezFlaeche;
            double trapezUmfang;

            // Auswahl Figur
            int auswahl;
            
            // Ueberschriften
            string title = "Geometrische Figuren";
            string ueberschrift = "Uebersicht";

            // Titel ausgeben mit Formatierung
            ausgabeHeader(title);
            // Auswahl
            Console.WriteLine("\n" + ueberschrift);
            Console.WriteLine(new string('=', ueberschrift.Length));
            Console.WriteLine("1 - Parallelogramm");
            Console.WriteLine("2 - Trapez");

            // Auswahl einlesen
            Console.Write("\nIhre Wahl: ");
            auswahl = int.Parse(Console.ReadLine());

            // Abfrage mit if
            if (auswahl == 1)
            {
                // Parallelogramm
                // Eingabe
                Console.Write("\nSeite a: ");
                parallelogrammSeiteA = double.Parse(Console.ReadLine());
                Console.Write("Seite b: ");
                parallelogrammSeiteB = double.Parse(Console.ReadLine());
                Console.Write("Hoehe ha: ");
                parallelogrammHoeheA = double.Parse(Console.ReadLine());

                // Berechnung
                parallelogrammUmfang = (parallelogrammSeiteA + parallelogrammSeiteB) * 2;
                parallelogrammFlaeche = parallelogrammSeiteA * parallelogrammHoeheA;

                // Ausgabe der Ergebnisse
                Console.WriteLine($"\nDer Umfang betraegt: {parallelogrammUmfang} m");
                Console.WriteLine($"Der Flaecheninhalt betraegt: {parallelogrammFlaeche} m²");
            }
            else if (auswahl == 2)
            {
                // Trapez
                // Eingabe
                Console.Write("\nSeite a: ");
                trapezSeiteA = double.Parse(Console.ReadLine());
                Console.Write("Seite b: ");
                trapezSeiteB = double.Parse(Console.ReadLine());
                Console.Write("Seite c: ");
                trapezSeiteC = double.Parse(Console.ReadLine());
                Console.Write("Seite d: ");
                trapezSeiteD = double.Parse(Console.ReadLine());
                Console.Write("Hoehe h: ");
                trapezHoehe = double.Parse(Console.ReadLine());

                // Berechnung
                trapezUmfang = trapezSeiteA + trapezSeiteB + trapezSeiteC + trapezSeiteD;
                trapezFlaeche = (trapezSeiteA + trapezSeiteC) * trapezHoehe / 2;

                // Ausgabe der Ergebnisse
                Console.WriteLine($"\nDer Umfang betraegt: {trapezUmfang} m");
                Console.WriteLine($"Der Flaecheninhalt betraegt: {trapezFlaeche} m²");
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe");
            }

        }
    }
}

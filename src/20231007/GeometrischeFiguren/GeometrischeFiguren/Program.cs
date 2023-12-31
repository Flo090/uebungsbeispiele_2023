﻿using System;
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
                // Schriftfarbe vor Ausgabe ändern
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(new string('*', Console.WindowWidth));
            }

            // Berechnungen Cursor-Position
            int xPosHeader = Console.WindowWidth / 2 - title.Length / 2;
            // Cursor-Position manuell setzen
            Console.SetCursorPosition(xPosHeader, 1);
            // Vor Ausgabe Schriftfarbe umändern
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(title);
            Console.SetCursorPosition(0, 3);
        }
        static void zeichneParallelogramm()
        {
            int hoehe = 5;
            int breite = 10;
            int einrückung = 0;

            Console.WriteLine("\nParallelogramm\n");
            Console.ForegroundColor = ConsoleColor.Green;   // Farbe setzen

            for (int zeile = 0; zeile < hoehe; zeile++)
            {
                Console.Write(new string(' ', einrückung));
                for (int spalte = 0; spalte < breite; spalte++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                einrückung++;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;   // Farbe zurücksetzen
        }
        static void zeichneTrapez()
        {
            int hoehe = 4;
            int breiteOben = 6;
            int breiteUnten = 12;
            int einrückung = 0;
            int breiteAktuell = breiteOben;

            Console.WriteLine("\nTrapez\n");
            Console.ForegroundColor = ConsoleColor.Green;   // Farbe setzen

            for (int zeile = 0; zeile < hoehe; zeile++)
            {
                Console.Write(new string(' ', (breiteUnten - breiteOben) / 2 - einrückung));
                for (int spalte = 0; spalte < breiteAktuell; spalte++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                einrückung++;
                breiteAktuell += 2;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;   // Farbe zurücksetzen
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


            // Variablen Deklaration & Initialisierung
            // Parallelogramm
            double parallelogrammSeiteA = 0.0;
            double parallelogrammSeiteB = 0.0;
            double parallelogrammHoeheA = 0.0;
            double parallelogrammFlaeche = 0.0;
            double parallelogrammUmfang = 0.0;
            // Trapez
            double trapezSeiteA = 0.0;
            double trapezSeiteB = 0.0;
            double trapezSeiteC = 0.0;
            double trapezSeiteD = 0.0;
            double trapezHoehe = 0.0;
            double trapezFlaeche = 0.0;
            double trapezUmfang = 0.0;
            // Auswahl Figur (nur positive Zahlen)
            uint auswahl = 0;
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

            try
            {
                auswahl = uint.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n" + ex.Message + "\nProgramm wird beendet.\n");
                Environment.Exit(1);
            }

            Console.WriteLine(new string('-', 13));

            // Abfrage mit if
            if (auswahl == 1)
            {
                // Parallelogramm zeichnen
                zeichneParallelogramm();

                // Eingabe
                try
                {
                    Console.Write("\nSeite a: ");
                    parallelogrammSeiteA = double.Parse(Console.ReadLine());
                    Console.Write("Seite b: ");
                    parallelogrammSeiteB = double.Parse(Console.ReadLine());
                    Console.Write("Hoehe ha: ");
                    parallelogrammHoeheA = double.Parse(Console.ReadLine());
                }
                catch (Exception ex)    // Alle Exceptions behandeln
                {
                    Console.WriteLine("\n" + ex.Message + "\nProgramm wird beendet.\n");
                    Environment.Exit(1);
                }

                // Überprüfung ob ein negativer Wert vorhanden ist
                if (parallelogrammSeiteA <= 0 || parallelogrammSeiteB <= 0 || parallelogrammHoeheA <= 0)
                {
                    Console.WriteLine($"\nEingabe einer negativen Zahl nicht erlaubt !!!\nProgramm wird beendet.\n");
                    Environment.Exit(1);
                }

                // Berechnung
                parallelogrammUmfang = (parallelogrammSeiteA + parallelogrammSeiteB) * 2;
                parallelogrammFlaeche = parallelogrammSeiteA * parallelogrammHoeheA;

                // Ausgabe der Ergebnisse
                Console.WriteLine($"\nDer Umfang betraegt: {parallelogrammUmfang} m");
                Console.WriteLine($"Der Flaecheninhalt betraegt: {parallelogrammFlaeche} m²\n");
            }
            else if (auswahl == 2)
            {
                // Trapez zeichnen
                zeichneTrapez();

                // Eingabe
                try
                {
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
                }
                catch (Exception ex)    // Alle Exceptions behandeln
                {
                    Console.WriteLine("\n" + ex.Message + "\n");
                    Environment.Exit(1);
                }

                // Überprüfung ob ein negativer Wert vorhanden ist
                if (trapezSeiteA <= 0 || trapezSeiteB <= 0 || trapezSeiteC <= 0 || trapezSeiteD <= 0 || trapezHoehe <= 0)
                {
                    Console.WriteLine($"\nEingabe einer negativen Zahl nicht erlaubt !!!\n Programm wird beendet.\n");
                    Environment.Exit(1);
                }

                // Berechnung
                trapezUmfang = trapezSeiteA + trapezSeiteB + trapezSeiteC + trapezSeiteD;
                trapezFlaeche = (trapezSeiteA + trapezSeiteC) * trapezHoehe / 2;

                // Ausgabe der Ergebnisse
                Console.WriteLine($"\nDer Umfang betraegt: {trapezUmfang} m");
                Console.WriteLine($"Der Flaecheninhalt betraegt: {trapezFlaeche} m²\n");
            }
            else
            {
                Console.WriteLine($"Ungültige Eingabe: {auswahl}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Globalization;

namespace Teilnehmerverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Teilnehmerverwaltung
            //Schreiben Sie eine Applikation welche Teilnehmerdaten einlesen kann.Die Teilnehmer Daten
            //sollen nach Abschluss der Eingaben auf dem Bildschirm formatiert dargestellt werden.

            //Anforderungen
            //Eingabe Name, Vorname, Geburtsdatum pro Teilnehmer
            //Validierung der Daten auf Gültigkeit => keine Abstürze
            //Verwenden Sie in der Ein-und Ausgabe Farben
            //Achten Sie auf eine klare Benutzerführung

            // Variablen
            string name = string.Empty;
            string vorname = string.Empty;
            string input = string.Empty;
            DateTime geburtsdatum = DateTime.MinValue;

            // Header
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Teilnehmerverwaltung\n");
            Console.ResetColor();
            
            // Einlesen Daten
            Console.WriteLine("Daten eingeben\n");
            
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            name = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Vorname: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            vorname = Console.ReadLine();
            Console.ResetColor();

            Console.Write("Geburtsdatum (dd.MM.yyyy): ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            input = Console.ReadLine();
            Console.ResetColor();

            try
            {
                geburtsdatum = DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\aERROR: Datum hat falsches Format !!!");
                geburtsdatum = DateTime.MinValue;
                Console.ResetColor();

                // Programm beenden
                return;
            }

            // Forsetzung des Programms, falls Datum korrektes Format hat
            // Prüfen, ob Alter im Rahmen von 16-95 ist
            if (!(geburtsdatum.Year >= DateTime.Now.Year - 95 && geburtsdatum.Year <= DateTime.Now.Year - 16))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\aERROR: Ausserhalb des gültigen Altersbereich von 16-95 !!!");
                Console.ResetColor();
                return;
            }
            else
            {
                // Ausgabe der Daten
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDaten des Teilnehmers:");
                Console.WriteLine($"Name:          {name}");
                Console.WriteLine($"Vorname:       {vorname}");
                Console.WriteLine($"Geburtsdatum:  {geburtsdatum.ToLongDateString()}");
                Console.ResetColor();
            }
        }
    }
}
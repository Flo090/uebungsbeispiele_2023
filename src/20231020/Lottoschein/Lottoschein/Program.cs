using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lottoschein
{
    //Implementieren Sie eine Applikation, welches zum Ausfüllen von Lotto(6 aus 45) Scheinen benutzt werden kann!
    //Folgende Anforderungen gilt es dabei zu beachten:

    //Anforderungen
    // - die Applikation erfragt vom User, wie viele Zahlen-Blöcke ermittelt werden sollen, Anzahl = x
    // - die Applikation erstellt über einen Zufallsgenerator x gültige Zahlen-Blöcke(6 aus 45)
    // - die Zahlen-Blöcke sollen formatiert ausgegeben(Analog Lotto-Schein)
    // - sämtliche Eingaben sind Fehlertolerant umzusetzen
    // - setzen Sie Methoden ein wo sinnvoll
    // - verwenden Sie Farben für die Ein- und Ausgabe
    internal class Program
    {
        const int ANZAHL_LOTTOZAHLEN_ZIEHUNG = 6;
        const int ANZAHL_LOTTOZAHLEN_GESAMT = 45;
        static void Main(string[] args)
        {
            // Deklaration & Initialisierung
            int anzahlZahlenbloecke = 0;
            int[,] zahlenblock;                     // [zeile, spalte]
            // Titel
            string titel = " Lotto 6 aus 45 ";
            // Zufallszahl
            Random zufallszahl = new Random();      

            // Header
            WriteHeader(titel, ConsoleColor.Blue);

            // Anzahl Zahlenblöcke durch User-Eingabe
            anzahlZahlenbloecke = RueckgabeAnzahlZahlenbloecke();
            zahlenblock = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG, anzahlZahlenbloecke];

            // Zahlenbloecke erstellen
            ErstelleZahlenbloecke(zahlenblock, zufallszahl);

            // Ausgabe
            AusgabeZahlenbloecke(zahlenblock);
        }

        private static void AusgabeZahlenbloecke(int[,] zahlenblock)
        {
            int anzahlZahlenbloecke = zahlenblock.GetLength(1);
            int[] lottozahlen = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG];

            for (int spalte = 0; spalte < anzahlZahlenbloecke; spalte++)                           // Alle Zahlenblöcke durchlaufen
            {
                for (int zeile = 0; zeile < ANZAHL_LOTTOZAHLEN_ZIEHUNG; zeile++)
                {
                    lottozahlen[zeile] = zahlenblock[zeile, spalte];                     
                }

                for (int i = 1; i < ANZAHL_LOTTOZAHLEN_GESAMT + 1; i++)
                {
                    if (lottozahlen.Contains(i))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (i % 6 == 0)
                    {
                        Console.Write(i);
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    else
                    {
                        if (i < 10)
                        {
                            Console.Write(i);
                            Console.ResetColor();
                            Console.Write("  ");
                        }
                        else
                        {
                            Console.Write(i);
                            Console.ResetColor();
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine("\n");
            }
        }

        private static void ErstelleZahlenbloecke(int[,] zahlenblock, Random zufallszahl)
        {
            int anzahlZahlenbloecke = zahlenblock.GetLength(1);
            int[] lottozahlen = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG];

            for (int spalte = 0; spalte < anzahlZahlenbloecke; spalte++)
            {
                lottozahlen = ErstelleZahlenblock(zufallszahl);

                for (int zeile = 0; zeile < ANZAHL_LOTTOZAHLEN_ZIEHUNG; zeile++)
                {
                    zahlenblock[zeile, spalte] = lottozahlen[zeile];
                }
            }
        }

        private static int[] ErstelleZahlenblock(Random zufallszahl)
        {
            int[] lottozahlen = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG];
            //zufallszahl = new Random();                               // Fehler
            
            for (int i = 0; i < ANZAHL_LOTTOZAHLEN_ZIEHUNG; i++)        // Lottozahl generieren (6 aus 45)
            {
                int zahl = 0;

                // Zufallszahl erzeugen, die noch nicht im Array enthalten ist
                do
                {
                    zahl = zufallszahl.Next(1, ANZAHL_LOTTOZAHLEN_GESAMT + 1);
                }
                while (lottozahlen.Contains(zahl));

                lottozahlen[i] = zahl;
            }
            return lottozahlen;
        }

        private static int RueckgabeAnzahlZahlenbloecke()
        {
            int anzahl = 0;
            bool exception = false;

            // Einlesen der Anzahl von Zahlenbloecken
            do
            {
                Console.ResetColor();
                Console.Write("Bitte geben Sie die Anzahl der Zahlenbloecke ein: ");
                Console.ForegroundColor = ConsoleColor.Blue;

                try
                {
                    anzahl = int.Parse(Console.ReadLine());

                    if ((anzahl < 1 || anzahl > 12))
                    {
                        exception = true;
                    }
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Ungültige Eingabe!!!");
                    Console.ResetColor();
                }

                if (exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: Zahl muss zwischen 1 und 12 sein!!!");
                    Console.ResetColor();
                    exception = false;
                }
            }
            while (!(anzahl >= 1 && anzahl <= 12));

            Console.ResetColor();
            Console.WriteLine("\n");

            return anzahl;
        }

        private static void WriteHeader(string titel, ConsoleColor schriftfarbe)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(new string('-', Console.WindowWidth));

            // Farbe setzen
            Console.ForegroundColor = schriftfarbe;

            // Cursor-Position setzen
            Console.SetCursorPosition((Console.WindowWidth - titel.Length) / 2, 1);
            Console.WriteLine(titel);

            // Farbe zurücksetzen
            Console.ResetColor();

            // Cursor-Position zurücksetzen
            Console.SetCursorPosition(0, 4);
        }
    }
}

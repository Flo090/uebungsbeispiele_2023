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
            int anzahlZahlenbloecke = 0;
            int[,] zahlenblock;                     // [zeile, spalte]
            
            string titel = " Lotto 6 aus 45 ";      // Titel
           
            Random zufallszahl = new Random();      // Zufallszahl

            // Header
            writeHeader(titel);

            // Anzahl Zahlenblöcke durch User-Eingabe
            anzahlZahlenbloecke = uebergabeAnzahlZahlenbloecke();
            zahlenblock = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG, anzahlZahlenbloecke];

            // Zahlenbloecke erstellen
            erstelleZahlenbloecke(anzahlZahlenbloecke, zahlenblock, zufallszahl);

            // Ausgabe
            ausgabeZahlenbloecke(anzahlZahlenbloecke, zahlenblock);
        }

        private static void ausgabeZahlenbloecke(int anzahlZahlenbloecke, int[,] zahlenblock)
        {
            int[] lottozahlen = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG];

            for (int j = 0; j < anzahlZahlenbloecke; j++)
            {
                for (int zeile = 0; zeile < ANZAHL_LOTTOZAHLEN_ZIEHUNG; zeile++)
                {
                    lottozahlen[zeile] = zahlenblock[zeile, j];
                }

                for (int i = 1; i < ANZAHL_LOTTOZAHLEN_GESAMT + 1; i++)
                {
                    if (lottozahlen.Contains(i))
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
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
                            Console.Write(i + "  ");
                        }
                        else
                        {
                            Console.Write(i + " ");
                        }
                    }
                    Console.ResetColor();
                }
                Console.WriteLine("\n");
            }
        }

        public static void erstelleZahlenbloecke(int anzahlZahlenbloecke, int[,] zahlenblock, Random zufallszahl)
        {
            for (int spalte = 0; spalte < anzahlZahlenbloecke; spalte++)
            {
                int[] meinZahlenBlock = new int[ANZAHL_LOTTOZAHLEN_ZIEHUNG];
                meinZahlenBlock = erstelleZahlenblock(zufallszahl);

                for (int zeile = 0; zeile < ANZAHL_LOTTOZAHLEN_ZIEHUNG; zeile++)
                {
                    zahlenblock[zeile, spalte] = meinZahlenBlock[zeile];
                }
            }
        }

        private static int[] erstelleZahlenblock(Random zufallszahl)
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

        private static int uebergabeAnzahlZahlenbloecke()
        {
            int anzahl = 0;

            // Einlesen der Anzahl von Zahlenbloecken
            do
            {
                Console.Write("Bitte geben Sie die Anzahl der Zahlenbloecke ein: ");
                
                try
                {
                    anzahl = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("ERROR: Ungültige Eingabe!!!");
                }
            }
            while (!(anzahl >= 1 && anzahl <= 12));

            Console.WriteLine("\n");

            return anzahl;
        }

        private static void writeHeader(string titel)
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(new string('-', Console.WindowWidth));

            // Cursor-Position setzen
            Console.SetCursorPosition((Console.WindowWidth - titel.Length) / 2, 1);
            Console.WriteLine(titel);

            // Cursor-Position zurücksetzen
            Console.SetCursorPosition(0, 4);
        }
    }
}

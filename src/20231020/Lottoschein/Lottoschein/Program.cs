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
        static void Main(string[] args)
        {
            int anzahlZahlenbloecke = -1;
            string titel = " Lotto 6 aus 45 ";
            const int ANZAHL_LOTTOZAHLEN = 6;
            int[,] zahlenblock;                     // [zeile, spalte]

            // Header
            writeHeader(titel);

            // Anzahl Zahlenblöcke durch User-Eingabe
            anzahlZahlenbloecke = uebergabeAnzahlZahlenbloecke();
            zahlenblock = new int[ANZAHL_LOTTOZAHLEN, anzahlZahlenbloecke];

            // Zahlenbloecke erstellen
            erstelleZahlenbloecke(anzahlZahlenbloecke, zahlenblock);

            // Ausgabe
            ausgabeZahlenbloecke(anzahlZahlenbloecke, zahlenblock);
        }

        private static void ausgabeZahlenbloecke(int anzahlZahlenbloecke, int[,] zahlenblock)
        {
            /*for (int spalte = 0; spalte < anzahlZahlenbloecke; spalte++)
            {
                for (int zeile = 0; zeile < 6; zeile++)
                {
                    Console.WriteLine(zahlenblock[zeile, spalte]);
                }
            }*/

            int[] lottozahlen = new int[6];

            for (int j = 0; j < anzahlZahlenbloecke; j++)
            {
                for (int zeile = 0; zeile < 6; zeile++)
                {
                    lottozahlen[zeile] = zahlenblock[zeile, j];
                }

                for (int i = 1; i < 46; i++)
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

        public static void erstelleZahlenbloecke(int anzahlZahlenbloecke, int[,] zahlenblock)
        {
            for (int spalte = 0; spalte < anzahlZahlenbloecke; spalte++)
            {
                int[] meinZahlenBlock = new int[6];
                meinZahlenBlock = erstelleZahlenblock();

                for (int zeile = 0; zeile < 6; zeile++)
                {
                    zahlenblock[zeile, spalte] = meinZahlenBlock[zeile];
                }
            }
        }

        private static int[] erstelleZahlenblock()
        {
            int[] lottozahlen = new int[6];
            Random zufallszahl = new Random();
            int zahl = 0;
            
            // Lottozahl generieren (6 aus 45)
            for (int i = 0; i < 6; i++)
            {
                // Zufallszahl erzeugen, die noch nicht im Array enthalten ist
                do
                {
                    zahl = zufallszahl.Next(1, 46);
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

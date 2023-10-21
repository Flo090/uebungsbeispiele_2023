using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TeilnehmerVerwaltung_v2
{
    internal class Program
    {
        // Implementieren Sie eine Applikation mit der beliebig viele Teilnehmerdaten erfasst und dargestellt
        // werden können. Folgende Anforderung sollen dabei erfüllt werden:

        // - max.Anzahl der Teilnehmer soll zu Beginn vom User abgefragt werden
        // - Einlesen folgender Daten:
        //     - Name, Vorname
        //     - Geburtsdatum
        //     - PLZ, Ort
        // - Fehlertolerante Eingaben
        // - verwenden sie Methoden wo sinnvoll
        // - verwenden sie Farben
        // - Teilnehmerdaten sollen nach der Eingabe tabellarisch ausgegeben werden

        static void Main(string[] args)
        {
            int teilnehmerCount = 0;
            Teilnehmer teilnehmer = new Teilnehmer();
            Teilnehmer[] teilnehmerListe;
            string headerText = "Teilnehmer Verwaltung v2.0   (c) 2023 Wifi-Soft";

            // Header
            CreateHeader(headerText, ConsoleColor.Yellow, true);

            // Abfrage Anzahl Teilnehmer
            teilnehmerCount = ReadInt("Bitte Anzahl Teilnehmer eingeben: ");

            // TeilnehmerListe vorbereiten
            teilnehmerListe = new Teilnehmer[teilnehmerCount];

            // Daten einlesen
            Console.WriteLine("Bitte geben Sie die Teilnehmerdaten ein: ");

            for (int i = 0; i < teilnehmerListe.Length; i++)
            {
                Console.WriteLine($"\nTeilnehmer {i + 1} / {teilnehmerListe.Length}: ");
                // TODO: Die GetStudentInfos() Methode kann auch überladen werden, damit Sie eine ganze Liste einliest ...
                teilnehmerListe[i] = GetStudentInfos();
            }

            // Ausgabe der Daten
            Console.WriteLine("\nDie Teilnehmerdaten: \n");
            DisplayStudentInfo(teilnehmerListe);
            // TODO: Implement JSON and XML format too !!!
            SaveStudentInfosToFile(teilnehmerListe, "meineTeilnehmerDaten", TextFileFormat.Xml);
        }

        private static void SaveStudentInfosToFile(Teilnehmer[] students, string filename, TextFileFormat fileFormat)
        {
            // TODO: Wie funktioniert StreamReader?
            
            if (fileFormat == TextFileFormat.Csv)
            {
                filename = filename + ".csv";

                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        string dataLine = $"{students[i].Name}, {students[i].Nachname}, {students[i].Geburtsdatum.ToShortDateString()}, {students[i].Plz}, {students[i].Ort}";
                        sw.WriteLine(dataLine);
                    }
                }
            }
            else if (fileFormat == TextFileFormat.Json)
            {
                string jsonString = string.Empty;

                filename = filename + ".json";

                using (StreamWriter sw = new StreamWriter(filename, false))
                {
                    List<Teilnehmer> studentList = new List<Teilnehmer>();

                    for (int i = 0; i < students.Length; i++)
                    {
                        studentList.Add(students[i]);;     
                    }
                    jsonString = JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented);    // Newtonsoft.Json
                    sw.WriteLine(jsonString);
                }

            }
            else if (fileFormat == TextFileFormat.Xml)
            {
                filename = filename + ".xml";

                using (XmlWriter xmlWriter = XmlWriter.Create(filename))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Teilnehmer");

                    for (int i = 0; i < students.Length; i++)
                    {
                        xmlWriter.WriteStartElement("Teilnehmer");
                            xmlWriter.WriteStartElement("Vorname");
                            xmlWriter.WriteString(students[i].Name);
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteStartElement("Nachname");
                            xmlWriter.WriteString(students[i].Nachname);
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteStartElement("Geburtsdatum");
                            xmlWriter.WriteString(students[i].Geburtsdatum.ToShortDateString());
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteStartElement("PLZ");
                            xmlWriter.WriteString(students[i].Plz.ToString());
                            xmlWriter.WriteEndElement();

                            xmlWriter.WriteStartElement("Wohnort");
                            xmlWriter.WriteString(students[i].Ort);
                            xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();
                    }

                    xmlWriter.WriteEndDocument();
                    xmlWriter.Close();
                }
            }
        }

        private static Teilnehmer GetStudentInfos()
        {
            Teilnehmer teilnehmer;

            teilnehmer.Name = ReadString("\tVorname: ");
            teilnehmer.Nachname = ReadString("\tNachname: ");
            teilnehmer.Geburtsdatum = ReadDateTime("\tGeburtsdatum: ");    // Eingabe Geburtsdatum => Methode weil komplex
            teilnehmer.Plz = ReadInt("\tPLZ: ");                           // Eingabe PLZ => Methode weil komplex
            teilnehmer.Ort = ReadString("\tWohnort: ");

            return teilnehmer;
        }

        private static void DisplayStudentInfo(Teilnehmer[] studentInfos)
        {
            for (int i = 0; i < studentInfos.Length; i++)
            {
                DisplayStudentInfo(studentInfos[i]);
            }
        }

        private static void DisplayStudentInfo(Teilnehmer studentInfo)
        {
            Console.WriteLine($"\t{studentInfo.Name}, {studentInfo.Nachname}, {studentInfo.Geburtsdatum.ToShortDateString()}, {studentInfo.Plz}, {studentInfo.Ort}");
        }

        private static string ReadString(string inputPrompt)
        {
            string input = string.Empty;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }

        private static int ReadInt(string inputPrompt)
        {
            string input = string.Empty;
            int inputValue = 0;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                    inputValue = int.Parse(input);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Eingabe.");
                    inputValue = 0;
                    Console.ResetColor();
                    inputIsValid = false;
                }

            }
            while (!inputIsValid);

            return inputValue;
        }

        private static DateTime ReadDateTime(string inputPrompt)
        {
            string input = string.Empty;
            DateTime inputDateTime = DateTime.MinValue;
            bool inputIsValid = false;

            do
            {
                Console.Write(inputPrompt);
                input = Console.ReadLine();

                try
                {
                    inputDateTime = DateTime.ParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    inputIsValid = true;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\aERROR: Ungültige Datumseingabe.");
                    inputDateTime = DateTime.MinValue;
                    Console.ResetColor();
                    inputIsValid = false;
                }

            }
            while (!inputIsValid);

            return inputDateTime;
        }

        private static void CreateHeader(string headerText, ConsoleColor headerTextColor, bool clearScreen)
        {
            int xTitelPos = 0;

            // Wenn true wird Bildschirm gelöscht
            if (clearScreen)
            {
                Console.Clear();
            }

            //Darstellung Programm Header
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));
            Console.WriteLine(new string('*', Console.WindowWidth - 1));

            //cursor f. Titel Ausgabe positionieren
            xTitelPos = (Console.WindowWidth - (headerText.Length + 2)) / 2;
            Console.SetCursorPosition(xTitelPos, 1);

            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = headerTextColor;
            Console.Write(" " + headerText + " ");
            Console.ForegroundColor = oldColor;

            //alte cursor Position wiederherstellen
            Console.SetCursorPosition(0, 4);
            //Consolen Fensterbezeichnung setzen
            Console.Title = headerText;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.CancelKeyPress += Console_CancelKeyPress;
            //Console.ReadKey();

            Kreis meinKreis = new Kreis();
            meinKreis.UngültigerKreisRadius += new KreisRadiusHandler(MeinKreis_KreisRadius);
            meinKreis.PropertyChanged += MeinKreis_PropertyChanged;

            meinKreis.Radius = -2;
        }

        private static void MeinKreis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine($"Eigenschaft - {e.PropertyName} hat sich geändert!!!");
        }

        private static void MeinKreis_KreisRadius(Object sender, UngültigerKreisRadiusEventArgs e)
        {
            var erg = sender as Kreis;

            Console.WriteLine($"Kreisradius: {e.UngültigerKreisRadius}, kann nicht negativ sein !!!");
            //Console.WriteLine($"Aktueller gültiger Radius: {erg.Radius}");

        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Vorgang wird beendet !!!");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EinAusgabeKonsole
{
    internal class Program
    {
        public static void beepSuperMario()
        {
            Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167);
            Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375);
            Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125);
            Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125);
            Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125);
            Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125);
            Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125);
            Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(523, 125);
            Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125);
            Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125);
            Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125);
            Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125);
            Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125);
            Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125);
            Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125);
            Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125);
            Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125);
            Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625);
            Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125);
            Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125);
            Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250);
            Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125); Console.Beep(784, 125); Console.Beep(740, 125);
            Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167);
            Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125);
            Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42);
            Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125);
            Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125);
            Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125);
            Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125);
            Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125);
        }
        static void Main(string[] args)
        {
            int wahl;

            do
            {
                Console.WriteLine("Übersicht");
                Console.WriteLine("=========");
                Console.WriteLine("1 - Beep");
                Console.WriteLine("2 - Change background color");
                Console.WriteLine("3 - Clear screen");
                Console.WriteLine("4 - args ausgeben");
                Console.WriteLine("5 - Change title");
                Console.WriteLine("6 - Set window height x width");
                Console.WriteLine("===========================");
                Console.Write("Ihre Wahl: ");

                wahl = Convert.ToInt32(Console.ReadLine());

                switch (wahl)
                {
                    case 1:
                        Program.beepSuperMario();
                        //beepSuperMario();
                        break;
                    case 2:
                        Array enumArray = Enum.GetValues(typeof(ConsoleColor));
                        Random r = new Random();
                        int colorNumber = r.Next(0, enumArray.Length - 1);
                        Console.SetCursorPosition(0, 0);
                        Console.BackgroundColor = (ConsoleColor)colorNumber;
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        foreach (string str in args)
                            Console.WriteLine(str);
                        break;
                    case 5:
                        Console.Write("Set new title: ");
                        string title = Console.ReadLine();
                        Console.Title = title;
                        break;
                    case 6:
                        Console.Write("Set window dimensions HeightxWidth: ");
                        string dimensions = Console.ReadLine();
                        string part1 = dimensions.Substring(0, 2);
                        string part2 = dimensions.Substring(3, 3);
                        //Console.WindowHeight = Convert.ToInt32(part1);
                        //Console.WindowWidth = Convert.ToInt32(part2);
                        //Console.WriteLine(Convert.ToString(Console.LargestWindowHeight));
                        //Console.WriteLine(Convert.ToString(Console.LargestWindowWidth));
                        Console.SetWindowSize(Convert.ToInt32(part2), Convert.ToInt32(part1));
                        //Console.SetWindowPosition(1000, 1000);
                        break;
                    default:
                        break;
                }
            } while (wahl != 7);

            /*foreach (int item in enumArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("======");
            Console.WriteLine("" + enumArray.Length);*/
        }
    }
}

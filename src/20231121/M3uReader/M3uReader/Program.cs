using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3uReader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            M3uReader myM3uList = new M3uReader();

            myM3uList.readFile();
        }
    }
}

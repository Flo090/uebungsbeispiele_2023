using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal abstract class OperatorMethods
    {
        public static double Add(double val1, double val2)
        {
            return val1 + val2;
        }

        public static double Modulo(double val1, double val2)
        {
            return val1 % val2;
        }
    }
}

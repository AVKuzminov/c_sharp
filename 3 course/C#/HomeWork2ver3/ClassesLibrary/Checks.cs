using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesLibrary
{
    public static class Checks
    {
        public static bool IsDouble(string number)
        {
            double result;
            bool state = double.TryParse(number, out result);
            return state && result > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SoapApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WebService2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WebService2.svc or WebService2.svc.cs at the Solution Explorer and start debugging.
    public class WebService2 : IWebService2
    {
        public void DoWork()
        {
        }

        public Result Factorial(string Input_number)
        {
            try
            {
                int f = int.Parse(Input_number);
                if (f < 0)
                    return new Result("Для отрицательных чисел факториал не определен");
                long n = 1;
                for (int i = 1; i <= f; i++)
                {
                    long prev = n;
                    n *= i;
                    if (n < prev)
                        return new Result("Переполнение");
                }
                return new Result(n);
            }
            catch (Exception ex)
            {
                return new Result(ex);
            }
        }
    }
}

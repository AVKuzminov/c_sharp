using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfConsole
{
    /// <summary>
    /// WCF-сервис
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfService : IWcfService
    {
        public Result Factorial(string s)
        {
            try
            {
                int f; // да, тут int
                f = int.Parse(s);
                if (f < 0)
                {
                    return new Result("Для отрицательных чисел факториал не определен");
                }

                long n = 1;
                for (int i = 1; i <= f; i++)
                {
                    long prev = n;
                    n *= i;
                    if (n < prev)
                    {
                        return new Result("Переполнение");
                    }
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

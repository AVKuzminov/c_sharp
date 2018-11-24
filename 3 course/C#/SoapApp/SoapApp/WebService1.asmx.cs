using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SoapApp
{
    /// <summary>
    /// Веб-сервис SOAP, Asp.Net
    /// </summary>
    [WebService(Namespace = "https://vk.com/kuzminov_artem")] //хороший тон - писать ссылку, которая на что-то ведет
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        /// <summary>
        /// Привет
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string HelloWorld()
        {
            return "Велком";
        }

        /// <summary>
        /// Факториал
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [WebMethod(Description ="Вычисление факториала")]
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

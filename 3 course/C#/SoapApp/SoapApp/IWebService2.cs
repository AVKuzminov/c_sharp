using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SoapApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWebService2" in both code and config file together.
    [ServiceContract(Namespace = "https://vk.com/kuzminov_artem")]
    public interface IWebService2
    {
        [OperationContract()]
        Result Factorial(string Input_number);
        //void DoWork();
    }
}

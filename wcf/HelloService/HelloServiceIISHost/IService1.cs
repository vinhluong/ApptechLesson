using System.ServiceModel;
using System.ServiceModel.Web;

namespace HelloServiceIISHost
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/HelloWorld/")]
        string HelloWorld();
    }
}
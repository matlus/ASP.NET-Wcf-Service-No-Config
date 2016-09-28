using System.ServiceModel;

namespace ASPNETWcfServiceNoConfig
{
    [ServiceContract(Namespace = "http://www.matlus.com/IMyService")]
    public interface IMyService
    {
        [OperationContract]
        string DoSomething(int value, string data);
    }
}
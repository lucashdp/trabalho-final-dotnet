using Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF.Rest
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST", 
            UriTemplate = "SendMessageToMSMQ", 
            RequestFormat = WebMessageFormat.Json, 
            ResponseFormat = WebMessageFormat.Json)]
        string SendMessageToMSMQ(MessageInfo messageInfo);
    }
}

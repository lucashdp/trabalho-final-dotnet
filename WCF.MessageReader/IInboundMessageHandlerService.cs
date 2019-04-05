using Domain;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;

namespace WCF.MessageReader
{
    [ServiceKnownType(typeof(MessageInfo))]
    [ServiceContract]
    public interface IInboundMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void GetMessage(MsmqMessage<MessageInfo> incomingOrderMessage);
    }
}

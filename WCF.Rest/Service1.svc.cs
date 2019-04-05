using Domain;
using System.Messaging;
using System.ServiceModel.Activation;
using System.Transactions;

namespace WCF.Rest
{
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        public string SendMessageToMSMQ(MessageInfo messageInfo)
        {
            Message message = new Message
            {
                Label = "Message received from Web API and Web Service",
                Body = messageInfo
            };

            MessageQueue messageQueue = new MessageQueue(@".\private$\flowmessage")
            {
                Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" })
            };

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                messageQueue.Send(message, MessageQueueTransactionType.Automatic);
                transactionScope.Complete();
            }

            return "OK";
        }
    }
}

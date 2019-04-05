using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;
using Domain;
using WCF.MessageReader.Repository;

namespace WCF.MessageReader
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class MessageInboundMessageHandlerService : IInboundMessageHandlerService
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void GetMessage(MsmqMessage<MessageInfo> messageInfo)
        {
            Console.WriteLine("------------------------------------ mensagem recebida ---------------------------------------");

            MessageInfo message = messageInfo.Body;

            Console.WriteLine(message.Assunto);
            Console.WriteLine(message.Mensagem);
            Console.WriteLine();

            new WCFMessageRepository().Insert(messageInfo.Body);
        }
    }
}

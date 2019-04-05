using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WCF.MessageReader
{
    class Program
    {
        static ManualResetEvent signal = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            ////SELF-HOST (repare que não estou utilizando o IIS)
            using (var host = new ServiceHost(typeof(MessageInboundMessageHandlerService)))
            {
                host.Faulted += Faulted;
                host.Open();

                Console.WriteLine("Serviço iniciado ...");

                //Se apertar qualquer tecla vai sair do console
                Console.ReadLine();

                if (host != null)
                {
                    if (host.State == CommunicationState.Faulted)
                    {
                        host.Abort();
                    }
                    host.Close();
                }
            }
        }

        static void Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Problema no WCF. Aperte qualquer tecla para fechar.");
        }
    }
}

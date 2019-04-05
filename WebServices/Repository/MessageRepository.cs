using Domain;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebServices.Repository
{
    public class MessageRepository
    {
        static HttpClient client;

        public string SendMessage(string subject, string message)
        {
            //try
            //{
            //    MessageInfo messageInfo = new MessageInfo
            //    {
            //        Assunto = subject,
            //        Mensagem = message
            //    };

            //    client = new HttpClient();
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    var json = JsonConvert.SerializeObject(message);
            //    var content = new StringContent(json, Encoding.UTF8, "application/json");
            //    var result = string.Empty;
            //    var baseAddress = "http://localhost/WCF.Rest/Service1.svc/";

            //    HttpResponseMessage response = client.PostAsync(baseAddress + "SendMessageToMSMQ", content).Result;

            //    if (response.IsSuccessStatusCode)
            //        result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);

            //    if (result != "OK")
            //        throw new OperationCanceledException();

            //    return HttpStatusCode.OK.ToString();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}






            try
            {
                MessageInfo messageInfo = new MessageInfo
                {
                    Assunto = subject,
                    Mensagem = message
                };

                client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var msg = new MessageInfo { Assunto = messageInfo.Assunto, Mensagem = messageInfo.Mensagem };
                var json = JsonConvert.SerializeObject(msg);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = string.Empty;
                var baseAddress = "http://localhost/WCF.Rest/Service1.svc/";

                HttpResponseMessage response = client.PostAsync(baseAddress + "SendMessageToMSMQ", content).Result;

                if (response.IsSuccessStatusCode)
                    result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);

                if (result != "OK")
                    throw new OperationCanceledException();

                return HttpStatusCode.OK.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

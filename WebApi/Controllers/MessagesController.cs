using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : Controller
    {
        static HttpClient client;

        [HttpPost]
        public void CreateMessage([FromBody] MessageInfo messageInfo)
        {
            try
            {
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
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
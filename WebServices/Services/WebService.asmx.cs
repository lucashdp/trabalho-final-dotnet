using System.ComponentModel;
using System.Web.Services;
using WebServices.Repository;

namespace WebServices.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[ToolboxItem(false)]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod]
        public string CreateMessage(string subject, string message)
        {
            return new MessageRepository().SendMessage(subject, message);
        }
    }
}

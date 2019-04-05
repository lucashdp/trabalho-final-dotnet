using Domain;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace WCF.MessageReader.Repository
{
    public class WCFMessageRepository
    {
        private readonly IMongoCollection<MessageInfo> messageCollection;

        public WCFMessageRepository()
        {
            string mongoConnection = ConfigurationManager.ConnectionStrings["MessageDB"].ConnectionString;

            //string mongoConnection = ConfigurationManager.AppSettings["connectionString"];

            var mongoClient = new MongoClient(mongoConnection);

            messageCollection = mongoClient.GetDatabase("messagedatabase").GetCollection<MessageInfo>("Messages");
        }

        public List<MessageInfo> Get()
        {
            return messageCollection.Find(collection => true).ToList();
        }

        public void Insert(MessageInfo messageInfo)
        {
            messageCollection.InsertOne(messageInfo);
        }
    }
}

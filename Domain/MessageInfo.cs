using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class MessageInfo
    {
        [DataMember(IsRequired = true)]
        public string Assunto { get; set; }

        [DataMember(IsRequired = true)]
        public string Mensagem { get; set; }
    }
}

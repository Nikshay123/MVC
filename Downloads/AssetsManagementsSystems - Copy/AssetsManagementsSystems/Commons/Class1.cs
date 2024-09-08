using System.Runtime.Serialization;

namespace Common
{
    [DataContract(Name = "ResponseBaseDataContract")]
    public class ResponseBaseDataContract
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string StatusMessage { get; set; }
    }
}

using System.Runtime.Serialization;

namespace Week6Assignment.DAL
{
    [DataContract]
    public class BookDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public string Author { get; set; }
    }
}

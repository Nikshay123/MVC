using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AssetsManagementSystems.DAL
{
    [DataContract(Name = "BookDataContract")]
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

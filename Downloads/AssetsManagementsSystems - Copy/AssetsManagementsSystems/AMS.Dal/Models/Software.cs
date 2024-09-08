using System.ComponentModel.DataAnnotations;

namespace AssetsManagementsSystems.DAL
{
    public class Software
    {
        [Key]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string LicenseKey { get; set; }
        public string Version { get; set; }
    }
}

using AMS.Api.Response;
using System.Runtime.Serialization;

namespace AssetsManagementsSystems.Api.Software
{
    [DataContract]
    public class SoftwareRequest
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string LicenseKey { get; set; }
        public string Version { get; set; }
    }
    public class SoftwareResponse :BaseResponse
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string LicenseKey { get; set; }
        public string Version { get; set; }
        public IEnumerable<SoftwareResponse> Data { get; set; }
    }
    public class SoftwareUpdateRequest
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string LicenseKey { get; set; }
        public string Version { get; set; }
    }
}






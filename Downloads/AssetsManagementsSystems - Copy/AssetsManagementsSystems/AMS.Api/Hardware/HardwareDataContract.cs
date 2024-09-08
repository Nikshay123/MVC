using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using AMS.Api.Response;

namespace AssetsManagementSystems.Api.Hardware
{
    [DataContract]
    public class HardwareRequest
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Specification { get; set; }
    }
    public class HardwareResponse:BaseResponse
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Specification { get; set; }
        public IEnumerable<HardwareResponse> Data { get; set; }
    }
    public class HardwareUpdateRequest
    {

        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Specification { get; set; }
    }
}


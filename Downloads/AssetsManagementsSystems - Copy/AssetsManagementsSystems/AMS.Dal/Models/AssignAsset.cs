using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AssetsManagementsSystems.DAL
{
    public class AssignAsset
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int AssetId {  get; set; }
        public string AssetType { get; set; }
        public string AssignedTo { get; set; }


    }
}

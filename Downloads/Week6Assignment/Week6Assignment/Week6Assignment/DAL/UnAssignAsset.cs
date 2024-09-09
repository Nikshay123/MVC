using System.ComponentModel.DataAnnotations;

namespace Week6Assignment.DAL
{
    public class UnassignAsset
    {
        [Key]
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string AssignedTo { get; set; }
        public string AssetType { get; set; }
    }
}

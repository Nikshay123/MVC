using System;
using System.ComponentModel.DataAnnotations;

namespace Week6Assignment.DAL
{
    public class AssignAsset
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AssetId { get; set; }

        [Required]
        public string AssetType { get; set; }

        [Required]
        public string AssignedTo { get; set; }

    
    }
}

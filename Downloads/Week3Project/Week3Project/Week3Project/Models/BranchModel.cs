using System.ComponentModel.DataAnnotations;

namespace Week3Project.Models
{
    public class BranchModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

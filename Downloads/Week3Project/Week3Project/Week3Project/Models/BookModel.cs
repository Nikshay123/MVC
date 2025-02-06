using System.ComponentModel.DataAnnotations;

namespace Week3Project.Models
{
    public class BookModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Publication ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative number.")]
        public int Quantity { get; set; }
    }
}

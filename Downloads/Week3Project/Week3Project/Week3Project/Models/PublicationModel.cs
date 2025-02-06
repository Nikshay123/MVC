using System;
using System.ComponentModel.DataAnnotations;

namespace Week3Project.Models
{
    public class PublicationModel
    {
        [Required(ErrorMessage = "Publication ID is required.")]
        public int PublicationId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Please enter a valid publication year.")]
        public int Year { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Branch is required.")]
        public string Branch { get; set; }
    }
}

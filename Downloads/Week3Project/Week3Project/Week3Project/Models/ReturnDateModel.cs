using System;
using System.ComponentModel.DataAnnotations;

namespace Week3Project.Models
{
    public class ReturnDateModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Issue Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime IssueDate { get; set; }

        [Required(ErrorMessage = "Return Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime ReturnDate { get; set; }
    }
}

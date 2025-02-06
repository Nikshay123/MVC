using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week3Project.Models
{
    public class IssuedBook
    {
        public string Id { get; set; }
        public string StudentId { get; set; }
        public String BookId { get; set; }
        public string IssueDate {  get; set; }
        public string ReturnDate { get; set; }
    }
}
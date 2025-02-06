using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week3Project.Models
{
    public class StudentReportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
using System.Collections.Generic;

namespace Week3Project.Models
{
    public class DashBoard
    {
        public List<PublicationModel> Publications { get; set; }
        public List<StudentReportModel> Students { get; set; }
        public List<BookModel> Books { get; set; }
        public List<BranchModel> Branches { get; set; }
        public List<IssueDateModel> IssueDates { get; set; }
        public List<ReturnDateModel> ReturnDates { get; set; }

        
    }
}

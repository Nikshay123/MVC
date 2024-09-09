using System.ComponentModel.DataAnnotations;

namespace Week6Assignment.DAL
{
    public class Hardware
    {
        [Key]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Specification { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AssetsManagementsSystems.DAL
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public String SerialNumber { get; set; }
        public String Name { get; set; }
        public String Details { get; set; }
        public string Title {  get; set; }
        public String Author { get; set; }

    }
}

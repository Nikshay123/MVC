using AMS.Api.Response;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AssetsManagementSystems.Api.Books
{
    public class BookRequest
    {
        public int SerialNumber { get; set; }

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Author { get; set; }
        public string  Title { get; set; }
        public String Details { get; set; }
        public int Id { get; set; }
    }



    public class BookResponse:BaseResponse
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int  Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public IEnumerable<BookResponse>? Data { get; set; }
    }


    public class BookUpdateRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int SerialNumber { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Author { get; set; }

        public string Title { get; set; }
    }
}


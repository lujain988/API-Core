using WebApplication13.Models;

namespace WebApplication13.DTOs
{
    public class productRequestDTO
    {

        public string? ProductName { get; set; }

        public string? Description { get; set; }
        public int? CategoryId { get; set; }

        public long? Price { get; set; }

        public IFormFile? ProductImage { get; set; }


    }
}

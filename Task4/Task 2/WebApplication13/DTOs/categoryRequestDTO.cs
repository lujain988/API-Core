using WebApplication13.Models;

namespace WebApplication13.DTOs
{
    public class categoryRequestDTO
    {

        public string? CategoryName { get; set; }

        public IFormFile? CategoryImage { get; set; }

    }
}

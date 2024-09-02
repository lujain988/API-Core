using System.ComponentModel.DataAnnotations;

namespace WebApplication13.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "This field is required.")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string? Password { get; set; }


    }
}

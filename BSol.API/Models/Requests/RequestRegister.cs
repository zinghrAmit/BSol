using System.ComponentModel.DataAnnotations;

namespace BSol.API.Models.Requests
{
    public class RequestRegister
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Mobile {  get; set; } = string.Empty;

        [Required]
        public string UserType {  get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Proffession {  get; set; } = string.Empty;

        [Required]
        public string Company {  get; set; } = string.Empty;

        [Required]
        public string WorkingExperience { get; set; } = string.Empty;

        [Required]
        public double CTC { get; set; }
    }
}

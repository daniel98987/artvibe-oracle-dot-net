using System.ComponentModel.DataAnnotations;

namespace artvibe_oracle.Data.Configurations
{
    public class LoginDtoBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace artvibe_oracle.Models.userModel
{
    public class UserModel : IdentityUser
    {


        public DateTime DateOfBirdth { get; set; }
        public string Password { get; set; }

    }
}

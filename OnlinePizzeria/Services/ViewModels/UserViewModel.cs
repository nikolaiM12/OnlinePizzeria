using Microsoft.AspNetCore.Identity;

namespace OnlinePizzeria.Services.ViewModels
{
    public class UserViewModel : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}

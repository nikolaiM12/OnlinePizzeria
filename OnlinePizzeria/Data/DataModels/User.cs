using Microsoft.AspNetCore.Identity;

namespace OnlinePizzeria.Data.DataModels
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}

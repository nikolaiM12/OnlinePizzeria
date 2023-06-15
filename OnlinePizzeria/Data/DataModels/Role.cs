using Microsoft.AspNetCore.Identity;

namespace OnlinePizzeria.Data.DataModels
{
    public class Role : IdentityRole
    {
        public DateTime CreationDate { get; set; }
    }
}

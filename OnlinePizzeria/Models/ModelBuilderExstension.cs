using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlinePizzeria.Data.DataModels;

namespace OnlinePizzeria.Models
{
    public static class ModelBuilderExstension
    {
        public static void Seed(this ModelBuilder builder)
        {
            var password = "[arugqnb7r&W&^Er62";
            var passwordHasher = new PasswordHasher<User>();

            var adminRole = new Role()
            {
                Name = "Admin",
                CreationDate = DateTime.Now,
            };
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var userRole = new Role()
            {
                Name = "User",
                CreationDate = DateTime.Now,
            };
            userRole.NormalizedName = userRole.Name.ToUpper();

            List<Role> roles = new List<Role>()
            {   adminRole,
                userRole,
            };

            builder.Entity<Role>().HasData(roles);

            var adminUser = new User()
            {
                UserName = "Petar",
                Email = "a@admin.com",
                EmailConfirmed = true,
                ProfilePicturePath = "/ProfilePictures/default.jpg",
                CreationDate = DateTime.Now,
                LastLoginDate = DateTime.Now
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, password);

            var userUser = new User()
            {
                UserName = "Georgi",
                Email = "u@user.com",
                EmailConfirmed = true,
                ProfilePicturePath = "/ProfilePictures/default.jpg",
                CreationDate = DateTime.Now,
                LastLoginDate = DateTime.Now
            };
            userUser.NormalizedUserName = userUser.UserName.ToUpper();
            userUser.NormalizedEmail = userUser.Email.ToUpper();
            userUser.PasswordHash = passwordHasher.HashPassword(userUser, password);

            List<User> users = new List<User>()
            {
                adminUser,
                userUser,
            };

            builder.Entity<User>().HasData(users);

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            for (int i = 0; i < users.Count; i++)
            {
                userRoles.Add(new IdentityUserRole<string>()
                {
                    UserId = users[i].Id,
                    RoleId = roles[i].Id
                });
            }

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}

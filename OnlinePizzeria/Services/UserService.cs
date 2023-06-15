using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using OnlinePizzeria.Data.DataModels;
using OnlinePizzeria.Data;
using OnlinePizzeria.Services.Interfaces;

namespace OnlinePizzeria.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;
        private readonly ILogger<User> _logger;
        private readonly IEmailSender _emailSender;

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }

        public UserService(ApplicationDbContext context,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUserStore<User> userStore,

            ILogger<User> logger,
            IEmailSender emailSender)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _logger = logger;
            _emailSender = emailSender;
        }

        public List<User> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public User GetUserById(string id)
        {
            return _userManager.FindByIdAsync(id).Result;
        }
        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

    }
}

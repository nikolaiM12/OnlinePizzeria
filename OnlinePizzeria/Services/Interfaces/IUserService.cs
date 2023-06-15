using OnlinePizzeria.Data.DataModels;

namespace OnlinePizzeria.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetUserById(string id);
        Task<bool> DeleteUser(string id);
    }
}

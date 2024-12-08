using Entity;

namespace service
{
    public interface IUserService
    {
        Task<Users> AddUser(Users user);
        int CheckPassword(string password);
        Task<Users> GetUserById(int id);
        Task<Users> LogIn(string userName, string password);
        Task UpdateUser(int id, Users userToUpdate);
    }
}
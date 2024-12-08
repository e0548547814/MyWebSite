using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        Task<Users> AddUser(Users user);
        Task<Users> GetUserById(int id);
        Task<Users> LogIn(string userName, string password);
        Task<Users> UpdateUser(int id, Users userToUpdate);
    }
}
using Entity;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserById(int id);
        User LogIn(string userName, string password);
        void UpdateUser(int id, User userToUpdate);
    }
}
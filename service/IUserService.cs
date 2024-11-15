using Entity;

namespace service
{
    public interface IUserService
    {
        User AddUser(User user);
        int CheckPassword(string password);
        User GetUserById(int id);
        User LogIn(string userName, string password);
        void UpdateUser(int id, User userToUpdate);
    }
}
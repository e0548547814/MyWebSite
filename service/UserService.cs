using Entity;
using Repository;
using System.Text.Json;

namespace service
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository UserRepository)
        {
            userRepository = UserRepository;
        }
       
        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);

        }

        public User AddUser(User user)
        {
            if (CheckPassword(user.Password) > 2)
                return userRepository.AddUser(user);
            else
            {
                return null;
            }


        }
        public void UpdateUser(int id, User userToUpdate)
        {
            if (CheckPassword(userToUpdate.Password) > 2)
                userRepository.UpdateUser(id, userToUpdate);


        }

        public User LogIn(string userName, string password)
        {
            return userRepository.LogIn(userName, password);
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}

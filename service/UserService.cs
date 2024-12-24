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

        public async Task<User> GetUserById(int id)
        {
            return await userRepository.GetUserById(id);

        }

        public async Task<User> AddUser(User user)
        {
            if (CheckPassword(user.Password) > 2)
                return await userRepository.AddUser(user);
            else
            {
                return null;


            }


        }
        public async Task UpdateUser(int id, User userToUpdate)
        {
            if (CheckPassword(userToUpdate.Password) > 2)
                await userRepository.UpdateUser(id, userToUpdate);


        }

        public async Task<User> LogIn(string userName, string password)
        {
            return await userRepository.LogIn(userName, password);
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}

using Entity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        ApiOrmContext _ApiOrmContext;
        public UserRepository(ApiOrmContext ApiOrmContext)
        {
            _ApiOrmContext = ApiOrmContext;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _ApiOrmContext.Users.FindAsync(id);

        }

        public async Task<User> AddUser(User user)
        {
            await _ApiOrmContext.Users.AddAsync(user);
            await _ApiOrmContext.SaveChangesAsync();
            return user;

        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            User user = await _ApiOrmContext.Users.FindAsync(id);
            if (user == null)
                return null;
            _ApiOrmContext.Update(user).CurrentValues.SetValues(userToUpdate);
            return user;

        }

        public async Task<User> LogIn(string userName, string password)
        {
           return await _ApiOrmContext.Users.FirstOrDefaultAsync((user=> user.UserName== userName &&user.Password== password));

        }


    }
}

       
    


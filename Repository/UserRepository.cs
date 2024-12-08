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

        public async Task<Users> GetUserById(int id)
        {
            return await _ApiOrmContext.Users.FindAsync(id);

        }

        public async Task<Users> AddUser(Users user)
        {
            await _ApiOrmContext.Users.AddAsync(user);
            await _ApiOrmContext.SaveChangesAsync();
            return user;

        }
        public async Task<Users> UpdateUser(int id, Users userToUpdate)
        {
            userToUpdate.UserId = id;
            _ApiOrmContext.Users.Update(userToUpdate);
            await _ApiOrmContext.SaveChangesAsync();
            return userToUpdate;

        }

        public async Task<Users> LogIn(string userName, string password)
        {
           return await _ApiOrmContext.Users.FirstOrDefaultAsync((user=> user.UserName== userName &&user.Password== password));

        }


    }
}

       
    


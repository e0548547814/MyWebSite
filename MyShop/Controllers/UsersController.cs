using Microsoft.AspNetCore.Mvc;
using service;
using System.Text.Json;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers 
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService UserService;
        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        //GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return new string[] { " ", " " };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id) { 

        Users foundUser =await  UserService.GetUserById(id);
        if (foundUser == null)
            return  NoContent();
        else 

        return Ok(foundUser);

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Users user)
        {

          Users newUser = await UserService.AddUser(user);
            if(newUser!=null)
            return Ok(newUser);
            else
                return Unauthorized();
        }

        [HttpPost("password")]
        public async Task<IActionResult> CheckPassword([FromBody] string password)
        {

          int Score =  UserService.CheckPassword(password);
          return  (Score < 3)?
                 BadRequest(Score):
            Ok(Score);
        }


        [HttpPost("login")]
        public async Task<ActionResult<Users>> LogIn([FromQuery] string userName, string password)
        {
            Users userLogin =await UserService.LogIn(userName, password);
            if (userLogin == null)
                return NoContent();
            return Ok(userLogin);
         
           
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Users userToUpdate)
        {
           await UserService.UpdateUser(id, userToUpdate); 

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

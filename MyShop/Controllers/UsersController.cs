using Microsoft.AspNetCore.Mvc;
using service;
using System.Text.Json;
using Entity;
using AutoMapper;
using dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers 
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService UserService;
        IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            mapper = _mapper;
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterUserDTO>> Get(int id) {

            User user = await UserService.GetUserById(id);
            RegisterUserDTO userDTO = _mapper.Map<User, RegisterUserDTO>(user);

            if (userDTO == null)
            return  NoContent();
        else 

        return Ok(userDTO);

        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<userDTO>> Register([FromBody] RegisterUserDTO user)
        {

            User newUser = _mapper.Map<RegisterUserDTO, User>(user);
            User userDTO = await UserService.AddUser(newUser);

            userDTO newUserDTO = _mapper.Map<User, userDTO>(userDTO);
            if (newUserDTO != null)
                return CreatedAtAction(nameof(Get), new { id = user.UserName }, newUserDTO);
            else
                return BadRequest(newUserDTO);

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
        public async Task<ActionResult<userDTO>> LogIn([FromQuery] string userName,
            string password)
        {
            User userLogin =await UserService.LogIn(userName, password);
            userDTO userDTO = _mapper.Map<User, userDTO>(userLogin);
            if (userDTO == null)
                return NoContent();
            return Ok(userDTO);
         
           
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] userDTO value)
        {
            User user = _mapper.Map<userDTO, User>(value);
            await UserService.UpdateUser(id, user);
        }


    }
}

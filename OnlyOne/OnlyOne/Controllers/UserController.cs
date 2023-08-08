using Microsoft.AspNetCore.Mvc;
using OnlyOne.Interface;
using OnlyOne.Models;

namespace OnlyOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            if(users == null)
            {
                return BadRequest(ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if(user == null)
            {
                return BadRequest(ModelState);
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(user);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await  _userRepository.GetUserByName(name);
            if (user != null)
            {
                return Ok(user);

            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user) 
        { 
            await _userRepository.CreateUser(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if(!await _userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            await _userRepository.DeleteUser(user);
            return Ok("Deleted");
        }
    }
}

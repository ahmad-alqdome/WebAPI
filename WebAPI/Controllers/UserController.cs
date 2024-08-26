using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IUserService _userService;

        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            return Ok(await _userService.GetUserByIdAsync(id));
        }


        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody]UserDto user)
        {
            return await _userService.AddUser(user)?Ok("Sucessfully!"):BadRequest("The Data Not Saved");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            return await _userService.DeleteUserAsync(id)?Ok("Delete Sucessfully"):NotFound("The Date Is Not Found !");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id , [FromBody]UserDto newUser)
        {
         return   await  _userService.UpdateUserAsync(id, newUser)?Ok("Update Sucessfully "): NotFound("The Date Is Not Found !");
        }
    }
}

using System.Collections;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetAllUsersAsync();
        public Task<UserDto> GetUserByIdAsync(int id);
        public Task<bool> AddUser(UserDto user);
        public Task<bool> UpdateUserAsync(int id, UserDto updatedUserDto);
        public Task<bool> DeleteUserAsync(int id);

    }
}
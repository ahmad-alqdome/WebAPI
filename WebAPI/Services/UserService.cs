using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        public ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<bool> AddUser(UserDto user)
        {
            if (user == null)
            {
                return false;
            }
            else
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }

        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return false; // User not found
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return true; // Deletion was successful
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
           return await _context.Users.ToListAsync();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);

        }

        public async Task<bool> UpdateUserAsync(int id, UserDto updatedUserDto)
        {
            // Find the user by ID
            var user = await _context.Users.FindAsync(id);

            // If the user is not found, return false
            if (user == null)
            {
                return false;
            }

            // Update the user properties with the values from updatedUserDto
            user.Name = updatedUserDto.Name;
            user.Email = updatedUserDto.Email;
            // Update other properties as needed

            // Mark the entity as modified
            _context.Users.Update(user);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true indicating the update was successful
            return true;
        }

    }
}

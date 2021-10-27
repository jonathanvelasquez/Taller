using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TallerAPI.Data;
using TallerAPI.Data.Entities;

namespace TallerAPI.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManeger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public UserHelper(
            UserManager<User> userManeger, 
            RoleManager<IdentityRole> roleManager,
            DataContext context)
        {
            _userManeger = userManeger;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManeger.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManeger.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(x => x.DocumentType)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManeger.IsInRoleAsync(user, roleName);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using TallerAPI.Data.Entities;
using TallerAPI.Models;

namespace TallerAPI.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<User> GetUserAsync(Guid id);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<IdentityResult> UpdateUserAsync(User user);
    }
}

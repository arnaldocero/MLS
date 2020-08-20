using Microsoft.AspNetCore.Identity;
using MLS.Web.Data.Entities;
using MLS.Web.Models;
using System;
using System.Threading.Tasks;

namespace MLS.Web.Helpers
{
    public interface IUserHelper
    {
        Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(UserEntity user);

        Task<UserEntity> AddUserAsync(AddUserViewModel model, string path);
        Task<UserEntity> GetUserAsync(string email);

        Task<UserEntity> GetUserAsync(Guid userId);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


    }
}

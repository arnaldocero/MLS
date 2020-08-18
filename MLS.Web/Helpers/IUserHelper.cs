using Microsoft.AspNetCore.Identity;
using MLS.Web.Data.Entities;
using MLS.Web.Models;
using System.Threading.Tasks;

namespace MLS.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> AddUserAsync(AddUserViewModel model, string path);
        Task<UserEntity> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();


    }
}

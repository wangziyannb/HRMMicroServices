using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Contracts.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password, string role);
        Task<SignInResult> PasswordSignInAsync(string username, string password);
    }
}

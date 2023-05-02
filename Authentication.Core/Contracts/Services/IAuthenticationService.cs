using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Core.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task<SignInResult> SignInAsync(SignInModel model);
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<IdentityResult> SignUpAsync(SignUpModel model, string role);
    }
}

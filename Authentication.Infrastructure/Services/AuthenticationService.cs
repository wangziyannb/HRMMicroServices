using Authentication.Core.Contracts.Repositories;
using Authentication.Core.Contracts.Services;
using Authentication.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository repository;
        public AuthenticationService(IAuthenticationRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SignInResult> SignInAsync(SignInModel model)
        {
            return await repository.PasswordSignInAsync(model.Username, model.Password);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return await repository.CreateAsync(user, model.Password);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model, string role)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            return await repository.CreateAsync(user, model.Password, role);
        }
    }
}

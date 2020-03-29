using Microsoft.AspNetCore.Identity;
using Midas_Data.Entities;
using Midas_Models.Accounts;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateUser(UserCreate request)
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var createUser = await _userManager.CreateAsync(user, request.Password);

            if (createUser.Succeeded)
            {
                return true;
            }

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var deleteUser = await _userManager.DeleteAsync(user);

            if (deleteUser.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> EditUser(ApplicationUser request)
        {
            var user = await GetUserById(request.Id);

            user.Id = request.Id;
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return user;

        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            var userList =  _userManager.Users;

            return userList;
        }
    }
}

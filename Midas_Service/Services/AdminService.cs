using Microsoft.AspNetCore.Identity;
using Midas_Data.Entities;
using Midas_Models.Admin;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class AdminService : IAdminService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> CreateUserRole(UserRoleCreate request)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = request.RoleName
            };

            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            
            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteUserRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> EditUserRole(IdentityRole request)
        {
            var role = await GetUserRoleById(request.Id);

            role.Id = request.Id;
            role.Name = request.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<IdentityRole> GetUserRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            return role;
        }

        public IQueryable<IdentityRole> GetUserRoles()
        {
            var roles = _roleManager.Roles;

            return roles;
        }
    }
}

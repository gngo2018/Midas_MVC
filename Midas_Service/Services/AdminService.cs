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
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> CreateRole(RoleCreate request)
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

        public async Task<bool> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> EditRole(IdentityRole request)
        {
            var role = await GetRoleById(request.Id);

            role.Id = request.Id;
            role.Name = request.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return true;
            }

            return false;

        }

        public async Task<IdentityRole> GetRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            return role;
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            var roles = _roleManager.Roles;

            return roles;
        }

        public async Task<bool> ManageUserRole(List<UserRoleManager> request, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            result = await _userManager.AddToRolesAsync(user, request
                .Where(r => r.IsSelected).Select(x => x.RoleName));

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}

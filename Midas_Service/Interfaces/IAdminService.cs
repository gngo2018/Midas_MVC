using Microsoft.AspNetCore.Identity;
using Midas_Data.Entities;
using Midas_Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IAdminService
    {
        Task<bool> CreateRole(RoleCreate request);
        IQueryable<IdentityRole> GetRoles();
        Task<IdentityRole> GetRoleById(string id);
        Task<bool> EditRole(IdentityRole request);
        Task<bool> DeleteRole(string id);
        Task<bool> ManageUserRole(List<UserRoleManager> request, string userId);
        Task<RoleClaimView> ManageRoleClaims(string roleId);

    }
}

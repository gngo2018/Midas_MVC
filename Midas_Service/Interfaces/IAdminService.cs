using Microsoft.AspNetCore.Identity;
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
        Task<bool> CreateUserRole(UserRoleCreate request);
        IQueryable<IdentityRole> GetUserRoles();
        Task<IdentityRole> GetUserRoleById(string id);
        Task<bool> EditUserRole(IdentityRole request);
        Task<bool> DeleteUserRole(string id);

    }
}

using Midas_Data.Entities;
using Midas_Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateUser(UserCreate request);
        Task<bool> DeleteUser(string id);
        Task<bool> EditUser(ApplicationUser request);
        IQueryable<ApplicationUser> GetUsers();
        Task<ApplicationUser> GetUserById(string id);

    }
}

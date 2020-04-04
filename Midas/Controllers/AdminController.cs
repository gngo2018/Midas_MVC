using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Entities;
using Midas_Models.Admin;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(IAdminService adminService, IAccountService accountService, 
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _adminService = adminService;
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: Admin
        public ActionResult Index()
        {
            var roles = _adminService.GetRoles();

            return View(roles);
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var role = await _adminService.GetRoleById(id);

            return View(role);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(RoleCreate request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userRoleRequest = await _adminService.CreateRole(request);

                    if (userRoleRequest =!false)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                };

                throw new Exception();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _adminService.GetRoleById(id);
            var roleClaims = await _roleManager.GetClaimsAsync(role);

            var roleViewModel = new RoleEdit
            {
                Id = role.Id,
                RoleName = role.Name,
                Claims = roleClaims.Select(c => c.Type).ToList()
            };

            foreach(var user in await _userManager.Users.ToListAsync())
            {
                if(await _userManager.IsInRoleAsync(user, role.Name))
                {
                    roleViewModel.Users.Add(user.UserName);
                };
            }

            return View(roleViewModel);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(RoleEdit request)
        {
            try
            {
                var identityRoleRequest = new IdentityRole
                {
                    Id = request.Id,
                    Name = request.RoleName
                };

                var result = await _adminService.EditRole(identityRoleRequest);

                if (result =!false)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _adminService.GetRoleById(id);

            return View(role);
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteRole(string id)
        {
            try
            {
                var result = await _adminService.DeleteRole(id);

                if (result =!false)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Unable to delete role: ", e.Message);
                return View();
            }
        }

        //Managing User Roles
        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string userId, string userName)
        {
            ViewBag.userId = userId;
            ViewBag.userName = userName;

            var user = await _accountService.GetUserById(userId);
            var model = new List<UserRoleManager>();

            foreach (var role in await _adminService.GetRoles().ToListAsync())
            {
                var userRoleManager = new UserRoleManager
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleManager.IsSelected = true;
                }
                else
                {
                    userRoleManager.IsSelected = false;
                }

                model.Add(userRoleManager);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRoleManager> request, string userId)
        {
            var result = await _adminService.ManageUserRole(request, userId);

            if (result =!false)
            {
                return RedirectToAction("Index", "Account");
            }

            throw new Exception();
        }

        [HttpGet]
        public async Task<IActionResult> ManageRoleClaims(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            ViewBag.roleName = role.Name;

            var roleClaimModel = await _adminService.ManageRoleClaims(roleId); 

            return View(roleClaimModel);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRoleClaims(RoleClaimView request)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(request.RoleId);

                if (role == null)
                {
                    ModelState.AddModelError("", "Role was not found");
                    return View(request);
                }

                var claims = await _roleManager.GetClaimsAsync(role);

                //Remove all Claims from Role
                foreach (var claim in claims)
                {
                    var result = await _roleManager.RemoveClaimAsync(role, claim);

                }

                var selectedClaims = request.Claims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType));

                //Add Checked Claims to Role
                foreach (var claim in selectedClaims)
                {
                    await _roleManager.AddClaimAsync(role, claim);
                }

                return RedirectToAction("Edit", new { id = request.RoleId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Unable to add claim to role");
                ModelState.AddModelError("", e.Message);

                return View(request);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Entities;
using Midas_Models.Accounts;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountService accountService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //GET: Post
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin credentials)
        {
            try
            {
                var result = await _accountService.LoginUser(credentials);

                if (result == true)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "User Name or Password is incorrect");
                    return View(credentials);
                }
            }
            
            catch (Exception e)
            {
                ModelState.AddModelError("User Name or Password is incorrect", e.Message);
                return View(credentials);
            }
            throw new Exception();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        // GET: Account
        public ActionResult Index()
        {
            var userList = _accountService.GetUsers();

            return View(userList);
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var user = await _accountService.GetUserById(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var userViewModel = new UserDetail
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LastLogin = user.LastLogin,
                Roles = userRoles
            };

            return View(userViewModel);
        }

        // GET: Account/Create
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(UserCreate request)
        {
            try
            {
                var createRequest = await _accountService.CreateUser(request);

                if (createRequest)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _accountService.GetUserById(id);

            return View(user);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser request)
        {
            try
            {
                var editRequest = await _accountService.EditUser(request);
                
                if (editRequest =! false)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);

                return View(request);
            }
        }

        // GET: Account/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _accountService.GetUserById(id);

            return View(user);
        }

        // POST: Account/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                var userDeleteRequest = await _accountService.DeleteUser(id);

                if (userDeleteRequest =! false)
                {
                    return RedirectToAction(nameof(Index));
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Delete");
            }
        }
    }
}
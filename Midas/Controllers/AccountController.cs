using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Midas_Data.Entities;
using Midas_Models.Accounts;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
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

            return View(user);
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
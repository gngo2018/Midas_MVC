using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Midas_Models.MonthlyExpenses;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class MonthlyExpenseController : Controller
    {
        private readonly IMonthlyExpenseService _monthlyExpenseService;
        private readonly IMapper _mapper;

        public MonthlyExpenseController(IMonthlyExpenseService monthlyExpenseService, IMapper mapper)
        {
            _monthlyExpenseService = monthlyExpenseService;
            _mapper = mapper;
        }

        // GET: MonthlyExpense
        public async Task<IActionResult> Index()
        {
            var result = await _monthlyExpenseService.GetMonthlyExpenses();
            var totalAmount = 0.0;

            foreach(var expense in result)
            {
                totalAmount += expense.BillAmount;
            }

            ViewBag.totalAmount = totalAmount;

            return View(result);
        }

        // GET: MonthlyExpense/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonthlyExpense/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonthlyExpense/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MonthlyExpenseListItem request)
        {
            try
            {
                var result = await _monthlyExpenseService.CreateMonthlyExpense(request);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        // GET: MonthlyExpense/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonthlyExpense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MonthlyExpense/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonthlyExpense/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
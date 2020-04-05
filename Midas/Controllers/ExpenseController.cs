using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Midas_Models.Expenses;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
        }

        // GET: Expense
        public async Task<IActionResult> Index()
        {
            var expenseListResponse = await _expenseService.GetExpenses();

            return View(expenseListResponse);
        }

        // GET: Expense/Details/5
        public async Task <IActionResult> Details(int id)
        {
            try
            {
                var result = await _expenseService.GetExpenseById(id);
                return View(result);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View("Index");
            }
        }

        // GET: Expense/Create
        public IActionResult Create()
        {
             return View();
        }

        // POST: Expense/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpenseCreate request)
        {
            try
            {
                if (await _expenseService.CreateExpense(request))
                {
                    TempData["SaveResult"] = "Your invoice was created!";
                    return RedirectToAction("Index");
                }

                throw new Exception();
            }
            catch
            {
                ModelState.AddModelError("", "Invoice was unable to be created");

                return View(request);
            }
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _expenseService.GetExpenseById(id);
                return View(result);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: Expense/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ExpenseUpdate request)
        {
            try
            {
                // TODO: Add update logic here
                var result = await _expenseService.UpdateExpense(request);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> DeleteExpense(int id)
        {
            try
            {
                var result = await _expenseService.GetExpenseById(id);
                return View(result);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Index");
            }
        }

        // POST: Expense/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Delete(int id)
        {
            try
            {
                var result = await _expenseService.DeleteExpense(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("DeleteExpense", id);
            }
        }
    }
}
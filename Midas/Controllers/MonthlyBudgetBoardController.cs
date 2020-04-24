using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Midas_Data.Models;
using Midas_Models.MonthlyBudgetBoard;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class MonthlyBudgetBoardController : Controller
    {
        private readonly IMonthlyBudgetBoardService _monthlyBudgetService;
        private readonly IBudgetBoardService _budgetBoardService;

        public MonthlyBudgetBoardController(IMonthlyBudgetBoardService monthlyBudgetBoardService, IBudgetBoardService budgetBoardService)
        {
            _monthlyBudgetService = monthlyBudgetBoardService;
            _budgetBoardService = budgetBoardService;
        }
        // GET: MonthlyBudgetBoard
        public async Task<IActionResult> Index()
        {
            var result = await _monthlyBudgetService.GetMonthlyBudgetBoards();

            return View(result);
        }

        // GET: MonthlyBudgetBoard/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _monthlyBudgetService.GetMonthlyBudgetBoardById(id);
            var expenses = await _monthlyBudgetService.GetExpenseTypes();
            var budgetBoard = await _budgetBoardService.GetBudgetBoardById(result.BudgetBoardId);
            var expenseTypeList = new SelectList(expenses, "ExpenseTypeId", "ExpenseTypeName");
            var expenseTotal = 0.0;
            var livingExpenseTotal = 0.0;
            var leisureExpenseTotal = 0.0;

            foreach (var expense in result.ExpenseList)
            {
                expenseTotal += expense.ExpenseAmount;

                if (expense.ExpenseTypeId == 1)
                {
                    livingExpenseTotal += expense.ExpenseAmount;
                }

                else if (expense.ExpenseTypeId == 3)
                {
                    leisureExpenseTotal += expense.ExpenseAmount;
                }
            };

            ViewBag.expenseTotal = expenseTotal;
            ViewBag.ExpenseType = expenseTypeList;

            ViewBag.LeisureAmount = budgetBoard.LeisureAmount;
            ViewBag.SavingsAmount = budgetBoard.SavingsAmount;
            ViewBag.LivingAmount = budgetBoard.LivingAmount;

            ViewBag.LeisureTotal = leisureExpenseTotal;
            ViewBag.LivingTotal = livingExpenseTotal;

            return View(result);
        }

        // GET: MonthlyBudgetBoard/Create
        public async Task<IActionResult> Create()
        {
            var budgetBoards = await _budgetBoardService.GetBudgetBoards();
            var boardList = new SelectList(budgetBoards, "BudgetBoardId", "BudgetBoardName");

            ViewBag.BudgetBoard = boardList;
            return View();
        }

        // POST: MonthlyBudgetBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MonthlyBudgetBoardCreate request)
        {
            try
            {
                await _monthlyBudgetService.CreateMonthlyBudgetBoard(request);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.InnerException.Message);
                return View(request);
            }
        }

        // GET: MonthlyBudgetBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MonthlyBudgetBoard/Edit/5
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

        // GET: MonthlyBudgetBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MonthlyBudgetBoard/Delete/5
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

        // POST: Add expense
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddExpense(MonthlyBudgetBoardDetail request)
        {
            try
            {
                // TODO: Add insert logic here

                var expense = new Expense
                {
                    ExpenseName = request.ExpenseModel.ExpenseName,
                    ExpenseAmount = request.ExpenseModel.ExpenseAmount,
                    ExpenseDate = request.ExpenseModel.ExpenseDate,
                    ExpenseTypeId = request.ExpenseModel.ExpenseTypeId
                };

                var expenseId = await _monthlyBudgetService.AddExpenseToMonthlyBudgetBoard(expense);

                var result = await _monthlyBudgetService.BoardExpenseTransaction(request.MonthlyBudgetBoardId, expenseId);

                return RedirectToAction("Details", new { id = request.MonthlyBudgetBoardId });

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }
    }
}
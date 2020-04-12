using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Midas.ViewModels;
using Midas_Models.BudgetBoard;
using Midas_Models.MonthlyExpenses;
using Midas_Service.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Midas.Controllers
{
    public class BudgetBoardController : Controller
    {
        private readonly IBudgetBoardService _budgetBoardService;
        private readonly IMonthlyExpenseService _monthlyExpenseService;
        private readonly IMapper _mapper;

        public BudgetBoardController(IBudgetBoardService budgetBoardService, IMonthlyExpenseService monthlyExpenseService, IMapper mapper)
        {
            _budgetBoardService = budgetBoardService;
            _monthlyExpenseService = monthlyExpenseService;
            _mapper = mapper;
        }

        // GET: BudgetBoard
        public async Task<IActionResult> Index()
        {
            var budgetBoards = await _budgetBoardService.GetBudgetBoards();

            return View(budgetBoards);
        }

        // GET: BudgetBoard/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _budgetBoardService.GetBudgetBoardById(id);

            var expenseTotal = 0.0;
            //var livingExpenseTotal = 0.0;
            //var savingsExpenseTotal = 0.0;
            //var leisureExpenseTotal = 0.0;

            foreach (var expense in result.MonthlyExpenses)
            {
                expenseTotal += expense.BillAmount;

                //if (expense.BillType = "Living")
                //{
                //    livingExpenseTotal += expense.BillAmount;
                //}

                //else if (expense.BillType = "Savings")
                //{
                //    savingsExpenseTotal += expense.BillAmount;
                //}

                //else if (expense.BillType = "Leisure")
                //{
                //    leisureExpenseTotal += expense.BillAmount;
                //}
            }

            ViewBag.expenseTotal = expenseTotal;
            //ViewBag.livingExpenseTotal = livingExpenseTotal
            //ViewBag.savingsExpenseTotal = savingsExpenseTotal
            //ViewBag.leisureExpenseTotal = leisureExpenseTotal

            return View(result);
        }

        // GET: BudgetBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetBoard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BudgetBoardCreateViewModel request)
        {
            try
            {
                // TODO: Add insert logic here

                if (request.LeisurePercentage + request.LivingPercentage + request.SavingsPercentage != 100)
                {
                    ModelState.AddModelError("", "Total Percentages Do Not Equal 100");
                    return View(request);
                }

                var dto = _mapper.Map<BudgetBoardCreate>(request);

                var result = await _budgetBoardService.CreateBudgetBoard(dto);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        // GET: BudgetBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BudgetBoard/Edit/5
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

        // GET: BudgetBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BudgetBoard/Delete/5
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
        public async Task<IActionResult> AddExpense(BudgetBoardDetailDTO request)
        {
            try
            {
                // TODO: Add insert logic here

                var expense = new MonthlyExpenseModel
                {
                    BillName = request.MonthlyExpenseModel.BillName,
                    BillAmount = request.MonthlyExpenseModel.BillAmount
                };

                var expenseId = await _monthlyExpenseService.AddMonthlyExpenseToBudgetBoard(expense);

                var result = await _budgetBoardService.BoardExpenseTransaction(request.BudgetBoardId, expenseId);
                
                return RedirectToAction("Details", new { id = request.BudgetBoardId });

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        // POST: BudgetBoard/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMonthlyExpense(int expenseId, int budgetBoardId)
        {
            try
            {
                await _budgetBoardService.DeleteExpenseTransaction(expenseId);

                return RedirectToAction("Details", new { id = budgetBoardId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return RedirectToAction("Details", new { id = budgetBoardId });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Midas.ViewModels;
using Midas_Models.BudgetBoard;
using Midas_Service.Interfaces;

namespace Midas.Controllers
{
    public class BudgetBoardController : Controller
    {
        private readonly IBudgetBoardService _budgetBoardService;
        private readonly IMapper _mapper;

        public BudgetBoardController(IBudgetBoardService budgetBoardService, IMapper mapper)
        {
            _budgetBoardService = budgetBoardService;
            _mapper = mapper;
        }

        // GET: BudgetBoard
        public async Task<IActionResult> Index()
        {
            var budgetBoards = await _budgetBoardService.GetBudgetBoards();

            return View(budgetBoards);
        }

        // GET: BudgetBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                //var dto = new BudgetBoardCreate
                //{
                //    BudgetBoardName = request.BudgetBoardName,
                //    MonthlyIncome = request.MonthlyIncome,
                //    LeisurePercentage = request.LeisurePercentage,
                //    LivingPercentage = request.LivingPercentage,
                //    SavingsPercentage = request.SavingsPercentage,
                //    LeisureAmount = 0,
                //    LivingAmount = 0,
                //    SavingsAmount = 0,
                //};

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
    }
}
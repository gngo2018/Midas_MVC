using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Entities;
using Midas_Data.Models;
using Midas_Models.BudgetBoard;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class BudgetBoardService : IBudgetBoardService
    {
        private readonly MidasContext _midasContext;
        private readonly IMapper _mapper;

        public BudgetBoardService(MidasContext midasContext, IMapper mapper)
        {
            _midasContext = midasContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateBudgetBoard(BudgetBoardCreate request)
        {
            var fullRequest = CalculateTotalAmounts(request);

            var entity = _mapper.Map<BudgetBoard>(fullRequest);

            await _midasContext.BudgetBoard.AddAsync(entity);

            return await _midasContext.SaveChangesAsync() == 1;

        }

        public async Task<BudgetBoardDetailDTO> GetBudgetBoardById(int budgetBoardId)
        {
            //Get Budget Board Entity Data
            var budgetBoard = await _midasContext.BudgetBoard.FirstOrDefaultAsync(bb => bb.BudgetBoardId == budgetBoardId);

            //Query the Transaction table to see what Monthly Expenses are associated with a Budget Board
            //MonthlyExpenseId to BudgetBoardId relationship
            var budgetBoardMonthlyExpenses = await _midasContext.BudgetBoardMonthlyExpense.Where(bbme => bbme.BudgetBoardId == budgetBoardId).ToArrayAsync();
            
            //New list to store monthly expense data
            var monthlyExpenses = new List<MonthlyExpense>();

            foreach (BudgetBoardMonthlyExpense entity in budgetBoardMonthlyExpenses)
            {
                var expense = _midasContext.MonthlyExpense.FirstOrDefault(me => me.MonthlyExpenseId == entity.MonthlyExpenseId);

                var newExpense = new MonthlyExpense
                {
                    MonthlyExpenseId = expense.MonthlyExpenseId,
                    BillName = expense.BillName,
                    BillAmount = expense.BillAmount
                };

                monthlyExpenses.Add(newExpense);
            }

            var dto = new BudgetBoardDetailDTO
            {
                BudgetBoardId = budgetBoard.BudgetBoardId,
                BudgetBoardName = budgetBoard.BudgetBoardName,
                LivingAmount = budgetBoard.LivingAmount,
                MonthlyExpenses = monthlyExpenses
            };

            return dto;

        }

        public async Task<IEnumerable<BudgetBoardListItem>> GetBudgetBoards()
        {
            var query = await _midasContext.BudgetBoard.ToArrayAsync();

            var response = _mapper.Map<IEnumerable<BudgetBoardListItem>>(query);

            return response;

        }



        private BudgetBoardCreate CalculateTotalAmounts(BudgetBoardCreate request)
        {
            var savingsPercentage = (double)request.SavingsPercentage / 100.0;
            var leisurePercentage = (double)request.LeisurePercentage / 100.0;
            var livingPercentage = (double)request.LivingPercentage / 100;

            request.SavingsAmount = request.MonthlyIncome * savingsPercentage;
            request.LeisureAmount = request.MonthlyIncome * leisurePercentage;
            request.LivingAmount = request.MonthlyIncome * livingPercentage;

            return request;
        }
    }
}

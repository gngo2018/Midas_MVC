using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Models;
using Midas_Models.Expenses;
using Midas_Models.MonthlyBudgetBoard;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class MonthlyBudgetBoardService : IMonthlyBudgetBoardService
    {
        private readonly MidasContext _midasContext;
        private readonly IMapper _mapper;

        public MonthlyBudgetBoardService(MidasContext midasContext, IMapper mapper)
        {
            _midasContext = midasContext;
            _mapper = mapper;
        }

        public async Task<int> AddExpenseToMonthlyBudgetBoard(Expense request)
        { 
            await _midasContext.Expense.AddAsync(request);

            await _midasContext.SaveChangesAsync();

            return request.ExpenseId;
        }

        public async Task<bool> BoardExpenseTransaction(int boardId, int expenseId)
        {
            var transaction = new MonthlyBudgetExpense
            {
                MonthlyBudgetBoardId = boardId,
                ExpenseId = expenseId
            };

            await _midasContext.MonthlyBudgetExpense.AddAsync(transaction);

            return await _midasContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> CreateMonthlyBudgetBoard(MonthlyBudgetBoardCreate request)
        {
            var entity = new MonthlyBudgetBoard
            {
                MonthlyBudgetName = request.MonthlyBudgetName,
                BudgetBoardId = request.BudgetBoardId
            };

            await _midasContext.MonthlyBudgetBoard.AddAsync(entity);

            return await _midasContext.SaveChangesAsync() == 1;

        }

        public async Task<IEnumerable<ExpenseType>> GetExpenseTypes()
        {
            var expenses = await _midasContext.ExpenseType.ToArrayAsync();

            return expenses;        
        }

        public async Task<MonthlyBudgetBoardDetail> GetMonthlyBudgetBoardById(int id)
        {
            //Get Budget Board Entity Data
            var board = await _midasContext.MonthlyBudgetBoard.FirstOrDefaultAsync(mb => mb.MonthlyBudgetId == id);

            //Query the Transaction table to see what Monthly Expenses are associated with a Budget Board
            var budgetExpenses = await _midasContext.MonthlyBudgetExpense.Where(be => be.MonthlyBudgetBoardId == id).ToArrayAsync();

            //New list to store monthly expense data for mapping to the DTO
            var expenses = new List<ExpenseListItem>();

            foreach (MonthlyBudgetExpense entity in budgetExpenses)
            {
                //Query the Expense Table to get table data
                var expense = _midasContext.Expense.FirstOrDefault(e => e.ExpenseId == entity.ExpenseId);
                var expenseType = _midasContext.ExpenseType.FirstOrDefault(e => e.ExpenseTypeId == expense.ExpenseTypeId);

                var newExpense = new ExpenseListItem
                {
                    ExpenseId = expense.ExpenseId,
                    ExpenseName = expense.ExpenseName,
                    ExpenseAmount = expense.ExpenseAmount,
                    ExpenseTypeId = expense.ExpenseTypeId,
                    ExpenseTypeName = expenseType.ExpenseTypeName,
                    ExpenseDate = expense.ExpenseDate
                };

                expenses.Add(newExpense);
            }

            var dto = new MonthlyBudgetBoardDetail
            {
                MonthlyBudgetBoardId = board.MonthlyBudgetId,
                BudgetBoardId = board.BudgetBoardId,
                MonthlyBudgetBoardName = board.MonthlyBudgetName,            
                ExpenseList = expenses
            };

            return dto;

        }

        public async Task<IEnumerable<MonthlyBudgetBoardListItem>> GetMonthlyBudgetBoards()
        {
            var monthlyBudgetBoardListItem = await (from mbb in _midasContext.MonthlyBudgetBoard.Cast<MonthlyBudgetBoard>()
                                              join bb in _midasContext.BudgetBoard on mbb.BudgetBoardId equals bb.BudgetBoardId
                                              select new MonthlyBudgetBoardListItem
                                              {
                                                  MonthlyBudgetBoardId = mbb.MonthlyBudgetId,
                                                  MonthlyBudgetBoardName = mbb.MonthlyBudgetName,
                                                  BudgetBoardName = bb.BudgetBoardName,
                                              })
                                             .ToArrayAsync();


            return monthlyBudgetBoardListItem;
        }
    }
}

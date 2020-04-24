using Midas_Data.Models;
using Midas_Models.MonthlyBudgetBoard;
using Midas_Models.MonthlyExpenses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IMonthlyBudgetBoardService
    {
        Task<IEnumerable<MonthlyBudgetBoardListItem>> GetMonthlyBudgetBoards();
        Task<bool> CreateMonthlyBudgetBoard(MonthlyBudgetBoardCreate request);
        Task<MonthlyBudgetBoardDetail> GetMonthlyBudgetBoardById(int id);
        Task<IEnumerable<ExpenseType>> GetExpenseTypes();
        Task<int> AddExpenseToMonthlyBudgetBoard(Expense request);
        Task<bool> BoardExpenseTransaction(int boardId, int expenseId);


    }
}

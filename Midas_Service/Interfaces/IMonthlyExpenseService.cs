using Midas_Data.Entities;
using Midas_Models.MonthlyExpenses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IMonthlyExpenseService
    {
        Task<IEnumerable<MonthlyExpenseModel>> GetMonthlyExpenses();
        Task<bool> CreateMonthlyExpense(MonthlyExpenseModel request);
        Task<int> AddMonthlyExpenseToBudgetBoard(MonthlyExpenseModel request);

    }
}

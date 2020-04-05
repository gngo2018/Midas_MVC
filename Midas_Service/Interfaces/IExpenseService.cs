using Midas_Models.Expenses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseListItem>> GetExpenses();
        Task<ExpenseListItem> GetExpenseById(int id);
        Task<bool> CreateExpense(ExpenseCreate request);
        Task<bool> DeleteExpense(int id);
        Task<bool> UpdateExpense(ExpenseUpdate request);
    }
}

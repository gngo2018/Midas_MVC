using Midas_Models.Expenses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IExpenseService
    {
        Task<IEnumerable<ExpenseGetListItem>> GetExpenses();
        Task<bool> CreateExpense(ExpenseCreate request);
    }
}

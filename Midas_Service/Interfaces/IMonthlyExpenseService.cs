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
        Task<IEnumerable<MonthlyExpenseListItem>> GetMonthlyExpenses();
        Task<bool> CreateMonthlyExpense(MonthlyExpenseListItem request);

    }
}

using Midas_Models.MonthlyBudgetBoard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IMonthlyBudgetBoardService
    {
        Task<IEnumerable<MonthlyBudgetBoardListItem>> GetMonthlyBudgetBoards();
    }
}

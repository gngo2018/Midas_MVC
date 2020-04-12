using Midas_Models.BudgetBoard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Interfaces
{
    public interface IBudgetBoardService
    {
        Task<IEnumerable<BudgetBoardListItem>> GetBudgetBoards();
        Task<bool> CreateBudgetBoard(BudgetBoardCreate request);
        Task<BudgetBoardDetailDTO> GetBudgetBoardById(int budgetBoardId);
        Task<bool> DeleteExpenseTransaction(int expenseId);
        Task<bool> BoardExpenseTransaction(int boardId, int expenseId);
    }
}

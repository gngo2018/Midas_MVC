using Midas_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midas.ViewModels
{
    public class BudgetBoardDetailViewModel
    {
        public int BudgetBoardId { get; set; }
        public string BudgetBoardName { get; set; }
        public List<MonthlyExpense> MonthlyExpenses { get; set; }

    }
}

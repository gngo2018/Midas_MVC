using System;
using System.Collections.Generic;

namespace Midas_Data.Models
{
    public partial class BudgetBoardMonthlyExpense
    {
        public int BudgetBoardMonthlyExpenseId { get; set; }
        public int BudgetBoardId { get; set; }
        public int MonthlyExpenseId { get; set; }
    }
}

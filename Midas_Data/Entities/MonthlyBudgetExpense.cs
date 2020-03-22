using System;
using System.Collections.Generic;

namespace Midas_Data.Models
{
    public partial class MonthlyBudgetExpense
    {
        public int MonthlyBudgetExpenseId { get; set; }
        public int MonthlyBudgetBoardId { get; set; }
        public int ExpenseId { get; set; }
    }
}

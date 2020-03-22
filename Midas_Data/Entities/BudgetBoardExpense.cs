using System;
using System.Collections.Generic;

namespace Midas_Data.Models
{
    public partial class BudgetBoardExpense
    {
        public int BudgetBoardExpenseId { get; set; }
        public int BudgetBoardId { get; set; }
        public int ExpenseId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Midas_Data.Models
{
    public partial class MonthlyBudgetBoard
    {
        [Key]
        public int MonthlyBudgetId { get; set; }
        public string MonthlyBudgetName { get; set; }
        public int BudgetBoardId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.MonthlyBudgetBoard
{
    public class MonthlyBudgetBoardListItem
    {
        [Display(Name = "Monthly Board Id")]
        public int MonthlyBudgetBoardId { get; set; }
        [Display(Name = "Monthly Board Name")]
        public string MonthlyBudgetBoardName { get; set; }
        [Display(Name = "Parent Budget Board")]
        public string BudgetBoardName { get; set; }
    }
}

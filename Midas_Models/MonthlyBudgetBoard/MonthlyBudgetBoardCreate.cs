using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.MonthlyBudgetBoard
{
    public class MonthlyBudgetBoardCreate
    {
        [Display(Name = "Monthly Board Name")]
        [Required]
        public string MonthlyBudgetName { get; set; }
        [Display(Name = "Parent Budget Board")]
        [Required]
        public int BudgetBoardId { get; set; }
    }
}

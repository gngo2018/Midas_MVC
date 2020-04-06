using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.BudgetBoard
{
    public class BudgetBoardListItem
    {
        public int BudgetBoardId { get; set; }
        [Display(Name = "Board Name")]
        public string BudgetBoardName { get; set; }
        [Display(Name = "Monthly Income")]
        [DataType(DataType.Currency)]
        public double? MonthlyIncome { get; set; }
        [Display(Name = "Living Amount")]
        [DataType(DataType.Currency)]
        public double? LivingAmount { get; set; }
        [Display(Name = "Living Percentage")]
        public int? LivingPercentage { get; set; }
        [Display(Name = "Savings Amount")]
        [DataType(DataType.Currency)]
        public double? SavingsAmount { get; set; }
        [Display(Name = "Savings Percentage")]
        public int? SavingsPercentage { get; set; }
        [Display(Name = "Leisure Amount")]
        [DataType(DataType.Currency)]
        public double? LeisureAmount { get; set; }
        [Display(Name = "Leisure Percentage")]
        public int? LeisurePercentage { get; set; }
    }
}

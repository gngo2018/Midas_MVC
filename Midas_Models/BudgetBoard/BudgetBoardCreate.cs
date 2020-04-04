using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.BudgetBoard
{
    public class BudgetBoardCreate
    {
        public string BudgetBoardName { get; set; }
        public double? MonthlyIncome { get; set; }
        public double? LivingAmount { get; set; }
        public int? LivingPercentage { get; set; }
        public double? SavingsAmount { get; set; }
        public int? SavingsPercentage { get; set; }
        public double? LeisureAmount { get; set; }
        public int? LeisurePercentage { get; set; }
    }
}

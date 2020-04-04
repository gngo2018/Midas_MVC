using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Midas.ViewModels
{
    public class BudgetBoardCreateViewModel
    {
        [Display(Name = "Board Name")]
        public string BudgetBoardName { get; set; }
        [Display(Name = "Monthly Income")]
        public double? MonthlyIncome { get; set; }
        [Display(Name = "Living Percentage")]
        public int? LivingPercentage { get; set; }
        [Display(Name = "Savings Percentage")]
        public int? SavingsPercentage { get; set; }
        [Display(Name = "Leisure Percentage")]
        public int? LeisurePercentage { get; set; }
    }
}

using Midas_Data.Models;
using Midas_Models.Expenses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.MonthlyBudgetBoard
{
    public class MonthlyBudgetBoardDetail
    {
        [Display(Name = "Monthly Board Id")]
        public int MonthlyBudgetBoardId { get; set; }
        public int BudgetBoardId { get; set; }
        [Display(Name = "Monthly Board Name")]
        public string MonthlyBudgetBoardName { get; set; }
        public List<ExpenseListItem> ExpenseList { get; set; }
        public virtual Expense ExpenseModel { get; set; }


        //TODOs
        public double? LivingAmount { get; set; }
        [DataType(DataType.Currency)]
        public double? SavingsAmount { get; set; }
        [DataType(DataType.Currency)]
        public double? LeisureAmount { get; set; }

    }
}

using Midas_Data.Entities;
using Midas_Models.MonthlyExpenses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.BudgetBoard
{
    public class BudgetBoardDetailDTO
    {
        public int BudgetBoardId { get; set; }
        public string BudgetBoardName { get; set; }
        [DataType(DataType.Currency)]
        public double? LivingAmount { get; set; }
        [DataType(DataType.Currency)]
        public double? SavingsAmount { get; set; }
        [DataType(DataType.Currency)]
        public double? LeisureAmount { get; set; }
        public List<MonthlyExpense> MonthlyExpenses { get; set; }

        public virtual MonthlyExpenseModel MonthlyExpenseModel {get; set;}
    }
}

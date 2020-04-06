using Midas_Data.Entities;
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
        public List<MonthlyExpense> MonthlyExpenses { get; set; }
    }
}

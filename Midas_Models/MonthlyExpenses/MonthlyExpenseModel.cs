using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.MonthlyExpenses
{
    public class MonthlyExpenseModel
    {
        public int MonthlyExpenseId { get; set; }
        [Required]
        [Display(Name = "Bill Name")]
        public string BillName { get; set; }
        [Required]
        [Display(Name = "Bill Amount")]
        [DataType(DataType.Currency)]
        public double BillAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Data.Entities
{
    public class MonthlyExpense
    {
        [Key]
        public int MonthlyExpenseId { get; set; }
        [Required]
        public string BillName { get; set; }
        [Required]
        public double BillAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Midas_Data.Models
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public double ExpenseAmount { get; set; }
        public int ExpenseTypeId { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}

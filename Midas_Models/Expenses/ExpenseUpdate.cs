using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.Expenses
{
    public class ExpenseUpdate
    {
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]

        public double ExpenseAmount { get; set; }
        public int ExpenseTypeId { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}

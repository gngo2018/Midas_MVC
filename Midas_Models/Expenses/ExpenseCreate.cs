using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Midas_Models.Expenses
{
    public class ExpenseCreate
    {
        public string ExpenseName { get; set; }
        public double ExpenseAmount { get; set; }
        public int ExpenseTypeId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
    }
}

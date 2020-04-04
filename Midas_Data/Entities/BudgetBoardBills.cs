using System;
using System.Collections.Generic;

namespace Midas_Data.Models
{
    public partial class BudgetBoardBills
    {
        public int BudgetBoardBillsId { get; set; }
        public int BudgetBoardId { get; set; }
        public int BillId { get; set; }
    }
}

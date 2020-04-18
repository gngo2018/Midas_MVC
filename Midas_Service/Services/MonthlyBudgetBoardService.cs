using Microsoft.EntityFrameworkCore;
using Midas_Data.Models;
using Midas_Models.MonthlyBudgetBoard;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class MonthlyBudgetBoardService : IMonthlyBudgetBoardService
    {
        private readonly MidasContext _midasContext;

        public MonthlyBudgetBoardService(MidasContext midasContext)
        {
            _midasContext = midasContext;
        }

        public async Task<IEnumerable<MonthlyBudgetBoardListItem>> GetMonthlyBudgetBoards()
        {
            var monthlyBudgetBoardListItem = await (from mbb in _midasContext.MonthlyBudgetBoard.Cast<MonthlyBudgetBoard>()
                                              join bb in _midasContext.BudgetBoard on mbb.BudgetBoardId equals bb.BudgetBoardId
                                              select new MonthlyBudgetBoardListItem
                                              {
                                                  MonthlyBudgetBoardId = mbb.MonthlyBudgetId,
                                                  MonthlyBudgetBoardName = mbb.MonthlyBudgetName,
                                                  BudgetBoardName = bb.BudgetBoardName,
                                              })
                                             .ToArrayAsync();


            return monthlyBudgetBoardListItem;
        }
    }
}

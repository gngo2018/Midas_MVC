using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Entities;
using Midas_Data.Models;
using Midas_Models.MonthlyExpenses;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class MonthlyExpenseService : IMonthlyExpenseService
    {
        private readonly MidasContext _midasContext;
        private readonly IMapper _mapper;

        public MonthlyExpenseService(MidasContext midasContext, IMapper mapper)
        {
            _midasContext = midasContext;
            _mapper = mapper;
        }

        public async Task<int> AddMonthlyExpenseToBudgetBoard(MonthlyExpenseModel request)
        {
            var entity = _mapper.Map<MonthlyExpense>(request);

            await _midasContext.MonthlyExpense.AddAsync(entity);

            await _midasContext.SaveChangesAsync();

            return entity.MonthlyExpenseId;
        }

        public async Task<bool> CreateMonthlyExpense(MonthlyExpenseModel request)
        {
            var entity = _mapper.Map<MonthlyExpense>(request);

            await _midasContext.MonthlyExpense.AddAsync(entity);

            return await _midasContext.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<MonthlyExpenseModel>> GetMonthlyExpenses()
        {
            var expenses = await _midasContext.MonthlyExpense.ToArrayAsync();

            var response = _mapper.Map<IEnumerable<MonthlyExpenseModel>>(expenses);

            return response;

        }
    }
}

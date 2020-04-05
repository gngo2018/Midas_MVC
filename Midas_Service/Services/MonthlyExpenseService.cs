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

        public async Task<bool> CreateMonthlyExpense(MonthlyExpenseListItem request)
        {
            var entity = _mapper.Map<MonthlyExpense>(request);

            await _midasContext.MonthlyExpense.AddAsync(entity);

            return await _midasContext.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<MonthlyExpenseListItem>> GetMonthlyExpenses()
        {
            var expenses = await _midasContext.MonthlyExpense.ToArrayAsync();

            var response = _mapper.Map<IEnumerable<MonthlyExpenseListItem>>(expenses);

            return response;

        }
    }
}

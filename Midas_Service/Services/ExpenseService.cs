using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Models;
using Midas_Models.Expenses;
using Midas_Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly MidasContext _midasContext;
        private readonly IMapper _mapper;

        public ExpenseService(MidasContext midasContext, IMapper mapper)
        {
            _midasContext = midasContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateExpense(ExpenseCreate request)
        {
            var entity = _mapper.Map<Expense>(request);

            await _midasContext.Expense.AddAsync(entity);

            return await _midasContext.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<ExpenseGetListItem>> GetExpenses()
        {
            var query = await _midasContext.Expense.ToArrayAsync();

            var rao = _mapper.Map<IEnumerable<ExpenseGetListItem>>(query);

            return rao;
        }
    }
}

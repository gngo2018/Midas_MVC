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

        public async Task<bool> DeleteExpense(int id)
        {
            var expense = await _midasContext.Expense.FirstOrDefaultAsync(e => e.ExpenseId == id);
            _midasContext.Remove(expense);

            return await _midasContext.SaveChangesAsync() == 1;

        }

        public async Task<IEnumerable<ExpenseListItem>> GetExpenses()
        {
            var expenses = await _midasContext.Expense.ToArrayAsync();

            var rao = _mapper.Map<IEnumerable<ExpenseListItem>>(expenses);

            return rao;
        }

        public async Task<ExpenseListItem> GetExpenseById(int id)
        {
            var expense = await _midasContext.Expense.FirstOrDefaultAsync(e => e.ExpenseId == id);
            var response = _mapper.Map<ExpenseListItem>(expense);

            return response;

        }

        public async Task<bool> UpdateExpense(ExpenseUpdate request)
        {
            var expense = await _midasContext.Expense.FirstOrDefaultAsync(e => e.ExpenseId == request.ExpenseId);

            expense.ExpenseName = request.ExpenseName;
            expense.ExpenseAmount = request.ExpenseAmount;
            expense.ExpenseTypeId = request.ExpenseTypeId;
            expense.ExpenseDate = request.ExpenseDate;

            return await _midasContext.SaveChangesAsync() == 1;

        }
    }
}

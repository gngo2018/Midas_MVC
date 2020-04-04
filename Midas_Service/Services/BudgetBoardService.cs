using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Midas_Data.Models;
using Midas_Models.BudgetBoard;
using Midas_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Midas_Service.Services
{
    public class BudgetBoardService : IBudgetBoardService
    {
        private readonly MidasContext _midasContext;
        private readonly IMapper _mapper;

        public BudgetBoardService(MidasContext midasContext, IMapper mapper)
        {
            _midasContext = midasContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateBudgetBoard(BudgetBoardCreate request)
        {
            var fullRequest = CalculateTotalAmounts(request);

            var entity = _mapper.Map<BudgetBoard>(fullRequest);

            await _midasContext.BudgetBoard.AddAsync(entity);

            return await _midasContext.SaveChangesAsync() == 1;

        }

        public async Task<IEnumerable<BudgetBoardListItem>> GetBudgetBoards()
        {
            var query = await _midasContext.BudgetBoard.ToArrayAsync();

            var response = _mapper.Map<IEnumerable<BudgetBoardListItem>>(query);

            return response;

        }

        private BudgetBoardCreate CalculateTotalAmounts(BudgetBoardCreate request)
        {
            var savingsPercentage = (double)request.SavingsPercentage / 100.0;
            var leisurePercentage = (double)request.LeisurePercentage / 100.0;
            var livingPercentage = (double)request.LivingPercentage / 100;

            request.SavingsAmount = request.MonthlyIncome * savingsPercentage;
            request.LeisureAmount = request.MonthlyIncome * leisurePercentage;
            request.LivingAmount = request.MonthlyIncome * livingPercentage;

            return request;
        }
    }
}

using AutoMapper;
using Midas_Data.Entities;
using Midas_Models.MonthlyExpenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midas.MappingProfiles
{
    public class MonthlyExpenseMappingProfile : Profile
    {
        public MonthlyExpenseMappingProfile()
        {
            CreateMap<MonthlyExpense, MonthlyExpenseListItem>();
            CreateMap<MonthlyExpenseListItem, MonthlyExpense>();
        }
    }
}

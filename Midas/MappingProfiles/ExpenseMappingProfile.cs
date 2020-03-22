using AutoMapper;
using Midas_Data.Models;
using Midas_Models.Expenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midas.MappingProfiles
{
    public class ExpenseMappingProfile : Profile
    {
        public ExpenseMappingProfile()
        {
            //Get Mapping
            CreateMap<Expense, ExpenseGetListItem>();
            //Create Mapping
            CreateMap<ExpenseCreate, Expense>();
        }
    }
}

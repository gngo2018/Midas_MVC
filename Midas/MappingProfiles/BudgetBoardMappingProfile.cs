using AutoMapper;
using Midas.ViewModels;
using Midas_Data.Models;
using Midas_Models.BudgetBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midas.MappingProfiles
{
    public class BudgetBoardMappingProfile : Profile
    {
        public BudgetBoardMappingProfile()
        {
            //GET Mapping
            CreateMap<BudgetBoard, BudgetBoardListItem>();
            //CREATE Mapping
            CreateMap<BudgetBoardCreateViewModel, BudgetBoardCreate>();
            CreateMap<BudgetBoardCreate, BudgetBoard>();
        }
    }
}

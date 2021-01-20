using AutoMapper;
using ExpenseManagerAPI.Entities;
using ExpenseManagerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManagerAPI.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ExpenseDetail, ExpenseDetailDto>();
            CreateMap<ExpenseCategory, ExpenseCategoryDto>();
           
        }
    }
}

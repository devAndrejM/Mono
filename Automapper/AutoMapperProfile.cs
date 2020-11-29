using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Coreapp.Models;
using Coreapp.ViewModels;

namespace Coreapp.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMake, VehicleMakeView>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelView>().ReverseMap();
            
            
        }
    }
}

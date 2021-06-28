using AutoMapper;
using GameStore.Dtos;
using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.MapperProfiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehoueReadDto>();
            CreateMap<WarehouseDto, Warehouse>();
        }
    }
}

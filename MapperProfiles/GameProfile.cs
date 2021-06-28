 using AutoMapper;
using GameStore.Dtos;
using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.MapperProfiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameReadDto>();
            CreateMap<GameDto, Game>();
        }
    }
}

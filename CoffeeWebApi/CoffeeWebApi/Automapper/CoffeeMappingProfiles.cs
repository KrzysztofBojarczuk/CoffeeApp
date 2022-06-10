using AutoMapper;
using CoffeeWebApi.Dtos;
using CoffeeWebApi.Models;

namespace CoffeeWebApi.Automapper
{
    public class CoffeeMappingProfiles : Profile
    {
        public CoffeeMappingProfiles()
        {
            CreateMap<CoffeeCreateDto, Coffee>();
            CreateMap<Coffee, CoffeeGetDto>();
        }
    }
}

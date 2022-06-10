using AutoMapper;
using CoffeeWebApi.Controllers;
using CoffeeWebApi.Dtos;
using CoffeeWebApi.Models;
using CoffeeWebApi.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeWebApiXunit.Tests.Controller
{
    public class ControllerTest
    {
        private readonly ICoffeeRepository _coffeeeReposiotry;
        private readonly IMapper _mapper;

        public ControllerTest()
        {
            _coffeeeReposiotry = A.Fake<ICoffeeRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task CoffeeController_GetAllCoffee_ReturnOkAsync()
        {
            //Arrange
            var coffees = A.Fake<ICollection<CoffeeGetDto>>();

            var coffeeList = A.Fake<List<CoffeeGetDto>>();

            A.CallTo(() => _mapper.Map<List<CoffeeGetDto>>(coffees)).Returns(coffeeList);

            var controller = new CoffeeController(_coffeeeReposiotry, _mapper);
            //Act

            var result = await controller.GetAllCoffe();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));            
        }
        [Fact]
        public async Task CoffeeController_GetCoffeeById_ReturnOkAsync()
        {
            //Arrange
            int coffeeId = 1;
            var coffeeMap = A.Fake<Coffee>();
            var coffee = A.Fake<Coffee>();
            var coffeeCreate = A.Fake<CoffeeCreateDto>();
            var coffees = A.Fake<ICollection<CoffeeGetDto>>();
            var coffeeList = A.Fake<List<CoffeeGetDto>>();

            A.CallTo(() => _mapper.Map<Coffee>(coffeeCreate)).Returns(coffee);
            A.CallTo(() => _coffeeeReposiotry.CreateCoffeeAsync(coffee)).Returns(coffee);

            var controller = new CoffeeController(_coffeeeReposiotry, _mapper);

            //Act
            var result = controller.CreateCoffee(coffeeCreate);

            //Assert

            result.Should().NotBeNull();


        }
    }
    
}

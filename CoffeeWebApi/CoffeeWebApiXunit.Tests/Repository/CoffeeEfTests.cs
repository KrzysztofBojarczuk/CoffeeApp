using CoffeeWebApi.Data;
using CoffeeWebApi.Models;
using CoffeeWebApi.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeWebApiXunit.Tests.Repository
{
    public class CoffeeEfTests
    {
        private async Task<DataContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;

            var databaseContext = new DataContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Coffees.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Coffees.Add(
                        new Coffee()
                        {
                            Type = "Kawa",
                            Bean = "Arabica",
                            Location = "Koszalin",
                            DateCreated = DateTime.Now,

                            Score = 5,
                            NoOfShots = 5
                        });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async Task GetCoffeeById()
        {
            //Arrange 
            var coffee = new Coffee()
            {
                Type = "Kawa",
                Bean = "Arabica",
                Location = "Koszalin",
                DateCreated = DateTime.Now,

                Score = 5,
                NoOfShots = 5
            };

            //Act
            var dbContext = await GetDatabaseContext();
            var coffeeRepository = new CoffeeRepository(dbContext);

            //Assert

            var result = coffeeRepository.CreateCoffeeAsync(coffee);

            result.Should();
        }
        [Fact]
        public async void CoffeeRepository()
        {
            //Arrange
            var coffeId = 1;
            var dbContext = await GetDatabaseContext();
            var coffeeRepository = new CoffeeRepository(dbContext);

            //Act
            var result = coffeeRepository.GetCoffeeByIdAsync(coffeId);

            //Assert

            result.Should().NotBe(0);
        }
    }
}

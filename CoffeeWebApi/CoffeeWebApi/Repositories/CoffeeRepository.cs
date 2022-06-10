using CoffeeWebApi.Data;
using CoffeeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeWebApi.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private DataContext _ctx;

        public CoffeeRepository(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Coffee> CreateCoffeeAsync(Coffee coffee)
        {
            _ctx.Coffees.Add(coffee);
            await _ctx.SaveChangesAsync();
            return coffee;
        }

        public async Task<Coffee> DeleteCoffeeAsync(int id)
        {
            var coffee = await _ctx.Coffees.SingleOrDefaultAsync(c => c.Id == id);

            if (coffee == null)
            {
                return null;
            }
            _ctx.Coffees.Remove(coffee);
            await _ctx.SaveChangesAsync();
            return coffee;
        }

        public async Task<List<Coffee>> GetAllCoffeesAsync()
        {
            return await _ctx.Coffees.ToListAsync();
        }

        public async Task<Coffee> GetCoffeeByIdAsync(int id)
        {
            var coffee = await _ctx.Coffees.FirstOrDefaultAsync(c => c.Id == id);
            if (coffee == null)
            {
                return null;
            }
            return coffee;
        }

        public async Task<Coffee> UpdateCoffeeAsync(Coffee updatedCoffee)
        {
            _ctx.Coffees.Update(updatedCoffee);
            await _ctx.SaveChangesAsync();
            return updatedCoffee;
        }
    }
}

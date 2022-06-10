using CoffeeWebApi.Models;

namespace CoffeeWebApi.Repositories
{
    public interface ICoffeeRepository
    {
        Task<List<Coffee>> GetAllCoffeesAsync();
        Task<Coffee> GetCoffeeByIdAsync(int id);
        Task<Coffee> CreateCoffeeAsync(Coffee coffee);
        Task<Coffee> UpdateCoffeeAsync(Coffee updatedCoffee);
        Task<Coffee> DeleteCoffeeAsync(int id);
    }
}

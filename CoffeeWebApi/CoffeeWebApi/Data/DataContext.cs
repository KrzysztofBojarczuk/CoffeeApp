using CoffeeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Coffee> Coffees { get; set; }
    }

}

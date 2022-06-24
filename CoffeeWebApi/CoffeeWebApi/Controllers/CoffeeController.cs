using AutoMapper;
using CoffeeWebApi.Dtos;
using CoffeeWebApi.Models;
using CoffeeWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeRepository;
        private readonly IMapper _mapper;

        public CoffeeController(ICoffeeRepository coffeRepository, IMapper mapper)
        {
            _coffeRepository = coffeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCoffe()
        {
            var coffee = await _coffeRepository.GetAllCoffeesAsync();
            var coffeeDto = _mapper.Map<List<CoffeeGetDto>>(coffee);
            return Ok(coffeeDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoffeeById(int id)
        {
            var coffee = await _coffeRepository.GetCoffeeByIdAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }
            var coffeeGet = _mapper.Map<CoffeeGetDto>(coffee);
            return Ok(coffeeGet);
        }
        [HttpPost]        
        public async Task<IActionResult> CreateCoffee([FromBody] CoffeeCreateDto coffeeCreateDto)
        {
            var coffee = _mapper.Map<Coffee>(coffeeCreateDto);
            await _coffeRepository.CreateCoffeeAsync(coffee);
            var coffeeGet = _mapper.Map<CoffeeGetDto>(coffee);
            return CreatedAtAction(nameof(GetCoffeeById), new { id = coffee.Id }, coffeeGet);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoffe([FromBody] CoffeeCreateDto update, int id)
        {
            var toUpdate = _mapper.Map<Coffee>(update);
            toUpdate.Id = id;
            await _coffeRepository.UpdateCoffeeAsync(toUpdate);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffee(int id)
        {
            var coffee = await _coffeRepository.DeleteCoffeeAsync(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

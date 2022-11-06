using Microsoft.AspNetCore.Mvc;
using MongoDbExample.Models;
using MongoDbExample.Repositories;

namespace MongoDbExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    public readonly IAnimalRepository _animalRepository;

    public AnimalController(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _animalRepository.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _animalRepository.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Animal newAnimal)
    {
        await _animalRepository.CreateAsync(newAnimal);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Animal animalToUpdate)
    {
        await _animalRepository.UpdateAsync(id, animalToUpdate);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        await _animalRepository.DeleteAsync(id);
        return Ok();
    }
}

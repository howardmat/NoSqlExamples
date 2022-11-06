using CosmosDbExample.Models;
using CosmosDbExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDbExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    public readonly IAnimalRepository _animalCosmosService;

    public AnimalController(IAnimalRepository animalCosmosService)
    {
        _animalCosmosService = animalCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _animalCosmosService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _animalCosmosService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Animal newAnimal)
    {
        newAnimal.Id = Guid.NewGuid().ToString();
        var result = await _animalCosmosService.AddAsync(newAnimal);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Animal animalToUpdate)
    {
        var result = await _animalCosmosService.UpdateAsync(animalToUpdate);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _animalCosmosService.DeleteAsync(id);
        return Ok();
    }
}

using CosmosDbExample.Models;
using CosmosDbExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDbExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    public readonly ICarRepository _carCosmosService;

    public CarController(ICarRepository carCosmosService)
    {
        _carCosmosService = carCosmosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _carCosmosService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _carCosmosService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Car newCar)
    {
        newCar.Id = Guid.NewGuid().ToString();
        var result = await _carCosmosService.AddAsync(newCar);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Car carToUpdate)
    {
        var result = await _carCosmosService.UpdateAsync(carToUpdate);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _carCosmosService.DeleteAsync(id);
        return Ok();
    }
}

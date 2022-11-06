using CosmosDbExample.Models;
using CosmosDbExample.Options;
using Microsoft.Extensions.Options;

namespace CosmosDbExample.Repositories;

public class CarRepository : CosmosRepository<Car>, ICarRepository
{
    private const string CosmosContainerName = "Vehicles";

    public CarRepository(IOptions<CosmosDbOptions> cosmosDbOptions)
        : base(CosmosContainerName, cosmosDbOptions)
    { }
}
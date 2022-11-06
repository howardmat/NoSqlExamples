using CosmosDbExample.Models;
using CosmosDbExample.Options;
using Microsoft.Extensions.Options;

namespace CosmosDbExample.Repositories;

public class AnimalRepository : CosmosRepository<Animal>, IAnimalRepository
{
    private const string CosmosContainerName = "Animals";

    public AnimalRepository(IOptions<CosmosDbOptions> cosmosDbOptions)
        : base(CosmosContainerName, cosmosDbOptions)
    { }
}

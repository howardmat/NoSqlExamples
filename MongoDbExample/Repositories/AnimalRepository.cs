using Microsoft.Extensions.Options;
using MongoDbExample.Models;
using MongoDbExample.Options;

namespace MongoDbExample.Repositories;

public class AnimalRepository : MongoDbRepository<Animal>, IAnimalRepository
{
    private const string ContainerName = "Animals";

    public AnimalRepository(IOptions<MongoDbSettings> mongoDbSettings)
        : base(ContainerName, mongoDbSettings)
    { }
}

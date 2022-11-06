namespace MongoDbExample.Models;

public class Animal : BaseMongoModel
{
    public string Name { get; set; } = null!;
    public string Species { get; set; } = null!;
}

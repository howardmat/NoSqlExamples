using Newtonsoft.Json;

namespace CosmosDbExample.Models;

public class Car : BaseCosmosModel
{
    [JsonProperty("make")]
    public string? Make { get; set; }

    [JsonProperty("model")]
    public string? Model { get; set; }
}
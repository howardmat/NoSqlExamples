using Newtonsoft.Json;

namespace CosmosDbExample.Models;

public abstract class BaseCosmosModel
{
    [JsonProperty("id")]
    public string? Id { get; set; }
}
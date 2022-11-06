using CosmosDbExample.Options;
using CosmosDbExample.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

#region Swagger Configuration
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Repository configuration
builder.Services.Configure<CosmosDbOptions>(builder.Configuration.GetSection("AzureCosmosDbSettings"));

builder.Services.AddSingleton<ICarRepository, CarRepository>();
builder.Services.AddSingleton<IAnimalRepository, AnimalRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

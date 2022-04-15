using System.Text.Json;
using System.Text.Json.Serialization;
using SharedKernel;
using Web.Utils;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(e =>
{
    e.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    e.JsonSerializerOptions.PropertyNamingPolicy = new LowerCaseNamingPolicy();
});
builder.Services.ConfigureServices();

/*
var containerBuilder = new ContainerBuilder();
containerBuilder.ConfigureServices();
containerBuilder.ConfigureControllers();
containerBuilder.Build();
*/

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
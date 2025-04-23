using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte a CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Usar CORS no pipeline
app.UseCors();

// Endpoint para salvar a localização no arquivo
app.MapPost("/api/location", async (HttpContext context) =>
{
    var locationData = await JsonSerializer.DeserializeAsync<LocationData>(context.Request.Body);

    if (locationData == null)
    {
        return Results.BadRequest(new { message = "Invalid location data." });
    }

    // Salvar a localização no arquivo location.txt
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "location.txt");
    await File.AppendAllTextAsync(filePath, JsonSerializer.Serialize(locationData) + Environment.NewLine);

    return Results.Ok(new { message = "Location saved successfully." });
});

app.Run();

// Modelo para os dados de localização
record LocationData(float Latitude, float Longitude, string Timestamp);
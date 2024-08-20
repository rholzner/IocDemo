var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddTransient<lvl1>();
builder.Services.AddScoped<lvl1>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (IWeatherForecastService weatherForecastService) =>
{
    return await weatherForecastService.GetForecast();
})
.WithName("GetWeatherForecast");

app.Run();


public class lvl1 : IDisposable
{
    private WeatherForecast[] cachedForecasts;

    public lvl1()
    {
        Console.WriteLine("lvl1 created");
    }
    public void Dispose()
    {
        Console.WriteLine("lvl1 disposed");
    }

    public async Task<WeatherForecast[]> GetForecast()
    {
        if (cachedForecasts is not null)
        {
            return cachedForecasts;
        }

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        await Task.Delay(5000);

        cachedForecasts = Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();

        return cachedForecasts;
    }
}

public class WeatherForecastService : IDisposable, IWeatherForecastService
{
    public WeatherForecastService(lvl1 lvl1)
    {
        Console.WriteLine("WeatherForecastService created");
        Lvl1 = lvl1;
    }

    public lvl1 Lvl1 { get; }

    public void Dispose()
    {
        Console.WriteLine("WeatherForecastService disposed");
    }

    public async Task<WeatherForecast[]> GetForecast()
    {
        return await Lvl1.GetForecast();
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

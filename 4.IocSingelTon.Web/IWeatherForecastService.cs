public interface IWeatherForecastService
{
    Task<WeatherForecast[]> GetForecast();
}
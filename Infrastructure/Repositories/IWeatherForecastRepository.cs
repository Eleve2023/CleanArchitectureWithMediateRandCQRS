using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task AddWeatherForecastAsync(WeatherForecast weatherForecast);
        Task DeleteWeatherForecastAsync(Guid guid);
        Task<WeatherForecast?> GetWeatherForecastByIdAsync(Guid id);
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync();
        Task UpdateWeatherForecastAsync(WeatherForecast weatherForecast);
        Task<bool> WeatherForecastExistsAsync(Guid id);
    }
}
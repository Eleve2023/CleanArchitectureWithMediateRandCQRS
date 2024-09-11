using Application.Features.WeatherForecasts.DTOs;

namespace Application.Services
{
    public interface IWeatherForecastService
    {
        Task<Guid> CreateWeatherForecastAsync(CreateWeatherForecastDto createWeatherForecastDto);
        Task DeleteWeatherForecastAsync(Guid id);
        Task<WeatherForecastDto?> GetWeatherForecastByIdAsync(Guid id);
        Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastsAsync();
        Task UpdateWeatherForecastAsync(UpdateWeatherForecastDto updateWeatherForecastDto);
    }
}
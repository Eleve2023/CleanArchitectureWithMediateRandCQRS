using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class WeatherForecastRepository(AppDbContext context) : IWeatherForecastRepository
    {
        private readonly AppDbContext context = context;

        public async Task AddWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            context.WeatherForecasts.Add(weatherForecast);
            await context.SaveChangesAsync();
        }

        public async Task DeleteWeatherForecastAsync(Guid guid)
        {
            bool exists = await WeatherForecastExistsAsync(guid);
            if (!exists)
            {
                throw new EntityNotFoundException(nameof(WeatherForecast), guid);
            }
            var weatherForecast = new WeatherForecast { Id = guid };
            context.WeatherForecasts.Attach(weatherForecast);
            context.WeatherForecasts.Remove(weatherForecast);
            await context.SaveChangesAsync();
        }

        public async Task UpdateWeatherForecastAsync(WeatherForecast weatherForecast)
        {
            context.WeatherForecasts.Update(weatherForecast);
            await context.SaveChangesAsync();
        }

        public async Task<WeatherForecast?> GetWeatherForecastByIdAsync(Guid id)
        {
            return await context.WeatherForecasts.FindAsync(id);
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastsAsync()
        {
            return await context.WeatherForecasts.ToListAsync();
        }

        public async Task<bool> WeatherForecastExistsAsync(Guid id)
        {
            return await context.WeatherForecasts.AnyAsync(e => e.Id == id);
        }
    }
}

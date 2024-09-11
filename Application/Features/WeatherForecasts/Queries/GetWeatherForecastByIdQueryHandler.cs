using Application.Features.WeatherForecasts.DTOs;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Features.WeatherForecasts.Queries
{
    public class GetWeatherForecastByIdQueryHandler(IWeatherForecastRepository weatherForecastRepository) : IRequestHandler<GetWeatherForecastByIdQuery, WeatherForecastDto?>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository;

        public async Task<WeatherForecastDto?> Handle(GetWeatherForecastByIdQuery request, CancellationToken cancellationToken)
        {
            var weatherForecast = await _weatherForecastRepository.GetWeatherForecastByIdAsync(request.Id);
            if (weatherForecast == null)
            {
                return null;
            }
            return new WeatherForecastDto
            {
                Id = weatherForecast.Id,
                Date = weatherForecast.Date,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary
            };
        }
    }
}

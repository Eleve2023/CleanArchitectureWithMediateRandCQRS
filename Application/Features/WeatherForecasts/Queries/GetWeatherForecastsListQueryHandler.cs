using Application.Features.WeatherForecasts.DTOs;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Features.WeatherForecasts.Queries
{
    public class GetWeatherForecastsListQueryHandler(IWeatherForecastRepository weatherForecastRepository) : IRequestHandler<GetWeatherForecastsListQuery, List<WeatherForecastDto>>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository;

        public async Task<List<WeatherForecastDto>> Handle(GetWeatherForecastsListQuery request, CancellationToken cancellationToken)
        {
            var weatherForecasts = await _weatherForecastRepository.GetWeatherForecastsAsync();
            return weatherForecasts.Select(wf => new WeatherForecastDto
            {
                Id = wf.Id,
                Date = wf.Date,
                TemperatureC = wf.TemperatureC,
                Summary = wf.Summary
            }).ToList();
        }
    }
}

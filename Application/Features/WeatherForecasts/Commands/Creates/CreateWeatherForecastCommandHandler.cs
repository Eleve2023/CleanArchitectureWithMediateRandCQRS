using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Features.WeatherForecasts.Commands.Creates
{
    public class CreateWeatherForecastCommandHandler(IWeatherForecastRepository weatherForecastRepository) : IRequestHandler<CreateWeatherForecastCommand, Guid>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository;

        public async Task<Guid> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = request.Date,
                TemperatureC = request.TemperatureC,
                Summary = request.Summary
            };

            await _weatherForecastRepository.AddWeatherForecastAsync(weatherForecast);

            return weatherForecast.Id;
        }
    }
}

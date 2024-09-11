using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Features.WeatherForecasts.Commands.Updates
{
    public class UpdateWeatherForecastCommandHandler(IWeatherForecastRepository weatherForecastRepository) : IRequestHandler<UpdateWeatherForecastCommand>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository;

        public async Task Handle(UpdateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var weatherForecast = await _weatherForecastRepository.GetWeatherForecastByIdAsync(request.Id)
                ?? throw new EntityNotFoundException(nameof(WeatherForecast), request.Id);
            weatherForecast.Date = request.Date;
            weatherForecast.TemperatureC = request.TemperatureC;
            weatherForecast.Summary = request.Summary;

            await _weatherForecastRepository.UpdateWeatherForecastAsync(weatherForecast);
        }
    }
}

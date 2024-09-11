using Infrastructure.Repositories;
using MediatR;

namespace Application.Features.WeatherForecasts.Queries
{
    public class WeatherForecastExistsQueryHandler(IWeatherForecastRepository weatherForecastRepository) : IRequestHandler<WeatherForecastExistsQuery, bool>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository;

        public async Task<bool> Handle(WeatherForecastExistsQuery request, CancellationToken cancellationToken)
        {
            return await _weatherForecastRepository.WeatherForecastExistsAsync(request.Id);
        }
    }

}

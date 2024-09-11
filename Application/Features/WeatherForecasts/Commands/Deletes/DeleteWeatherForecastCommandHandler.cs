using Infrastructure.Repositories;
using MediatR;

namespace Application.Features.WeatherForecasts.Commands.Deletes
{
    public class DeleteWeatherForecastCommandHandler(IWeatherForecastRepository weatherForecastRepository) : IRequestHandler<DeleteWeatherForecastCommand>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository = weatherForecastRepository;

        public async Task Handle(DeleteWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            await _weatherForecastRepository.DeleteWeatherForecastAsync(request.Id);
        }
    }
}

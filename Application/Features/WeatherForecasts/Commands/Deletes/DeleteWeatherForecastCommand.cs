using MediatR;

namespace Application.Features.WeatherForecasts.Commands.Deletes
{
    public record DeleteWeatherForecastCommand(Guid Id) : IRequest;
}

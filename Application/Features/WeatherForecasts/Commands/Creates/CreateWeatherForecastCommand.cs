using MediatR;

namespace Application.Features.WeatherForecasts.Commands.Creates
{
    public record CreateWeatherForecastCommand(DateTime Date, int TemperatureC, string Summary) : IRequest<Guid>;
}

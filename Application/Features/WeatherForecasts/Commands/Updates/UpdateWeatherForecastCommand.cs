using MediatR;

namespace Application.Features.WeatherForecasts.Commands.Updates
{
    public record UpdateWeatherForecastCommand(Guid Id, DateTime Date, int TemperatureC, string Summary) : IRequest;
}

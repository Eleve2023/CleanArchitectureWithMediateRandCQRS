using Application.Features.WeatherForecasts.DTOs;
using MediatR;

namespace Application.Features.WeatherForecasts.Queries
{
    public record GetWeatherForecastByIdQuery(Guid Id) : IRequest<WeatherForecastDto?>;
}

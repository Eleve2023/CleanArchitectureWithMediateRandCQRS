using Application.Features.WeatherForecasts.DTOs;
using MediatR;

namespace Application.Features.WeatherForecasts.Queries
{
    public record GetWeatherForecastsListQuery : IRequest<List<WeatherForecastDto>>;
}

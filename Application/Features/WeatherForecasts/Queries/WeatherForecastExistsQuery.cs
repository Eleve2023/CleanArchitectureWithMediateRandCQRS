using MediatR;

namespace Application.Features.WeatherForecasts.Queries
{
    public record WeatherForecastExistsQuery(Guid Id) : IRequest<bool>;

}

using Application.Features.WeatherForecasts.Commands.Creates;
using Application.Features.WeatherForecasts.Commands.Deletes;
using Application.Features.WeatherForecasts.Commands.Updates;
using Application.Features.WeatherForecasts.DTOs;
using Application.Features.WeatherForecasts.Queries;
using MediatR;

namespace Application.Services
{
    internal class WeatherForecastService(IMediator mediator) : IWeatherForecastService
    {
        private readonly IMediator _mediator = mediator;

        public async Task<Guid> CreateWeatherForecastAsync(CreateWeatherForecastDto createWeatherForecastDto)
        {
            var command = new CreateWeatherForecastCommand(createWeatherForecastDto.Date, createWeatherForecastDto.TemperatureC, createWeatherForecastDto.Summary);
            return await _mediator.Send(command);
        }

        public async Task UpdateWeatherForecastAsync(UpdateWeatherForecastDto updateWeatherForecastDto)
        {
            var command = new UpdateWeatherForecastCommand(updateWeatherForecastDto.Id, updateWeatherForecastDto.Date, updateWeatherForecastDto.TemperatureC, updateWeatherForecastDto.Summary);
            await _mediator.Send(command);
        }

        public async Task DeleteWeatherForecastAsync(Guid id)
        {
            var command = new DeleteWeatherForecastCommand(id);
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetWeatherForecastsAsync()
        {
            var query = new GetWeatherForecastsListQuery();
            return await _mediator.Send(query);
        }

        public async Task<WeatherForecastDto?> GetWeatherForecastByIdAsync(Guid id)
        {
            var query = new GetWeatherForecastByIdQuery(id);
            return await _mediator.Send(query);
        }
    }
}

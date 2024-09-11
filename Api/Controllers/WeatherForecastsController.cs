using Application.Features.WeatherForecasts.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastsController(ILogger<WeatherForecastsController> logger, IWeatherForecastService weatherForecastService) : ControllerBase
    {
        private readonly ILogger<WeatherForecastsController> _logger = logger;
        private readonly IWeatherForecastService _weatherForecastService = weatherForecastService;

        // GET: /WeatherForecasts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecastDto>>> Get()
        {
            var weatherForecastDtos = await _weatherForecastService.GetWeatherForecastsAsync();
            return Ok(weatherForecastDtos);
        }
        // GET: /WeatherForecasts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecastDto>> Get(Guid id)
        {
            var weatherForecastDto = await _weatherForecastService.GetWeatherForecastByIdAsync(id);
            if (weatherForecastDto is null)
            {
                return NotFound();
            }
            return Ok(weatherForecastDto);
        }
        // POST: /WeatherForecasts
        [HttpPost]
        public async Task<ActionResult<Guid>> Post(CreateWeatherForecastDto createWeatherForecastDto)
        {
            var id = await _weatherForecastService.CreateWeatherForecastAsync(createWeatherForecastDto);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }
        // PUT: /WeatherForecasts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, UpdateWeatherForecastDto updateWeatherForecastDto)
        {
            if (id != updateWeatherForecastDto.Id)
            {
                return BadRequest();
            }
            await _weatherForecastService.UpdateWeatherForecastAsync(updateWeatherForecastDto);
            return NoContent();
        }
        // DELETE: /WeatherForecasts/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _weatherForecastService.DeleteWeatherForecastAsync(id);
            return NoContent();
        }
    }
}

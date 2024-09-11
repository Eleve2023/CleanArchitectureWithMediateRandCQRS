namespace Application.Features.WeatherForecasts.DTOs
{
    public class CreateWeatherForecastDto
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; } = null!;
    }
}

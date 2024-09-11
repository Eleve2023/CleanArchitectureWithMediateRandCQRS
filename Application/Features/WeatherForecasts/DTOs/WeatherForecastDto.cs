﻿namespace Application.Features.WeatherForecasts.DTOs
{
    public class WeatherForecastDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; } = null!;
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public virtual void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {            
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace first_steps_blazor.Data
{
    public class WeatherForecast : ICloneable
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        [Range(-60, 60, ErrorMessage = "Temp C. must be between -60 and 60.")]
        public int TemperatureC { get; set; }

        [Required]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Required]
        public string Summary { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}

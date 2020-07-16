using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace first_steps_blazor.Data
{
    public class WeatherForecastService
    {
        private List<WeatherForecast> Forecasts = new List<WeatherForecast>();

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService()
        {
            var rng = new Random();
            Forecasts.AddRange(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public Task<string[]> GetSummaries()
        {
            return Task.FromResult(Summaries);
        }

        public Task<List<WeatherForecast>> GetAll()
        {
            return Task.FromResult(this.Forecasts);
        }

        public Task<WeatherForecast> GetById(int id)
        {
            return Task.FromResult((WeatherForecast)this.Forecasts.Where(note => note.Id == id).First().Clone());
        }

        public Task Add(WeatherForecast forecast)
        {
            try
            {
                forecast.Id = this.Forecasts.Count + 1;
                this.Forecasts.Add(forecast);
            }
            catch (Exception e)
            {
                return Task.FromException(e);
            }

            return Task.CompletedTask;
        }

        public Task Update(int id, WeatherForecast forecast)
        {
            try
            {
                this.Forecasts[this.Forecasts.FindIndex(note => note.Id == id)] = forecast;
            }
            catch (Exception e)
            {
                return Task.FromException(e);
            }

            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            try
            {
                this.Forecasts = this.Forecasts.Where(note => note.Id != id).ToList();
            }
            catch (Exception e)
            {
                return Task.FromException(e);
            }

            return Task.CompletedTask;
        }
    }
}

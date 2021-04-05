using System;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Services
{
    public interface IWeatherService
    {
        Weather GetByCityId(long id);
    }

    public class WeatherService : IWeatherService
    {
        public Weather GetByCityId(long id)
        {
            throw new NotImplementedException();
        }
    }
}

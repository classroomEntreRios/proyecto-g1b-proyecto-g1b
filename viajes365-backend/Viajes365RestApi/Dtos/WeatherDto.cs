using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes365RestApi.Dtos
{
    public class InformationDto
    {
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
    }

    public class LocalityDto
    {
        public string Name { get; set; }
        public string Url_weather_forecast_15_days { get; set; }
        public string Url_hourly_forecast { get; set; }
        public string Country { get; set; }
        public string Url_country { get; set; }
    }

    public class DayDto
    {
        public string Date { get; set; }
        public int Temperature_max { get; set; }
        public int Temperature_min { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }
        public int Humidity { get; set; }
        public int Wind { get; set; }
        public string Wind_direction { get; set; }
        public string Icon_wind { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public string Moonset { get; set; }
        public string Moon_phases_icon { get; set; }
    }
    
    public class HourDto
    {
        public string Date { get; set; }
        public string Hour_data { get; set; }
        public int Temperature { get; set; }
        public string Text { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public string Icon { get; set; }
        public int Wind { get; set; }
        public string Wind_direction { get; set; }
        public string Icon_wind { get; set; }
    }
    
    public class Hour_hourDto
    {
        public HourDto Hour1 { get; set; }
        public HourDto Hour2 { get; set; }
        public HourDto Hour3 { get; set; }
        public HourDto Hour4 { get; set; }
        public HourDto Hour5 { get; set; }
        public HourDto Hour6 { get; set; }
        public HourDto Hour7 { get; set; }
        public HourDto Hour8 { get; set; }
        public HourDto Hour9 { get; set; }
        public HourDto Hour10 { get; set; }
        public HourDto Hour11 { get; set; }
        public HourDto Hour12 { get; set; }
        public HourDto Hour13 { get; set; }
        public HourDto Hour14 { get; set; }
        public HourDto Hour15 { get; set; }
        public HourDto Hour16 { get; set; }
        public HourDto Hour17 { get; set; }
        public HourDto Hour18 { get; set; }
        public HourDto Hour19 { get; set; }
        public HourDto Hour20 { get; set; }
        public HourDto Hour21 { get; set; }
        public HourDto Hour22 { get; set; }
        public HourDto Hour23 { get; set; }
        public HourDto Hour24 { get; set; }
        public HourDto Hour25 { get; set; }
    }

    public class WeatherDto
    {
       public string Copyright { get; set; }
       public string Use { get; set; }
       public InformationDto Information { get; set; }
       public string Web { get; set; }
       public string Language { get; set; }
       public LocalityDto Locality { get; set; }
       public DayDto Day1 { get; set; }
       public DayDto Day2 { get; set; }
       public DayDto Day3 { get; set; }
       public DayDto Day4 { get; set; }
       public DayDto Day5 { get; set; }
       public DayDto Day6 { get; set; }
       public DayDto Day7 { get; set; }
       public Hour_hourDto Hour_hour { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Viajes365RestApi.Entities
{
    // Inner entities
    public class Information
    {
        [Key]
        public long InformationId { get; set; }
        public string Temperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Pressure { get; set; }
    }

    public class Locality
    {
        [Key]
        public long LocalityId { get; set; }
        public string Name { get; set; }
        public string Url_weather_forecast_15_days { get; set; }
        public string Url_hourly_forecast { get; set; }
        public string Country { get; set; }
        public string Url_country { get; set; }

    }

    public class Day {
        [Key]
        public long DayId { get; set; }
        public string Name { get; set; }
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
        public long WeatherId { get; set; }
    }

    public class Hour
    {
        [Key]
        public long HourId { get; set; }
        public string Name { get; set; }
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
        public long WeatherId { get; set; }
    }

    // Main entity for TuTiempo.net
public class Weather : Base
    {
        [Key]
        public long WeatherId { get; set; }
        public string Copyright { get; set; }
        public string Use { get; set; }
        [ForeignKey("FK_Weathers_Informations_InformationId")]
        public long InformationId { get; set; }
        public virtual Information Information { get; set; }
        public string Web { get; set; }
        public string Language { get; set; }
        [ForeignKey("FK_Weathers_Localities_LocalityId")]
        public long LocalityId { get; set; }
        public virtual Locality Locality { get; set; }
        public ICollection<Day> Days { get; set; }
        public ICollection<Hour> Hours { get; set; }
    }
}

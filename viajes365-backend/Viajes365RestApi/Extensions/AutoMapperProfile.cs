using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;

namespace Viajes365RestApi.Extensions
{


    public class AutoMapperProfile : Profile
    {


        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<RoleDto, Role>();
            CreateMap<Role, RoleDto>();
            CreateMap<TopicDto, Topic>();
            CreateMap<Topic, TopicDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<AttractionDto, Attraction>();
            CreateMap<Attraction, AttractionDto>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
            CreateMap<Tour, TourDto>();
            CreateMap<TourDto, Tour>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();
            CreateMap<LocalityDto, Locality>();
            CreateMap<InformationDto, Information>();
            CreateMap<WeatherUpdateDto, Weather>();
            CreateMap<WeatherDto, Weather>()
                .ForMember(w => w.Days, wd => wd.MapFrom((z, y) =>
                    y.Days = convertToDay(z)))
                .ForMember(w => w.Hours, wd => wd.MapFrom((z, y) =>
                    y.Hours = convertToHours(z.Hour_hour)));
        }

        private Day[] convertToDay(WeatherDto z)
        {
            var days = new List<Day>();

            var day1 = new Day();
            assignDayValues("day1", day1, z.Day1);
            days.Add(day1);
            var day2 = new Day();
            assignDayValues("day2", day2, z.Day2);
            days.Add(day2);
            var day3 = new Day();
            assignDayValues("day3", day3, z.Day3);
            days.Add(day3);
            var day4 = new Day();
            assignDayValues("day4", day4, z.Day4);
            days.Add(day4);
            var day5 = new Day();
            assignDayValues("day5", day5, z.Day5);
            days.Add(day5);
            var day6 = new Day();
            assignDayValues("day6", day6, z.Day6);
            days.Add(day6);
            var day7 = new Day();
            assignDayValues("day7", day7, z.Day7);
            days.Add(day7);

            return days.ToArray();
        }

        private void assignDayValues(string name, Day day, DayDto z)
        {
            day.Name = name;
            day.Date = z.Date;
            day.Temperature_max = z.Temperature_max;
            day.Temperature_min = z.Temperature_min;
            day.Icon = z.Icon;
            day.Text = z.Text;
            day.Humidity = z.Humidity;
            day.Wind = z.Wind;
            day.Wind_direction = z.Wind_direction;
            day.Icon_wind = z.Icon_wind;
            day.Sunrise = z.Sunrise;
            day.Sunset = z.Sunset;
            day.Moonrise = z.Moonrise;
            day.Moonset = z.Moonset;
            day.Moon_phases_icon = z.Moon_phases_icon;
        }

        private Hour[] convertToHours(Hour_hourDto z)
        {
            var hours = new List<Hour>();

            var hour1 = new Hour();
            assignHoursValues("hour01", hour1, z.Hour1);
            hours.Add(hour1);
            var hour2 = new Hour();
            assignHoursValues("hour02", hour2, z.Hour2);
            hours.Add(hour2);
            var hour3 = new Hour();
            assignHoursValues("hour03", hour3, z.Hour3);
            hours.Add(hour3);
            var hour4 = new Hour();
            assignHoursValues("hour04", hour4, z.Hour4);
            hours.Add(hour4);
            var hour5 = new Hour();
            assignHoursValues("hour05", hour5, z.Hour5);
            hours.Add(hour5);
            var hour6 = new Hour();
            assignHoursValues("hour06", hour6, z.Hour6);
            hours.Add(hour6);
            var hour7 = new Hour();
            assignHoursValues("hour07", hour7, z.Hour7);
            hours.Add(hour7);
            var hour8 = new Hour();
            assignHoursValues("hour08", hour8, z.Hour8);
            hours.Add(hour8);
            var hour9 = new Hour();
            assignHoursValues("hour09", hour9, z.Hour9);
            hours.Add(hour9);
            var hour10 = new Hour();
            assignHoursValues("hour10", hour10, z.Hour10);
            hours.Add(hour10);

            var hour11 = new Hour();
            assignHoursValues("hour11", hour11, z.Hour11);
            hours.Add(hour11);
            var hour12 = new Hour();
            assignHoursValues("hour12", hour12, z.Hour12);
            hours.Add(hour12);
            var hour13 = new Hour();
            assignHoursValues("hour13", hour13, z.Hour13);
            hours.Add(hour13);
            var hour14 = new Hour();
            assignHoursValues("hour14", hour14, z.Hour14);
            hours.Add(hour14);
            var hour15 = new Hour();
            assignHoursValues("hour15", hour15, z.Hour15);
            hours.Add(hour15);
            var hour16 = new Hour();
            assignHoursValues("hour16", hour16, z.Hour16);
            hours.Add(hour16);
            var hour17 = new Hour();
            assignHoursValues("hour17", hour17, z.Hour17);
            hours.Add(hour17);
            var hour18 = new Hour();
            assignHoursValues("hour18", hour18, z.Hour18);
            hours.Add(hour18);
            var hour19 = new Hour();
            assignHoursValues("hour19", hour19, z.Hour19);
            hours.Add(hour19);
            var hour20 = new Hour();
            assignHoursValues("hour20", hour20, z.Hour20);
            hours.Add(hour20);

            var hour21 = new Hour();
            assignHoursValues("hour21", hour21, z.Hour21);
            hours.Add(hour21);
            var hour22 = new Hour();
            assignHoursValues("hour22", hour22, z.Hour22);
            hours.Add(hour22);
            var hour23 = new Hour();
            assignHoursValues("hour23", hour23, z.Hour23);
            hours.Add(hour23);
            var hour24 = new Hour();
            assignHoursValues("hour24", hour24, z.Hour24);
            hours.Add(hour24);
            var hour25 = new Hour();
            assignHoursValues("hour25", hour25, z.Hour25);
            hours.Add(hour25);

            return hours.ToArray();
        }

        private void assignHoursValues(string name, Hour hour, HourDto z)
        {
            hour.Name = name;
            hour.Date = z.Date;
            hour.Hour_data = z.Hour_data;
            hour.Temperature = z.Temperature;
            hour.Text = z.Text;
            hour.Humidity = z.Humidity;
            hour.Pressure = z.Pressure;
            hour.Icon = z.Icon;
            hour.Wind = z.Wind;
            hour.Wind_direction = z.Wind_direction;
            hour.Icon_wind = z.Icon_wind;
        }
    }
}

import { Role } from './role';
export class Information {
     InformationId!: number;
        Temperature!:string;
        Wind!: string;
        Humidity!: string;
        Pressure!: string;
};

export class Locality {
     Name!:number;
         Url_weather_forecast_15_days!: string;
         Url_hourly_forecast!: string;
         Country!: string;
         Url_country!: string;

};

export class Day {
        DayId!: string;
        Name!: string;
        Date!: string;
        Temperature_max!: number;
        Temperature_min!: number;
        Icon!:string;
        Text!: string;
        Humidity!: number;
        Wind!: number;
        Wind_direction!: string;
        Icon_wind!: string;
        Sunrise!: string;
        Sunset!: string;
        Moonrise!: string;
        Moonset!: string;
        Moon_phases_icon!: string;
        WeatherId!: number;
};

export class Hour {
    HourId!: number;
    Name!: string;
    Date!:string;
    Hour_data!: string;
    Temperature!: number;
    Text!: string;
    Humidity!: number;
    Pressure!: number;
    Icon!: string;
    Wind!: number;
    Wind_direction!: string;
    Icon_wind!: string;
    WeatherId!: number;
};


export class Weather {
    weatherId!: number;
    copyright!: string;
    use!: string;
    InformationId!: number;
    Information!: Information;
    Web!: string;
    Language!: string;
    LocalityId!: Locality;
    Days!: Day[];
    Hours!: Hour[]; 
    active!: boolean;   
}

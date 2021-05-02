import { WeatherService } from './../_services/weather.service';
import { CityService } from './../_services/city.service';
import { Component, OnInit } from '@angular/core';
import { City, Hour, Weather } from '@app/_models';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'apiclima',
  templateUrl: './apiclima.component.html',

})
export class ApiclimaComponent implements OnInit {

  // currentHour: any = Date.parse(new Date().toLocaleTimeString([], { hour: '2-digit', hour12: false }));
  citiesCollection!: City[];
  currentCity!: City;
  currentTemperature!: number;
  // weatherIconUrl = 'assets/images/icons/tutiempo/wi/6.png';
  weatherIconUrl!: string;
  currentTempUnit!: string;
  currentHumidityUnit!: string;
  currentPressureUnit!: string;
  currentStatus!: string;
  cityForm: FormGroup;
  currentHumidity!: number;
  currentPressure!: number;


  constructor(
    private fb: FormBuilder,
    private cityService: CityService,
    private weatherService: WeatherService) {
    this.cityForm = this.fb.group({
      city: [null]
    });
  }

  async ngOnInit(): Promise<void> {
    await this.cityService.getAll().subscribe(pagedCities => {
      try {
        this.citiesCollection = pagedCities.listElements;
        this.setDefaults();
      } catch (error) {
        console.log(pagedCities.message);
      }
    });
  }

  cityQuery(e: any) {
    let id: string = e.target.value;
    let cityId = Number(id.split(':')[1]);
    if (cityId > 0) {
      this.currentCity = this.getCityByCityId(cityId)
      this.weatherService.getByCode(this.currentCity.code).
        subscribe((weather: Weather) => {
          this.currentTemperature = weather.hours[0].temperature;
          this.weatherIconUrl = weather.hours[0].icon;
          this.currentTempUnit = weather.information.temperature;
          this.currentHumidityUnit = weather.information.humidity;
          this.currentPressureUnit = weather.information.pressure;
          this.currentStatus = weather.hours[0].text;
          this.currentHumidity = weather.hours[0].humidity;
          this.currentPressure = weather.hours[0].pressure;
          // weather icons are already in our assets folder        
          this.weatherIconUrl = 'assets/images/icons/tutiempo/wi/' + this.weatherIconUrl + '.png';
        })
    }
  };

  getCityByCityId(id: number): City {
    let city = this.citiesCollection.find(c => c.cityId == id);
    if (city) {
      return city;
    }
    return new City();
  }

  setDefaults() {
    // Selected option Choose City
    this.cityForm.get('city')!.patchValue(0);
  }
}








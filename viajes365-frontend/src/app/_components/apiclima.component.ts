import { Observable } from 'rxjs';
import { WeatherService } from './../_services/weather.service';
import { CityService } from './../_services/city.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { City, Hour, Weather } from '@app/_models';

@Component({
  selector: 'apiclima',
  templateUrl: './apiclima.component.html',

})
export class ApiclimaComponent implements OnInit  {

  horaActual: any = Date.parse(new Date().toLocaleTimeString([], { hour: '2-digit', hour12: false })) ;
  respuestaApi!:Weather;
  ciudades!: City[];
  ciudadElegida!:City;
  tempActual:number=0;
  iconoClima:string='';
  iconoClimaUrl = '';
  temperaturaActual = 0;
  variableConsulta!: Hour[] ;

private url = 'http://viajes365.azurewebsites.net/api/cities';

  // private url = 'https://api.tutiempo.net/json/?lan=es&apid=XsGaqqXXXzXeobw&lid=';

  // private url = 'http://localhost:5000/api/cities'

  constructor (
    private http: HttpClient, 
    private cityService: CityService, 
    private weatherService: WeatherService ){}

  async ngOnInit(): Promise<void> {
    await this.cityService.getAll().subscribe(pagedCities => {
      try {
        this.ciudades = pagedCities.listElements;
      } catch (error) {
        console.log(pagedCities.message);
      }
    });
  }

   consultaCiudad(val:any) {
console.log(val);
  this.ciudadElegida= val;
  
// let obj = this.ciudades.find(obj => obj.id == this.ciudadElegida);
// console.log(obj?.ciudadId);

 this.weatherService.getByCode(this.ciudadElegida.code, null).
  subscribe(weather => {
    this.respuestaApi = weather;
    this.variableConsulta.push(this.respuestaApi.Hours[0]);
    console.log(this.variableConsulta);
  })

    //  console.log ('consulta', this.respuestaApi.hour_hour);

    

    // console.log('consulta', this.variableConsulta);

    this.tempActual = this.variableConsulta[0].Temperature;
    this.iconoClima = this.variableConsulta[0].Icon;

    this.iconoClimaUrl = 'https://v5i.tutiempo.net/wi/02/30/' + this.iconoClima +'.png';

    console.log('Ciudad: ', this.ciudadElegida.name);
    console.log('Codigo: ', this.ciudadElegida.code );
    console.log('temp', this.variableConsulta[0].Temperature );
     console.log(this.iconoClimaUrl);
  };

    //  clima = hour_hour.find(h => h.hour_data = ''09:00).clima
    // this.variableConsulta = Array.of(this.respuestaApi.hour_hour);

    //  this.tempActual = this.variableConsulta.find((h: any) => h.hour_data == '9:00').temperature;

    //  if (this.respuestaApi.hour_hour.hour1.hour_data == this.horaActual){
    //    this.tempActual = this.respuestaApi.hour_hour.hour1.temperature
    //  }
    //  if (this.respuestaApi.hour_hour.hour2.hour_data == this.horaActual){
    //   this.tempActual = this.respuestaApi.hour_hour.hour2.temperature
    // }

    //  this.variableConsulta.forEach((h: any) => {
    //   console.log(h.hour_data);
    // });

    // console.log(this.variableConsulta.toString());
    //  console.log(this.respuestaApi);
    //  console.log(this.tempActual + this.iconoClima );


    //  console.log(this.respuestaApi.main.temp, this.respuestaApi.weather[0].icon );

  }

  // CONSULTA CLIMA A LA API

  

  




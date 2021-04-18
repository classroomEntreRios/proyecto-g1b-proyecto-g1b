import { HttpClient } from '@angular/common/http';
import { Ciudad } from './../_components/ciudad';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'apiclima',
  templateUrl: './apiclima.component.html',
  
})
export class ApiclimaComponent implements OnInit  {

  respuestaApi:any;
  ciudades!: Ciudad[];
  ciudadElegida:number=0;
  tempActual:number=0;
  iconoClima:string='';
  iconoClimaUrl = '';

  private url = 'https://api.tutiempo.net/json/?lan=es&apid=XsGaqqXXXzXeobw&lid=43214';

  private url2 = 'http://api.openweathermap.org/data/2.5/weather?q=Gualeguaychu&appid=4de652402d17c22f3c749ef7e711f6d1'
  constructor (private http: HttpClient){}

consultaCiudad(val:any) {
this.ciudadElegida= parseInt(val);
let obj = this.ciudades.find(obj => obj.id == this.ciudadElegida);
console.log(obj?.ciudadId);


  this.http.get(this.url)
    .subscribe(response => {
     this.respuestaApi = response;
     this.tempActual = this.respuestaApi.hour_hour.hour9.temperature;
     this.iconoClima = this.respuestaApi.hour_hour.hour9.icon;

     console.log(this.respuestaApi);
     console.log(this.tempActual, this.iconoClima );
     console.log(this.iconoClimaUrl);

     this.iconoClimaUrl = 'https://v5i.tutiempo.net/wi/02/30/' + this.iconoClima +'.png';




    //  console.log(this.respuestaApi.main.temp, this.respuestaApi.weather[0].icon );

    });

  }

  // CONSULTA CLIMA A LA API


  ngOnInit(){
    this.ciudades = [
      { id:1, ciudadId: 43214, ciudad:"Paraná"},
      { id:2, ciudadId: 42987, ciudad:"Federación"},
      { id:3, ciudadId: 42923, ciudad:"Concordia"},
      { id:4, ciudadId: 43034, ciudad:"Gualeguaychú"},
      { id:5, ciudadId: 43033, ciudad:"Gualeguay"},
    ]

    // CIUDAD POR DEFECTO PARANA
    this.ciudadElegida = 1;
  }


}

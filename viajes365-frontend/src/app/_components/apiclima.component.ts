import { HttpClient } from '@angular/common/http';
import { Ciudad } from './../_components/ciudad';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'apiclima',
  templateUrl: './apiclima.component.html',
  
})
export class ApiclimaComponent implements OnInit  {

  horaActual: any = Date.parse(new Date().toLocaleTimeString([], { hour: '2-digit', hour12: false })) ;
  respuestaApi:any;
  ciudades!: Ciudad[];
  ciudadElegida:number=0;
  tempActual:number=0;
  iconoClima:string='';
  iconoClimaUrl = '';
  temperaturaActual = 0;
  variableConsulta: any = [];
  
  private url = 'https://api.tutiempo.net/json/?lan=es&apid=XsGaqqXXXzXeobw&lid=43214';

  // private url2 = 'http://api.openweathermap.org/data/2.5/weather?q=Gualeguaychu&appid=4de652402d17c22f3c749ef7e711f6d1'
  constructor (private http: HttpClient){}

consultaCiudad(val:any) {
 
  // this.horaActual = Date.parse(new Date().toLocaleTimeString([], { hour: '2-digit', hour12: false }));
  // console.log(this.horaActual);
  this.ciudadElegida= parseInt(val);
let obj = this.ciudades.find(obj => obj.id == this.ciudadElegida);
console.log(obj?.ciudadId);


  this.http.get(this.url).toPromise().then(data =>{
    this.respuestaApi = data;

    // console.log ('consulta', this.respuestaApi.hour_hour);

    for (let key in this.respuestaApi.hour_hour ) {
      if (this.respuestaApi.hour_hour.hasOwnProperty(key)) {
        this.variableConsulta.push(this.respuestaApi.hour_hour[key]);     
      }

    }
    console.log('consulta', this.variableConsulta);
    console.log('temp', this.variableConsulta[0].temperature );

    this.tempActual = this.variableConsulta[0].temperature



     this.iconoClima = this.variableConsulta[0].icon;

    this.iconoClimaUrl = 'https://v5i.tutiempo.net/wi/02/30/' + this.iconoClima +'.png';

     console.log(this.iconoClimaUrl);




  });
     
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


  ngOnInit(){
    this.ciudades = [
      { id:1, ciudadId: 43214, ciudad:"Paraná"},
      { id:2, ciudadId: 42987, ciudad:"Federación"},
      { id:3, ciudadId: 42923, ciudad:"Concordia"},
      { id:4, ciudadId: 43034, ciudad:"Gualeguaychú"},
      { id:5, ciudadId: 43033, ciudad:"Gualeguay"},
    ]

    // CIUDAD POR DEFECTO PARANA
    this.ciudadElegida = 4;
  }


}

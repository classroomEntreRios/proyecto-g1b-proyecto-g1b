import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'apiclima',
  templateUrl: './apiclima.component.html',
  
})
export class ApiclimaComponent   {

  cities = [
    { id:1, cityId: 43214, city:"Paraná"},
    { id:2, cityId: 42987, city:"Federación"},
    { id:3, cityId: 42923, city:"Concordia"},
    { id:4, cityId: 43034, city:"Gualeguaychú"},
    { id:5, cityId: 43033, city:"Gualeguay"},
  ]


}

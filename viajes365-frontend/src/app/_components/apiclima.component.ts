import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'apiclima',
  templateUrl: './apiclima.component.html',
  
})
export class ApiclimaComponent   {

  cities = [
    {id:1, city:"Paraná"},
    {id:2, city:"Federación"},
    {id:3, city:"Concordia"},
    {id:4, city:"Gualeguaychú"},
    {id:5, city:"Gualeguay"},
  ]


}

﻿import { Attraction } from './attraction';
import { City } from './city';
import { Photo } from './photo';
import { Tour } from './tour';

export class Location {
  locationId!: number;
  locationName!: string;
  latitude!: number;
  longitude!: number;
  fullAddress!: string;
  note!: string;
  cityId!: number;
  city!: City;
  tours!: Tour[];
  attractions!: Attraction[];
  photos!: Photo[];
  active!: boolean;
  isDeleting = false;
}

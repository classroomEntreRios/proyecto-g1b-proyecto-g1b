import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from '@app/_models';
import { Location } from '@app/_models/location';
import { AlertService } from '@app/_services';
import { CityService } from '@app/_services/city.service';
import { LocationService } from '@app/_services/location.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-location-editor',
  templateUrl: './location-editor.component.html'
})
export class LocationEditorComponent implements OnInit {
    citiesCollection!: City[];
//     citiesCollection = [
// {"name":"Bovril", "code": 42829},
// {"name":"Caseros", "code": 42866},
// {"name": "Chajari", "code": 42881},
// {"name": "Colón", "code": 43437},
// {"name":"Colonia San Justo", "code": 43326},
// {"name": "Colonia Santa Maria", "code": 43350},
// {"name":"Concepcion del Uruguay", "code": 42922},
// {"name": "Concordia", "code": 42923},   
// {"name":"Crespo", "code": 42940},
// {"name":"Federacion", "code": 42987},
// {"name":"Federal", "code": 42988},
// {"name":"Gualeguay", "code": 43033},
// {"name": "Gualeguaychú", "code": 43034},
// {"name": "La Paz", "code": 43095},
// {"name":"Larroque", "code": 43115},
// {"name": "Los Conquistadores", "code": 43145},
// {"name": "Paraná", "code": 43214},
// {"name": "San Gustavo", "code": 43317},
// {"name": "San Jose de Feliciano", "code": 43321},
// {"name":"Macia", "code": 43157},
// {"name":"Santa Ana", "code": 43340},
// {"name":"Santa Elena", "code": 43344},
// {"name":"Sauce de luna", "code": 43364},
// {"name":"Segui", "code": 43366},
// {"name":"Tabossi", "code": 43376},
// {"name":"Ubajay", "code": 43401},
// {"name":"Victoria", "code": 43416},
// {"name":"Villaguay", "code": 43464},
// {"name":"Villa elisa", "code": 43437},
// {"name":"Villa Hernandarias", "code": 43443}
// ];
      
  currentLocation!: Location;
  form!: FormGroup;
  id!: number;
  isAddMode!: boolean;
  loading = false;
  submitted = false;
  activeLabel = 'Sí';


  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private locationService: LocationService,
    private cityService: CityService,
    private alertService: AlertService,
    ) {
      
    }

   ngOnInit() {
    this.cityService.getAll().subscribe(paged => {
      this.citiesCollection = paged.listElements;
    });

    this.id = this.route.snapshot.params['id'];
    this.isAddMode = this.id <= 0;

    this.form = this.formBuilder.group(
      {
        locationId: ['0'],
        locationName: ['', Validators.required],
        fullAddress: ['', Validators.required],
        note: ['', Validators.required],
        cityId: ['', Validators.required],
        active: [true, Validators.required]
      }

      // tours!: Tour[];
      // attractions!: Attraction[];
      // photos!: Photo[];
    );

    if (!this.isAddMode) {
      this.locationService
        .getById(this.id)
        .pipe(first())
        .subscribe((x) => {
          this.currentLocation = x.element;
          this.form.patchValue(x.element);
          this.form.controls['active'].patchValue(x.element.active);
          this.activeToggle();
        });
    }
  }

   // convenience getter for easy access to form fields
   get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;

    this.alertService.clear();

    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    if (this.isAddMode) {
      this.createLocation();
    } else {
      this.updateLocation();
    }
  }

  private createLocation() {
    this.locationService
      .create(this.form.value)
      .pipe(first())
      .subscribe(() => {
        this.alertService.success('Localidad agregada', {
          keepAfterRouteChange: true,
        });
        this.router.navigate(['/locations'], { relativeTo: this.route });
      })
      .add(() => (this.loading = false));
  }

  private updateLocation() {
    
    this.locationService
      .update(this.id, this.form.value)
      .pipe(first())
      .subscribe(() => {
        this.alertService.success('Localidad actualizada', {
          keepAfterRouteChange: true,
        });
        this.router.navigate(['/locations'], { relativeTo: this.route });
      })
      .add(() => (this.loading = false));
  }

  public onChangeRole(e: any) {
    // sincroniza el select con el Role Id
    this.form.controls['locationId'].patchValue(e.target.value);
  }

  activeToggle(): void {
    this.activeLabel = this.form.get('active')!.value ? 'Sí' : 'No';
  }

  cityChange(e: any) {
    let id: string = e.target.value;
  };
}

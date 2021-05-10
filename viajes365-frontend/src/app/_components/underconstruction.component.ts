import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { Subscription } from 'rxjs';

import { Alert, AlertType } from '@app/_models';
import { AlertService } from '@app/_services';

@Component({
    selector: 'app-underconstruction',
    templateUrl: './underconstruction.component.html'
  })
export class UnderConstructionComponent implements OnInit{

    // constructor(private router: Router, private alertService: AlertService) { }

    // ngOnInit() {

    // }

    constructor() { }

    ngOnInit(): void {
    }




}
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { UserService, AlertService } from '@app/_services';
import { MustMatch } from '@app/_helpers';
import { Role } from '@app/_models';
import { RoleService } from '@app/_services/role.service';

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    id!: number;
    isAddMode!: boolean;
    loading = false;
    submitted = false;
    roles = new Array<Role>();
    activeLabel = 'No';

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private userService: UserService,
        private roleService: RoleService,
        private alertService: AlertService
    ) {

    }

    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;

        // password not required in edit mode
        const passwordValidators = [Validators.minLength(6)];
        if (this.isAddMode) {
            passwordValidators.push(Validators.required);
        }
        // populate active roles
        this.roleService.getAll()
            .pipe(first())
            .subscribe(pagedroles => {
                pagedroles.listElements.forEach(rol => { if (rol.active) this.roles.push(rol) });
            });
        const formOptions: AbstractControlOptions = { validators: MustMatch('password', 'confirmPassword') };
        this.form = this.formBuilder.group({
            userId: ['', Validators.required],
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            email: ['', [Validators.required, Validators.email]],
            roleId: ['', Validators.required],
            role: ['', Validators.required],
            password: ['', [Validators.minLength(5), this.isAddMode ? Validators.required : Validators.nullValidator]],
            confirmPassword: ['', this.isAddMode ? Validators.required : Validators.nullValidator],
            active: ['', Validators.required]
        }, formOptions);

        if (!this.isAddMode) {
            this.userService.getById(this.id)
                .pipe(first())
                .subscribe(x => {
                    this.form.patchValue(x.element);
                    this.form.controls['role'].patchValue(x.element.roleId);
                    this.form.controls['roleId'].patchValue(x.element.roleId);
                    console.log(x.element.roleId);
                    this.form.controls['active'].patchValue(x.element.active);
                    this.activeToggle();
                });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createUser();
        } else {
            this.updateUser();
        }
    }

    private createUser() {
        this.userService.create(this.form.value)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Usuario agregado', { keepAfterRouteChange: true });
                this.router.navigate(['../'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);
    }

    private updateUser() {
        this.userService.update(this.id, this.form.value)
            .pipe(first())
            .subscribe(() => {
                this.alertService.success('Usuario actualizado', { keepAfterRouteChange: true });
                this.router.navigate(['/users/list'], { relativeTo: this.route });
            })
            .add(() => this.loading = false);
    }

    public onChange(e: any) {
        // sincroniza el select con el Role Id
        this.form.controls['roleId'].patchValue(e.target.value);
    }

    activeToggle(): void {
        this.activeLabel = this.form.get('active')!.value ? 'Sí' : 'No';
    }
}
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesListComponent } from './roles-list.component';
import { RoleEditorComponent } from './role-editor.component';
import { RolesRoutingModule } from './roles-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [RolesListComponent, RoleEditorComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RolesRoutingModule,
  ]
})
export class RolesModule { }

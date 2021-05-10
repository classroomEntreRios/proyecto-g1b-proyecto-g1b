import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { ListComponent } from './list.component';
import { AddEditComponent } from './add-edit.component';
import { EditProfileComponent } from './edit-profile.component';

const routes: Routes = [
  { path: '', component: LayoutComponent },
  { path: 'list', component: ListComponent, pathMatch: 'full' },
  { path: 'add', component: AddEditComponent, pathMatch: 'full' },
  { path: 'edit/:id', component: AddEditComponent, pathMatch: 'full' },
  { path: 'profile/:id', component: EditProfileComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  exports: [RouterModule],
})
export class UsersRoutingModule {}

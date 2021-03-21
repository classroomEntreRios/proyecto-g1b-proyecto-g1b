import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { DashboardComponent } from './dashboard.component';
import { SidebarComponent } from './sidebar.component';



@NgModule({
  declarations: [LayoutComponent, DashboardComponent, SidebarComponent],
  imports: [
    CommonModule
  ]
})
export class AdminModule { }

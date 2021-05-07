import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopicsListComponent } from './topics-list.component';
import { CommentsComponent } from './comments.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ForumRoutingModule } from './forum-routing.module';

@NgModule({
  declarations: [TopicsListComponent, CommentsComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ForumRoutingModule,
    NgxPaginationModule,
    FormsModule,
  ],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: 'es', // 'de' for Germany, 'fr' for France ...
    },
  ],
})
export class ForumModule {}

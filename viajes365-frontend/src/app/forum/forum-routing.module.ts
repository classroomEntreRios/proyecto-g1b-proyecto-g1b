import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommentsComponent } from './comments.component';
import { TopicsListComponent } from './topics-list.component';

const routes: Routes = [
  { path: '', component: TopicsListComponent },
  { path: 'topiclist', component: TopicsListComponent, pathMatch: 'full' },
  { path: 'comments/:id', component: CommentsComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ForumRoutingModule {}

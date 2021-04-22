import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { UserService } from '@app/_services';
import { User } from '@app/_models';
import { PaginatedResponse } from '@app/_rest/paginated.response';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
  page!: PaginatedResponse<User>;
  users!: User[];

  constructor(private userService: UserService) {

  }

  async ngOnInit(): Promise<void> {
    await this.userService.getAll().subscribe(paged => { this.users = paged.listElements; this.page = paged });
  }

  deleteUser(id: number): void {
    const user = this.users.find(x => x.userId === id);
    if (!user) { return; }
    user.isDeleting = true;
    this.userService.delete(id)
      .pipe(first())
      .subscribe(() => this.users = this.users.filter(x => x.userId !== id));
  }
}

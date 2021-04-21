import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { UserService } from '@app/_services';
import { User } from '@app/_models';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
  users!: User[];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.userService.getAll()
      .pipe(first())
      .subscribe(users => this.users = users.listElements);
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

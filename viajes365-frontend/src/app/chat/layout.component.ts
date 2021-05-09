import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '@app/_models';
import { AccountService } from '@app/_services';
import { ChatService } from '@app/_services/chat.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
})
export class LayoutComponent implements OnInit {
  userChat!: User;

  constructor(private router: Router, private chatService: ChatService) {
    this.chatService.getActualChatUser().subscribe((u) => (this.userChat = u));
  }

  ngOnInit(): void {
    if (!this.userChat) {
      this.router.navigateByUrl('chats/login');
    } else {
      if (this.userChat.nick == '' && this.userChat.email == '') {
        this.router.navigateByUrl('chats/login');
      }
    }
  }
}

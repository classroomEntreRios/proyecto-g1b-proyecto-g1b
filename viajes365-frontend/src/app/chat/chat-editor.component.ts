import { Component, OnDestroy, OnInit } from '@angular/core';
import { Chat, Chatcomment, User } from '@app/_models';
import { AccountService } from '@app/_services';
import { ChatService } from '@app/_services/chat.service';
import { ChatcommentService } from '@app/_services/chatcomment.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-chat-editor',
  templateUrl: './chat-editor.component.html',
})
export class ChatEditorComponent implements OnInit, OnDestroy {
  currentChat!: Chat;
  currentUser!: User;
  subscription!: Subscription;
  message = '';

  constructor(
    private accountService: AccountService,
    private chatService: ChatService,
    private chatCommentsService: ChatcommentService
  ) {
    this.currentUser = this.accountService.userValue;
    // subscribe to chat component
    this.subscription = this.chatService.getActualChat().subscribe((chat) => {
      if (chat) {
        this.currentChat = chat;
      } else {
        // when empty object received
        this.currentChat = new Chat();
      }
    });
  }

  ngOnInit(): void {}

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.subscription.unsubscribe();
  }

  async sendMessage(): Promise<void> {
    if (this.message.length > 0) {
      console.log(this.message);
      var chatComment = new Chatcomment();
      chatComment.chatId = this.currentChat.chatId;
      chatComment.message = this.message;
      chatComment.userId = this.currentUser.userId;
      chatComment.isResponse = true;
      chatComment.active = true;
      chatComment.status =
        'respuesta de ' +
        this.currentUser.firstName +
        ', ' +
        this.currentUser.lastName +
        ' el ';
      await this.chatCommentsService.create(chatComment).subscribe(
        (res) => {
          this.message = '';
          this.chatService.setActualChat(this.currentChat);
        },
        (error) => alert(error)
      );
    }
  }
}

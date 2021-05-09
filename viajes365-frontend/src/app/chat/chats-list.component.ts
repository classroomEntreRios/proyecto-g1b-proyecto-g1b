import { Component, OnInit, Output, ViewChild } from '@angular/core';
import { Chat } from '@app/_models';
import { ChatService } from '@app/_services/chat.service';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';

@Component({
  selector: 'app-chats-list',
  templateUrl: './chats-list.component.html',
})
export class ChatsListComponent implements OnInit {
  currentChat!: Chat;
  chatCollection!: Chat[];

  constructor(private chatService: ChatService) {
    registerLocaleData(localeEs, 'es');
  }

  async ngOnInit(): Promise<void> {
    await this.chatService
      .getAll()
      .subscribe((c) => (this.chatCollection = c.listElements.reverse()));
  }

  activateClass(chat: Chat): void {
    this.chatCollection.forEach((c) => (c.isSelected = false));
    chat.isSelected = !chat.isSelected;
    this.currentChat = chat;
    this.chatService.setActualChat(chat);
  }
}

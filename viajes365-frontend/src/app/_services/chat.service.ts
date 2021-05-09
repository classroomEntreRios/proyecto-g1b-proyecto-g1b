import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chat } from '@app/_models';
import { PaginatedResponse, SingleObjectResponse } from '@app/_rest';
import { environment } from '@environments/environment';
import { Observable, Subject } from 'rxjs';

const baseUrl = `${environment.apiUrl}/chats`;

@Injectable({ providedIn: 'root' })
export class ChatService {
  private subject = new Subject<any>();
  private actualChat = new Subject<Chat>();

  constructor(private http: HttpClient) {}

  getAll(): Observable<PaginatedResponse<Chat>> {
    return this.http.get<PaginatedResponse<Chat>>(`${baseUrl}`);
  }

  getById(id: number): Observable<SingleObjectResponse<Chat>> {
    return this.http.get<SingleObjectResponse<Chat>>(`${baseUrl}/${id}`);
  }

  create(params: any): Observable<any> {
    return this.http.post(baseUrl, params);
  }

  update(id: number, params: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, params);
  }

  delete(id: number) {
    return this.http.delete(`${baseUrl}/${id}`);
  }

  // messages methods

  sendMessage(message: string) {
    this.subject.next({ text: message });
  }

  clearMessages() {
    this.subject.next();
  }

  getMessage(): Observable<any> {
    return this.subject.asObservable();
  }

  // actualChat methods

  setActualChat(chat: Chat): void {
    this.actualChat.next(chat);
  }

  clearActualChat(): void {
    this.actualChat.next();
  }

  getActualChat(): Observable<Chat> {
    return this.actualChat.asObservable();
  }
}

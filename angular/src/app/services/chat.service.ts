import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Chat } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class ChatService extends SuperService<Chat> {

  constructor() {
    super('chats');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, idSender, idReceiver, message, idTicketSupport) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${idSender}/${idReceiver}/${message}/${idTicketSupport}`);
  }

}

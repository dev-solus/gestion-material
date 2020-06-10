import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { TicketSupport } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class TicketSupportService extends SuperService<TicketSupport> {

  constructor() {
    super('ticketSupports');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, question, priorite, idCollaborateur) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${question}/${priorite}/${idCollaborateur}`);
  }

}

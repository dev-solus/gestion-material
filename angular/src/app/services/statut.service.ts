import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Statut } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class StatutService extends SuperService<Statut> {

  constructor() {
    super('statuts');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}`);
  }

}

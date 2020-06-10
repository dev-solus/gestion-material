import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Fonction } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class FonctionService extends SuperService<Fonction> {

  constructor() {
    super('fonctions');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}`);
  }

}

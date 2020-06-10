import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Constucteur } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class ConstucteurService extends SuperService<Constucteur> {

  constructor() {
    super('constucteurs');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}`);
  }

}

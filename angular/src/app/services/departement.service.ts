import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Departement } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class DepartementService extends SuperService<Departement> {

  constructor() {
    super('departements');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom, etage) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}/${etage}`);
  }

}

import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Service } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class ServiceService extends SuperService<Service> {

  constructor() {
    super('services');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom, idDepartement) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}/${idDepartement}`);
  }

}

import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Emplacement } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class EmplacementService extends SuperService<Emplacement> {

  constructor() {
    super('emplacements');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, codeEmplacement, idDepartement) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${codeEmplacement}/${idDepartement}`);
  }

}

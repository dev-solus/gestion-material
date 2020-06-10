import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Fournisseur } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class FournisseurService extends SuperService<Fournisseur> {

  constructor() {
    super('fournisseurs');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom, tel, fax, email) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}/${tel}/${fax}/${email}`);
  }

}

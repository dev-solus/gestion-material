import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Categorie } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class CategorieService extends SuperService<Categorie> {

  constructor() {
    super('categories');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nom) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nom}`);
  }

}

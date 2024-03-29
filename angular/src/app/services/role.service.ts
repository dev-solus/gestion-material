import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Role } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends SuperService<Role> {

  constructor() {
    super('roles');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, name) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${name}`);
  }

}

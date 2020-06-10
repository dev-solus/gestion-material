import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Affectation } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class AffectationService extends SuperService<Affectation> {

  constructor() {
    super('affectations');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, action, idEquipement, idEmplacement, idCollaborateur, idAgentSi) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${action}/${idEquipement}/${idEmplacement}/${idCollaborateur}/${idAgentSi}`);
  }

}

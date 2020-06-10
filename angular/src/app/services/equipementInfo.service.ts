import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { EquipementInfo } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class EquipementInfoService extends SuperService<EquipementInfo> {

  constructor() {
    super('equipementInfos');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nSerie, stringInfo) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nSerie}/${stringInfo}`);
  }

}

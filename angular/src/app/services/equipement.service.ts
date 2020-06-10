import { SuperService } from './super.service';
import { Injectable } from '@angular/core';
import { Equipement } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class EquipementService extends SuperService<Equipement> {

  constructor() {
    super('equipements');
  }

  getAll(startIndex, pageSize, sortBy, sortDir, nSerie, model, refAchat, etatActuel, prixUnitaireHT, nInventaire, remarques, idConstucteur, idCategorie, idStatut, idFournisseur) {

    return this.http.get(`${this.urlApi}/${this.controller}/getAll/${startIndex}/${pageSize}/${sortBy}/${sortDir}/${nSerie}/${model}/${refAchat}/${etatActuel}/${prixUnitaireHT}/${nInventaire}/${remarques}/${idConstucteur}/${idCategorie}/${idStatut}/${idFournisseur}`);
  }

}

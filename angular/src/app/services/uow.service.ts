
import { Injectable } from '@angular/core';
import { AccountService } from './account.service';
import { FonctionService } from './fonction.service';
import { ServiceService } from './service.service';
import { TicketSupportService } from './ticketSupport.service';
import { ChatService } from './chat.service';
import { RoleService } from './role.service';
import { UserService } from './user.service';
import { AffectationService } from './affectation.service';
import { EquipementService } from './equipement.service';
import { EquipementInfoService } from './equipementInfo.service';
import { EmplacementService } from './emplacement.service';
import { FournisseurService } from './fournisseur.service';
import { CategorieService } from './categorie.service';
import { StatutService } from './statut.service';
import { ConstucteurService } from './constucteur.service';
import { DepartementService } from './departement.service';

@Injectable({
  providedIn: 'root'
})
export class UowService {
  accounts = new AccountService();
  fonctions = new FonctionService();
services = new ServiceService();
ticketSupports = new TicketSupportService();
chats = new ChatService();
roles = new RoleService();
users = new UserService();
affectations = new AffectationService();
equipements = new EquipementService();
equipementInfos = new EquipementInfoService();
emplacements = new EmplacementService();
fournisseurs = new FournisseurService();
categories = new CategorieService();
statuts = new StatutService();
constucteurs = new ConstucteurService();
departements = new DepartementService();

  

  constructor() { }

  valideDate(date: Date): Date {
    date = new Date(date);

    const hoursDiff = date.getHours() - date.getTimezoneOffset() / 60;
    const minutesDiff = (date.getHours() - date.getTimezoneOffset()) % 60;
    date.setHours(hoursDiff);
    date.setMinutes(minutesDiff);

    return date;
  }
}

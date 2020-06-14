export class Fonction {
  id = 0;
  nom = '';
  fonctionCollaborateurs: User[] = [];
}

export class Service {
  id = 0;
  nom = '';
  idDepartement = 0;
  departement = new Departement();
  serviceCollaborateurs: User[] = [];
}

export class TicketSupport {
  id = 0;
  question = '';
  dateCreation = new Date();
  priorite = '';
  idCollaborateur = 0;
  isClosed = false;
  collaborateur = new User();
  ticketSupportChats: Chat[] = [];
}

export class Chat {
  id = 0;
  idSender = 0;
  idReceiver = null;
  message = '';
  vu = false;
  date = new Date();
  idTicketSupport = 0;
  ticketSupport = new TicketSupport();
  sender = new User();
  receiver = new User();
}

export class Role {
  id = 0;
  name = '';
  roleUsers: User[] = [];
}
export class User {
  id = 0;
  nom = '';
  matricule = '';
  prenom = '';
  email = '';
  password = '';
  codeOfVerification = '';
  emailVerified = false;
  isActive = true;
  idService = 0;
  idFonction = 0;
  idRole = 0;
  role = new Role();
  service = new Service();
  fonction = new Fonction();
  agentSiAffectations: Affectation[] = [];
  collaborateurAffectations: Affectation[] = [];
  collaborateurTicketSupports: TicketSupport[] = [];
  senderChats: Chat[] = [];
  receiverChats: Chat[] = [];
}

export class Affectation {
  id = 0;
  action = '';
  date = new Date();
  idEquipement = 0;
  idEmplacement = 0;
  idCollaborateur = 0;
  idAgentSi = 0;
  equipement = new Equipement();
  emplacement = new Emplacement();
  collaborateur = new User();
  agentSi = new User();
}



export class Equipement {
  id = 0;
  nSerie = '';
  model = '';
  dateAchat = new Date();
  refAchat = '';
  etatActuel = '';
  prixUnitaireHT = 0;
  nInventaire = '';
  remarques = '';
  idConstucteur = 0;
  idCategorie = 0;
  idStatut = 0;
  idFournisseur = 0;

  constucteur = new Constucteur();
  categorie = new Categorie();
  fournisseur = new Fournisseur();
  statut = new Statut();
  equipementAffectations: Affectation[] = [];
}

export class EquipementInfo {
  id = 0;
  nSerie = '';
  date = new Date();
  infoSystemeHtml = '';
  softwareHtml = '';
}

export class Emplacement {
  id = 0;
  codeEmplacement = '';
  description = '';
  idDepartement = 0;
  departement = new Departement();
  emplacementAffectations: Affectation[] = [];
}

export class Fournisseur {
  id = 0;
  nom = '';
  tel = '';
  fax = '';
  email = '';
  fournisseurEquipements: Equipement[] = [];
}

export class Categorie {
  id = 0;
  nom = '';
  description = '';
  categorieEquipements: Equipement[] = [];
}

export class Statut {
  id = 0;
  nom = '';
  description = '';
  statutEquipements: Equipement[] = [];
}

export class Constucteur {
  id = 0;
  nom = '';
  description = '';
  constucteurEquipements: Equipement[] = [];
}

export class Departement {
  id = 0;
  nom = '';
  etage = '';
  departementEmplacements: Emplacement[] = [];
  departementServices: Service[] = [];
}


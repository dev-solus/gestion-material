using System;
using System.Collections.Generic;
namespace Models
{
public partial class Equipement 
{public int Id { get; set; }
public string NSerie { get; set; }
public string Model { get; set; }
public DateTime DateAchat { get; set; }
public string RefAchat { get; set; }
public string EtatActuel { get; set; }
public int PrixUnitaireHT { get; set; }
public string NInventaire { get; set; }
public string Remarques { get; set; }
public int IdConstucteur { get; set; }
public int IdCategorie { get; set; }
public int IdStatut { get; set; }
public int IdFournisseur { get; set; }
public virtual Constucteur Constucteur { get; set; }
public virtual Categorie Categorie { get; set; }
public virtual Fournisseur Fournisseur { get; set; }
public virtual Statut Statut { get; set; }
public virtual ICollection<Affectation> EquipementAffectations { get; set; }
}
}

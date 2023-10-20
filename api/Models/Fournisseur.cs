using System;
using System.Collections.Generic;
namespace Models
{
public partial class Fournisseur 
{public int Id { get; set; }
public string Nom { get; set; }
public string Tel { get; set; }
public string Fax { get; set; }
public string Email { get; set; }
public virtual ICollection<Equipement> FournisseurEquipements { get; set; }
}
}

using System;
using System.Collections.Generic;
namespace Models
{
public partial class Statut 
{public int Id { get; set; }
public string Nom { get; set; }
public string Description { get; set; }
public virtual ICollection<Equipement> StatutEquipements { get; set; }
}
}

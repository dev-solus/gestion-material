using System;
using System.Collections.Generic;
namespace Models
{
public partial class Constucteur 
{public int Id { get; set; }
public string Nom { get; set; }
public string Description { get; set; }
public virtual ICollection<Equipement> ConstucteurEquipements { get; set; }
}
}

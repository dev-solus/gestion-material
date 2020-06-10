using System;
using System.Collections.Generic;
namespace Models
{
public partial class Departement 
{public int Id { get; set; }
public string Nom { get; set; }
public string Etage { get; set; }
public virtual ICollection<Emplacement> DepartementEmplacements { get; set; }
public virtual ICollection<Service> DepartementServices { get; set; }
}
}

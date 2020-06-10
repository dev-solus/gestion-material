using System;
using System.Collections.Generic;
namespace Models
{
public partial class Emplacement 
{public int Id { get; set; }
public string CodeEmplacement { get; set; }
public string Description { get; set; }
public int IdDepartement { get; set; }
public virtual Departement Departement { get; set; }
public virtual ICollection<Affectation> EmplacementAffectations { get; set; }
}
}

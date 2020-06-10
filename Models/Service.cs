using System;
using System.Collections.Generic;
namespace Models
{
public partial class Service 
{public int Id { get; set; }
public string Nom { get; set; }
public int IdDepartement { get; set; }
public virtual Departement Departement { get; set; }
public virtual ICollection<User> ServiceCollaborateurs { get; set; }
}
}

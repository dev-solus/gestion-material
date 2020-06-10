using System;
using System.Collections.Generic;
namespace Models
{
public partial class Fonction 
{public int Id { get; set; }
public string Nom { get; set; }
public virtual ICollection<User> FonctionCollaborateurs { get; set; }
}
}

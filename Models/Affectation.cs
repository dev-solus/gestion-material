using System;
using System.Collections.Generic;
namespace Models
{
public partial class Affectation 
{public int Id { get; set; }
public string Action { get; set; }
public DateTime Date { get; set; }
public int IdEquipement { get; set; }
public int IdEmplacement { get; set; }
public int IdCollaborateur { get; set; }
public int IdAgentSi { get; set; }
public virtual Equipement Equipement { get; set; }
public virtual Emplacement Emplacement { get; set; }
public virtual User Collaborateur { get; set; }
public virtual User AgentSi { get; set; }
}
}

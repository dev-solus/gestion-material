using System;
using System.Collections.Generic;
namespace Models
{
public partial class User 
{public int Id { get; set; }
public string Nom { get; set; }
public string Matricule { get; set; }
public string Prenom { get; set; }
public string Email { get; set; }
public string Password { get; set; }
public string CodeOfVerification { get; set; }
public bool EmailVerified { get; set; }
public bool IsActive { get; set; }
public int? IdService { get; set; }
public int? IdFonction { get; set; }
public int IdRole { get; set; }
public virtual Role Role { get; set; }
public virtual Service Service { get; set; }
public virtual Fonction Fonction { get; set; }
public virtual ICollection<Affectation> AgentSiAffectations { get; set; }
public virtual ICollection<Affectation> CollaborateurAffectations { get; set; }
public virtual ICollection<TicketSupport> CollaborateurTicketSupports { get; set; }
public virtual ICollection<Chat> SenderChats { get; set; }
public virtual ICollection<Chat> ReceiverChats { get; set; }
}
}

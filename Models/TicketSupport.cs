using System;
using System.Collections.Generic;
namespace Models
{
public partial class TicketSupport 
{public int Id { get; set; }
public string Question { get; set; }
public DateTime DateCreation { get; set; }
public string Priorite { get; set; }
public int IdCollaborateur { get; set; }
public virtual User Collaborateur { get; set; }
public virtual ICollection<Chat> TicketSupportChats { get; set; }
}
}

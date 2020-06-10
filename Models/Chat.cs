using System;
using System.Collections.Generic;
namespace Models
{
public partial class Chat 
{public int Id { get; set; }
public int IdSender { get; set; }
public int? IdReceiver { get; set; }
public string Message { get; set; }
public bool Vu { get; set; }
public DateTime Date { get; set; }
public int IdTicketSupport { get; set; }
public virtual TicketSupport TicketSupport { get; set; }
public virtual User Sender { get; set; }
public virtual User Receiver { get; set; }
}
}

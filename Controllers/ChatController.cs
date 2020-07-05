using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Api.Providers;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatsController : SuperController<Chat>
    {
        private readonly IHubContext<ChatHub> _chatHub;
        public ChatsController(MyContext context, IHubContext<ChatHub> chatHub) : base(context)
        {
            _chatHub = chatHub;
        }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{idSender}/{idReceiver}/{message}/{idTicketSupport}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int idSender, int idReceiver, string message, int idTicketSupport)
        {
            var q = _context.Chats
                .Where(e => idSender == 0 ? true : e.IdSender == idSender)
                .Where(e => idReceiver == 0 ? true : e.IdCollaboratteur == idReceiver)
                .Where(e => message == "*" ? true : e.Message.ToLower().Contains(message.ToLower()))
                .Where(e => idTicketSupport == 0 ? true : e.IdTicketSupport == idTicketSupport)

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Chat>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)

                .Select(e => new
                {
                    id = e.Id,
                    sender = e.Sender.Nom,
                    receiver = e.Receiver.Nom,
                    message = e.Message,
                    vu = e.Vu,
                    date = e.Date,
                    ticketSupport = e.TicketSupport.Question,

                })
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByTicket(int id)
        {
            var list = await _context.Chats
                .Where(e => e.IdTicketSupport == id)
                .OrderBy(e => e.Date)
                .Select(e => new
                {
                    Id = e.Id,
                    Message = e.Message,
                    Vu = e.Vu,
                    Date = e.Date,
                    IdSender = e.IdSender,
                    SenderName = e.SenderName,
                })
                .ToListAsync()
                ;
            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Chat>> MessageSeenToTrue(int id)
        {
            var idUser = HttpContext.GetIdUser();

            var list = await _context.Chats
                .Where(e => e.IdTicketSupport == id && e.IdSender != idUser && e.Vu == false)
                .ToListAsync()
                ;

            list.ForEach(e => e.Vu = true);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok();
        }


        [HttpPost]
        public override async Task<ActionResult<Chat>> Post(Chat model)
        {
            _context.Chats.Add(model);
            // var user = _context.Users.Find(model.IdSender);

            try
            {
                await _context.SaveChangesAsync();
                //
                var isCollaborateur = HttpContext.GetRoleUser() == 3;


                if (isCollaborateur)
                {
                    var listAdminOrAgentSI = ConnectedUser.dict.Values.Where(e => e.IdRole == 2 || e.IdRole == 1).ToList();

                    listAdminOrAgentSI.ForEach(async e =>
                    {
                        await _chatHub.Clients.Client(e.ConnectionId).SendAsync("ReceiveMessage", model); //, $"{user.Nom} {user.Prenom}"
                    });
                }
                else
                {
                    var connectionId = ConnectedUser.dict.Values.Where(e => e.IdUser == model.IdCollaboratteur).Select(e => e.ConnectionId).FirstOrDefault();
                    if (connectionId != null)
                    {
                        await _chatHub.Clients.Client(connectionId).SendAsync("ReceiveMessage", model);
                    }
                }


            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return Ok(model);
        }

    }
}
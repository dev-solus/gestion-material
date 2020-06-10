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

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChatsController : SuperController<Chat>
    {
        public ChatsController(MyContext context) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{idSender}/{idReceiver}/{message}/{idTicketSupport}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, int idSender, int idReceiver, string message, int idTicketSupport)
        {
            var q = _context.Chats
                .Where(e => idSender == 0 ? true : e.IdSender == idSender)
                .Where(e => idReceiver == 0 ? true : e.IdReceiver == idReceiver)
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
                .Select(e => new{
                    Id = e.Id,
                    Message = e.Message,
                    Vu = e.Vu,
                    Date = e.Date,
                    IdSender = e.IdSender,
                    Sender = e.Sender.Nom,
                })
                .ToListAsync()
                ;
            return Ok(list);
        }

    }
}
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
    public class TicketSupportsController : SuperController<TicketSupport>
    {
        public TicketSupportsController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{question}/{priorite}/{idCollaborateur}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string question, string priorite, int idCollaborateur)
        {
            var q = _context.TicketSupports
                .Where(e => question == "*" ? true : e.Question.ToLower().Contains(question.ToLower()))
.Where(e => priorite == "*" ? true : e.Priorite.ToLower().Contains(priorite.ToLower()))
.Where(e => idCollaborateur == 0 ? true : e.IdCollaborateur == idCollaborateur)

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<TicketSupport>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
question = e.Question,
dateCreation = e.DateCreation,
priorite = e.Priorite,
collaborateur = e.Collaborateur.Nom,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
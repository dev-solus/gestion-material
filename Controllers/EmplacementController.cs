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
    public class EmplacementsController : SuperController<Emplacement>
    {
        public EmplacementsController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{codeEmplacement}/{idDepartement}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string codeEmplacement, int idDepartement)
        {
            var q = _context.Emplacements
                .Where(e => codeEmplacement == "*" ? true : e.CodeEmplacement.ToLower().Contains(codeEmplacement.ToLower()))
.Where(e => idDepartement == 0 ? true : e.IdDepartement == idDepartement)

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Emplacement>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
codeEmplacement = e.CodeEmplacement,
description = e.Description,
departement = e.Departement.Nom,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
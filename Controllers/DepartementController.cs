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
    public class DepartementsController : SuperController<Departement>
    {
        public DepartementsController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nom}/{etage}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string nom, string etage)
        {
            var q = _context.Departements
                .Where(e => nom == "*" ? true : e.Nom.ToLower().Contains(nom.ToLower()))
.Where(e => etage == "*" ? true : e.Etage.ToLower().Contains(etage.ToLower()))

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Departement>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
nom = e.Nom,
etage = e.Etage,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
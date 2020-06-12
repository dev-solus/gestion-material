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
using Microsoft.AspNetCore.Authorization;

namespace Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(Roles = "1")]
    public class ServicesController : SuperController<Service>
    {
        public ServicesController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nom}/{idDepartement}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string nom, int idDepartement)
        {
            var q = _context.Services
                .Where(e => nom == "*" ? true : e.Nom.ToLower().Contains(nom.ToLower()))
.Where(e => idDepartement == 0 ? true : e.IdDepartement == idDepartement)

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Service>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
nom = e.Nom,
departement = e.Departement.Nom,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
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
    //[Authorize(Roles = "1, 2")]
    public class FournisseursController : SuperController<Fournisseur>
    {
        public FournisseursController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nom}/{tel}/{fax}/{email}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string nom, string tel, string fax, string email)
        {
            var q = _context.Fournisseurs
                .Where(e => nom == "*" ? true : e.Nom.ToLower().Contains(nom.ToLower()))
.Where(e => tel == "*" ? true : e.Tel.ToLower().Contains(tel.ToLower()))
.Where(e => fax == "*" ? true : e.Fax.ToLower().Contains(fax.ToLower()))
.Where(e => email == "*" ? true : e.Email.ToLower().Contains(email.ToLower()))

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Fournisseur>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
nom = e.Nom,
tel = e.Tel,
fax = e.Fax,
email = e.Email,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
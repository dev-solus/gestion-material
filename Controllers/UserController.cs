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
    public class UsersController : SuperController<User>
    {
        public UsersController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nom}/{matricule}/{prenom}/{email}/{codeOfVerification}/{idService}/{idFonction}/{idRole}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string nom, string matricule, string prenom, string email, string codeOfVerification, int idService, int idFonction, int idRole)
        {
            var q = _context.Users
                .Where(e => nom == "*" ? true : e.Nom.ToLower().Contains(nom.ToLower()))
.Where(e => matricule == "*" ? true : e.Matricule.ToLower().Contains(matricule.ToLower()))
.Where(e => prenom == "*" ? true : e.Prenom.ToLower().Contains(prenom.ToLower()))
.Where(e => email == "*" ? true : e.Email.ToLower().Contains(email.ToLower()))
.Where(e => codeOfVerification == "*" ? true : e.CodeOfVerification.ToLower().Contains(codeOfVerification.ToLower()))
.Where(e => idService == 0 ? true : e.IdService == idService)
.Where(e => idFonction == 0 ? true : e.IdFonction == idFonction)
.Where(e => idRole == 0 ? true : e.IdRole == idRole)

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<User>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
nom = e.Nom,
matricule = e.Matricule,
prenom = e.Prenom,
email = e.Email,
password = e.Password,
codeOfVerification = e.CodeOfVerification,
emailVerified = e.EmailVerified,
isActive = e.IsActive,
service = e.Service.Nom,
fonction = e.Fonction.Nom,
role = e.Role.Name,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
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
    public class AffectationsController : SuperController<Affectation>
    {
        public AffectationsController(MyContext context) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{action_}/{idEquipement}/{idEmplacement}/{idCollaborateur}/{idAgentSi}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, string action_, int idEquipement, int idEmplacement, int idCollaborateur, int idAgentSi)
        {
            var idRole = HttpContext.GetRoleUser();
            var idUser = HttpContext.GetIdUser();

            var q = _context.Affectations
                .Where(e => action_ == "*" ? true : e.Action.ToLower().Contains(action_.ToLower()))
                .Where(e => idEquipement == 0 ? true : e.IdEquipement == idEquipement)
                .Where(e => idEmplacement == 0 ? true : e.IdEmplacement == idEmplacement)
                .Where(e => idRole == 3 ? e.IdCollaborateur == idUser : (idCollaborateur == 0 ? true : e.IdCollaborateur == idCollaborateur))
                .Where(e => idAgentSi == 0 ? true : e.IdAgentSi == idAgentSi)
                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Affectation>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)

                .Select(e => new
                {
                    id = e.Id,
                    action = e.Action,
                    date = e.Date,
                    equipement = e.Equipement.NSerie,
                    emplacement = e.Emplacement.CodeEmplacement,
                    collaborateur = e.Collaborateur.Nom,
                    agentSi = e.AgentSi.Nom,
                    IdAgentSi = e.IdAgentSi,
                    IdCollaborateur = e.IdCollaborateur,
                    IdEmplacement = e.IdEmplacement,
                    IdEquipement = e.IdEquipement,

                })
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
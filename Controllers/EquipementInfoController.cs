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
    public class EquipementInfosController : SuperController<EquipementInfo>
    {
        public EquipementInfosController(MyContext context) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nSerie}/{model}/{nom}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, string nSerie, string model, string nom)
        {
            var q = _context.EquipementInfos
                .Where(e => nSerie == "*" ? true : e.NSerie.ToLower().Contains(nSerie.ToLower()))
                .Where(e => model == "*" ? true : e.Model.ToLower().Contains(model.ToLower()))
                .Where(e => nom == "*" ? true : e.Nom.ToLower().Contains(nom.ToLower()))

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<EquipementInfo>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)

                .Select(e => new
                {
                    id = e.Id,
                    nSerie = e.NSerie,
                    model = e.Model,
                    nom = e.Nom,
                    date = e.Date,
                    InfoSystemeHtml = e.InfoSystemeHtml,
                    SoftwareHtml = e.SoftwareHtml,
                    user = _context.Affectations    
                        .Where(o => o.Equipement.NSerie == e.NSerie)
                        .Select(s => s.Collaborateur.Nom + " " + s.Collaborateur.Prenom )
                        .FirstOrDefault()
                })
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

        [HttpPost]
        public override async Task<ActionResult<EquipementInfo>> Post(EquipementInfo model)
        {
            var eq = await _context.EquipementInfos.Where(e => e.NSerie == model.NSerie).FirstOrDefaultAsync();

            if (eq != null)
            {
                eq.Date = model.Date;
                eq.Model = model.Model;
                eq.Nom = model.Nom;
                eq.InfoSystemeHtml = model.InfoSystemeHtml;
                eq.SoftwareHtml = model.SoftwareHtml;
            }
            else
            {
                _context.EquipementInfos.Add(model);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return eq != null ? Ok(new { message = "updated" }) : Ok(new { message = "added" });
        }


    }
}
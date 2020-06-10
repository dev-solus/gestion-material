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
    public class EquipementsController : SuperController<Equipement>
    {
        public EquipementsController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nSerie}/{model}/{refAchat}/{etatActuel}/{prixUnitaireHT}/{nInventaire}/{remarques}/{idConstucteur}/{idCategorie}/{idStatut}/{idFournisseur}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string nSerie, string model, string refAchat, string etatActuel, int prixUnitaireHT, string nInventaire, string remarques, int idConstucteur, int idCategorie, int idStatut, int idFournisseur)
        {
            var q = _context.Equipements
                .Where(e => nSerie == "*" ? true : e.NSerie.ToLower().Contains(nSerie.ToLower()))
.Where(e => model == "*" ? true : e.Model.ToLower().Contains(model.ToLower()))
.Where(e => refAchat == "*" ? true : e.RefAchat.ToLower().Contains(refAchat.ToLower()))
.Where(e => etatActuel == "*" ? true : e.EtatActuel.ToLower().Contains(etatActuel.ToLower()))
.Where(e => prixUnitaireHT == 0 ? true : e.PrixUnitaireHT == prixUnitaireHT)
.Where(e => nInventaire == "*" ? true : e.NInventaire.ToLower().Contains(nInventaire.ToLower()))
.Where(e => remarques == "*" ? true : e.Remarques.ToLower().Contains(remarques.ToLower()))
.Where(e => idConstucteur == 0 ? true : e.IdConstucteur == idConstucteur)
.Where(e => idCategorie == 0 ? true : e.IdCategorie == idCategorie)
.Where(e => idStatut == 0 ? true : e.IdStatut == idStatut)
.Where(e => idFournisseur == 0 ? true : e.IdFournisseur == idFournisseur)

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<Equipement>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)
                
                .Select(e => new 
{
id = e.Id,
nSerie = e.NSerie,
model = e.Model,
dateAchat = e.DateAchat,
refAchat = e.RefAchat,
etatActuel = e.EtatActuel,
prixUnitaireHT = e.PrixUnitaireHT,
nInventaire = e.NInventaire,
remarques = e.Remarques,
constucteur = e.Constucteur.Nom,
categorie = e.Categorie.Nom,
statut = e.Statut.Nom,
fournisseur = e.Fournisseur.Nom,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
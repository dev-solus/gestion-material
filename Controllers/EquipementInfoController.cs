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

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nSerie}/{stringInfo}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir, string nSerie, string stringInfo)
        {
            var q = _context.EquipementInfos
                .Where(e => nSerie == "*" ? true : e.NSerie.ToLower().Contains(nSerie.ToLower()))
                .Where(e => stringInfo == "*" ? true : e.InfoSystemeHtml.ToLower().Contains(stringInfo.ToLower()))

                ;

            int count = await q.CountAsync();

            var list = await q.OrderByName<EquipementInfo>(sortBy, sortDir == "desc")
                .Skip(startIndex)
                .Take(pageSize)

                .Select(e => new
                {
                    id = e.Id,
                    nSerie = e.NSerie,
                    date = e.Date,
                    InfoSystemeHtml = e.InfoSystemeHtml,
                    SoftwareHtml = e.SoftwareHtml,

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
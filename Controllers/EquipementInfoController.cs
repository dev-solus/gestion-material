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
        public EquipementInfosController(MyContext context ) : base(context)
        { }

        [HttpGet("{startIndex}/{pageSize}/{sortBy}/{sortDir}/{nSerie}/{stringInfo}")]
        public async Task<IActionResult> GetAll(int startIndex, int pageSize, string sortBy, string sortDir , string nSerie, string stringInfo)
        {
            var q = _context.EquipementInfos
                .Where(e => nSerie == "*" ? true : e.NSerie.ToLower().Contains(nSerie.ToLower()))
.Where(e => stringInfo == "*" ? true : e.StringInfo.ToLower().Contains(stringInfo.ToLower()))

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
stringInfo = e.StringInfo,

})
                .ToListAsync()
                ;

            return Ok(new { list = list, count = count });
        }

    }
}
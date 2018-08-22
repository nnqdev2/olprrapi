﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlprrApi.Services;

namespace OlprrApi.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    //[Route("api/lust")]
    [Route("lust")]
    public class LustController : Controller
    {
        private readonly ILogger<LustController> _logger;
        private readonly ILustService _lustService;
        public LustController(ILogger<LustController> logger, ILustService lustService)
        {
            _logger = logger;
            _lustService = lustService;
        }

        [Route("sitealias/{lustId}")]
        [HttpGet]
        public async Task<IActionResult> GetSiteAlias(int lustId)
        {
            return Ok(await _lustService.GetSiteAlias(lustId));
        }

        [Route("sitealias")]
        [HttpPost]
        public async Task<IActionResult> InsUpdSiteAlias([FromBody] Models.Request.ApInsUpdSiteAlias apInsUpdSiteAlias)
        {
            var siteAliasId = await _lustService.InsUpdSiteAlias(apInsUpdSiteAlias);
            if (apInsUpdSiteAlias.SiteNameAliasIdIn == 0)
            {
                apInsUpdSiteAlias.SiteNameAliasIdIn = siteAliasId;
                return CreatedAtAction("InsUpdSiteAlias", new { sitenamealiasid = siteAliasId }, apInsUpdSiteAlias);
            }
            return NoContent();
            //return Ok(await _olprrReviewService.InsUpdSiteAlias(apInsUpdSiteAlias));
        }
        [Route("sitealias/{siteNameAliasId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSiteAlias(int siteNameAliasId)
        {
            await _lustService.ApDltSiteNameAlias(siteNameAliasId);
            return NoContent();
        }

        [Route("contact")]
        [HttpGet]
        public async Task<IActionResult> GetContacts([FromQuery] string fname, [FromQuery] string lname, [FromQuery] string org, [FromQuery] int sc, [FromQuery] int so, [FromQuery] int pn, [FromQuery] int rpp)
        {
            return Ok(await _lustService.GetContacts(fname, lname, org, sc, so, pn, rpp));
        }

    }
}
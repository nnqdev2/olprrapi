using System.Threading.Tasks;
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

        //[Route("sitealiases/{lustId}")]
        [Route("lustid/{lustId}/sitealiases")]
        [HttpGet]
        public async Task<IActionResult> GetSiteAliases(int lustId)
        {
            return Ok(await _lustService.GetSiteAliases(lustId));
        }

        [Route("sitealias/{siteNameAliasId}")]
        [HttpGet]
        public async Task<IActionResult> GetSiteAlias(int siteNameAliasId)
        {
            return Ok(await _lustService.GetSiteAlias(siteNameAliasId));
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

        [Route("postalcounty/{county}")]
        [HttpGet]
        public async Task<IActionResult> GetCountyIdAndNameFromZP4Fips(int county)
        {
            return Ok(await _lustService.GetCountyIdAndNameFromZP4Fips(county));
        }

        [Route("incident/{lustId}")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentByIdData(int lustId)
        {
            return Ok(await _lustService.GetIncidentByIdData(lustId));
        }
        [Route("pm/{lustId}")]
        [HttpGet]
        public async Task<IActionResult> GetCurrentProjMgr(int lustId)
        {
            return Ok(await _lustService.GetCurrentProjMgr(lustId));
        }

        [Route("incident")]
        [HttpPost]
        public async Task<IActionResult> UpdIncidentData([FromBody] Models.Request.ApInsUpdIncidentData apInsUpdIncidentData)
        {
            return Ok(await _lustService.InsUpdLustIncident(apInsUpdIncidentData));
        }

        [Route("lustid/{lustId}/lognumber")]
        [HttpGet]
        public async Task<IActionResult> GetLogNumber(int lustId)
        {
            return Ok(await _lustService.GetLogNumber(lustId));
        }

        [Route("contact/{affilId}")]
        [HttpGet]
        public async Task<IActionResult> GetAffilById(int affilId)
        {
            return Ok(await _lustService.GetAffilById(affilId));
        }

        [Route("lustid/{lustId}/contact")]
        [HttpGet]
        public async Task<IActionResult> GetPartyGridByLustIdData(int affilId)
        {
            return Ok(await _lustService.GetPartyGridByLustIdData(affilId));
        }

        [Route("lustid/{lustId}/contact")]
        [HttpPost]
        public async Task<IActionResult> InsUpdLustAffilPartyData([FromBody] Models.Request.ApInsUpdLustAffilPartyData apInsUpdLustAffilPartyData)
        {
            return Ok(await _lustService.InsUpdLustAffilPartyData(apInsUpdLustAffilPartyData));
        }

        [Route("lustid/{lustId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLustIncident(int lustId)
        {
            await _lustService.ApDltIncidentByLustId(lustId);
            return NoContent();
        }
    }
}
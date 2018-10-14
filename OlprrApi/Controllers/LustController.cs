using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlprrApi.Models.Request;
using OlprrApi.Models.Response;
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

        /// <summary>
        /// List of all site aliases for a lust id
        /// (ApGetSiteAliasByLustIdData)
        /// </summary>
        /// <param name="lustId">LUST incident id</param>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApGetSiteAliasByLustId2>))]
        [ProducesResponseType(400, Type = typeof(void))]
        [Route("lustid/{lustId}/sitealiases")]
        [HttpGet]
        public async Task<IActionResult> GetSiteAliases(int lustId)
        {
            return Ok(await _lustService.GetSiteAliases(lustId));
        }

        /// <summary>
        /// Site Alias by site alias id
        /// (ApGetSiteAliasBySiteNameAliasIdData)
        /// </summary>
        /// <param name="siteNameAliasId">LUST incident site alias id</param>
        [ProducesResponseType(200, Type = typeof(ApGetSiteAliasByLustId2))]
        [Route("sitealias/{siteNameAliasId}")]
        [HttpGet]
        public async Task<IActionResult> GetSiteAlias(int siteNameAliasId)
        {
            return Ok(await _lustService.GetSiteAlias(siteNameAliasId));
        }

        /// <summary>
        /// Insert/Update site alias data for a lust incident
        /// (ApInsUpdSiteAliasData)
        /// </summary>
        /// <param name="apInsUpdSiteAlias">Site alias data to insert or update</param>
        [ProducesResponseType(201, Type = typeof(ApInsUpdSiteAlias))]
        [ProducesResponseType(204, Type = typeof(void))]
        [ProducesResponseType(400, Type = typeof(void))]
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

        /// <summary>
        /// Delete site alias data for a lust incident
        /// (ApDltSiteNameAlias)
        /// </summary>
        /// <param name="siteNameAliasId">site alias id</param>
        [ProducesResponseType(204, Type = typeof(void))]
        [Route("sitealias/{siteNameAliasId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteSiteAlias(int siteNameAliasId)
        {
            await _lustService.ApDltSiteNameAlias(siteNameAliasId);
            return NoContent();
        }

        /// <summary>
        /// List of all contacts 
        /// (ApGetPartyByFirstLastOrgNameData)
        /// </summary>
        /// <param name="fname">First name</param>
        /// <param name="lname">Last name</param>
        /// <param name="org">Organization</param>
        /// <param name="sc">Sort column</param>
        /// <param name="so">Sort order</param>
        /// <param name="pn">Page number</param>
        /// <param name="rpp">Rows per page</param>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContactsStats>))]
        [Route("contact")]
        [HttpGet]
        public async Task<IActionResult> GetContacts([FromQuery] string fname, [FromQuery] string lname, [FromQuery] string org, [FromQuery] int sc, [FromQuery] int so, [FromQuery] int pn, [FromQuery] int rpp)
        {
            return Ok(await _lustService.GetContacts(fname, lname, org, sc, so, pn, rpp));
        }

        /// <summary>
        /// GetCountyIdAndNameFromZP4Fips 
        /// (ApGetCountyIdAndNameFromZP4Fips) 
        /// </summary>
        /// <param name="county">County code</param>
        [ProducesResponseType(200, Type = typeof(ApGetCountyIdAndNameFromZP4Fips))]
        [Route("postalcounty/{county}")]
        [HttpGet]
        public async Task<IActionResult> GetCountyIdAndNameFromZP4Fips(int county)
        {
            return Ok(await _lustService.GetCountyIdAndNameFromZP4Fips(county));
        }

        /// <summary>
        /// Get LUST incident 
        /// (ApGetIncidentByIdData) 
        /// </summary>
        /// <param name="lustId">LUST incident id</param>
        [ProducesResponseType(200, Type = typeof(LustIncident))]
        [Route("incident/{lustId}")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentByIdData(int lustId)
        {
            return Ok(await _lustService.GetIncidentByIdData(lustId));
        }

        /// <summary>
        /// Get list of current project managers
        /// (ApGetCurrentProjMgr)
        /// </summary>
        /// <param name="lustId">LUST incident id</param>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProjectManager>))]
        [Route("pm/{lustId}")]
        [HttpGet]
        public async Task<IActionResult> GetCurrentProjMgr(int lustId)
        {
            return Ok(await _lustService.GetCurrentProjMgr(lustId));
        }

        /// <summary>
        /// Update LUST incident
        /// (ApUpdIncidentData)
        /// </summary>
        /// <param name="apInsUpdIncidentData">LUST incident data</param>
        [ProducesResponseType(200, Type = typeof(ApInsUpdIncidentDataResult))]
        [Route("incident")]
        [HttpPost]
        public async Task<IActionResult> UpdIncidentData([FromBody] Models.Request.ApInsUpdIncidentData apInsUpdIncidentData)
        {
            return Ok(await _lustService.InsUpdLustIncident(apInsUpdIncidentData));
        }

        /// <summary>
        /// Update LUST incident
        /// (ApGetLogNumber)  
        /// </summary>
        /// <param name="lustId">LUST incident id</param>
        /// [ProducesResponseType(200, Type = typeof(ApGetLogNumber))]
        [Route("lustid/{lustId}/lognumber")]
        [HttpGet]
        public async Task<IActionResult> GetLogNumber(int lustId)
        {
            return Ok(await _lustService.GetLogNumber(lustId));
        }

        /// <summary>
        /// Get a contact id for lust incident
        /// (ApGetAffilByIdData) 
        /// </summary>
        /// <param name="affilId">LUST incident affiliate id</param>
        /// [ProducesResponseType(200, Type = typeof(ApGetAffilById))]
        [Route("contact/{affilId}")]
        [HttpGet]
        public async Task<IActionResult> GetAffilById(int affilId)
        {
            return Ok(await _lustService.GetAffilById(affilId));
        }

        //[Route("contact/{affilId}")]
        //[HttpDelete]
        //public async Task<IActionResult> DeleteLustContactByAffilId(int affilId)
        //{
        //    await _lustService.ApDltLustContactByAffilId(affilId);
        //    return NoContent();
        //}

        /// <summary>
        /// Get all contacts for lust incident
        /// (ApGetPartyGridByLustIdData) 
        /// </summary>
        /// <param name="lustId">LUST incident id</param>
        /// [ProducesResponseType(200, Type = typeof(IEnumerable<ApGetAffilById>))]
        [Route("lustid/{lustId}/contact")]
        [HttpGet]
        public async Task<IActionResult> GetPartyGridByLustIdData(int lustId)
        {
            return Ok(await _lustService.GetPartyGridByLustIdData(lustId));
        }

        /// <summary>
        /// Insert/Update Contact for a LUST incident
        /// (ApInsUpdLustAffilPartyData) 
        /// </summary>
        /// <param name="apInsUpdLustAffilPartyData">Contact data for a LUST incident</param>
        /// [ProducesResponseType(200, Type = typeof(ApInsUpdLustAffilPartyDataResult))]
        [Route("lustid/{lustId}/contact")]
        [HttpPost]
        public async Task<IActionResult> InsUpdLustAffilPartyData([FromBody] Models.Request.ApInsUpdLustAffilPartyData apInsUpdLustAffilPartyData)
        {
            return Ok(await _lustService.InsUpdLustAffilPartyData(apInsUpdLustAffilPartyData));
        }

        /// <summary>
        /// Delete a lust incident
        /// (ApDltIncidentByLustId)
        /// </summary>
        /// <param name="lustId">LUST incident id</param>
        [ProducesResponseType(204, Type = typeof(void))]
        [Route("lustid/{lustId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteLustIncident(int lustId)
        {
            await _lustService.ApDltIncidentByLustId(lustId);
            return NoContent();
        }


    }
}
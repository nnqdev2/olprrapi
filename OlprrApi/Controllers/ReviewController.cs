using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlprrApi.Common.Exceptions;
using OlprrApi.Models.Response;
using OlprrApi.Services;
using ApGetLustSearchDataStats = OlprrApi.Models.Response.ApGetLustSearchDataStats;

namespace OlprrApi.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [EnableCors("AllowAllHeaders")]
    [Produces("application/json")]
    [Route("review")]
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IOlprrReviewService _olprrReviewService;
        public ReviewController(ILogger<ReviewController> logger, IOlprrReviewService olprrReviewService)
        {
            _logger = logger;
            _olprrReviewService = olprrReviewService;
        }


        //[Route("lustsearch")]
        //[HttpPost]
        //public async Task<IActionResult> LustSearch([FromBody] Models.Request.LustSiteAddressSearch lustSiteAddressSearch)
        //{
        //    return Ok(await _olprrReviewService.SearchLust(lustSiteAddressSearch));
        //}

        /// <summary>
        /// Get OLPRR incident
        /// (apOlprrGetIncidentById)
        /// </summary>
        /// <param name="olprrId">Get OLPRR Incident</param>
        [ProducesResponseType(200, Type = typeof(IncidentById))]
        [Route("incident/{olprrId}")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentById(int olprrId) => Ok(await _olprrReviewService.GetIncidentById(olprrId));

        /// <summary>
        /// Search LUST incident by filters
        /// (apGetLustSearchData)
        /// </summary>
        /// <param name="lustSearchFilter">Search filters</param>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApGetLustSearchDataStats>))]
        [ProducesResponseType(400, Type = typeof(void))]
        [Route("lustsite")]
        [HttpPost]
        public async Task<IActionResult> SearchLust([FromBody] Models.Request.LustSearchFilter lustSearchFilter) => Ok(await _olprrReviewService.Search(lustSearchFilter));

        /// <summary>
        /// Search UST by filters
        /// (apOLPRRGetUstLookupData)
        /// </summary>
        /// <param name="ustSearchFilter">Search filters</param>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApOlprrGetUstLookupDataStats>))]
        [ProducesResponseType(400, Type = typeof(void))]
        [Route("ustsite")]
        [HttpPost]
        public async Task<IActionResult> SearchUst([FromBody] Models.Request.UstSearchFilter ustSearchFilter) => Ok(await _olprrReviewService.Search(ustSearchFilter));

        /// <summary>
        /// get a contact for OLPRR incident  by contact type
        /// (ApOLPRRGetContactByIdByContactType)
        /// </summary>
        /// <param name="olprrId">OLPRR id</param>
        /// <param name="contactType">Contact Type</param>
        [ProducesResponseType(200, Type = typeof(ApOLPRRGetContactByIdByContactType))]
        [ProducesResponseType(500, Type = typeof(StoreProcedureNonZeroOutputParamException))]
        [Route("contact/{olprrId}/{contactType}")]
        [HttpGet]
        public async Task<IActionResult> GetContactByIdByContactType(int olprrId, string contactType) => Ok(await _olprrReviewService.GetContactByIdByContactType(olprrId, contactType));

        /// <summary>
        /// Search UST by filters
        /// (apOLPRRGetIncidents)
        /// </summary>
        /// <param name="deqo">DEQ office</param>
        /// <param name="stat">Status</param>
        /// <param name="st">Site Type</param>
        /// <param name="id">OLPRR id</param>
        /// <param name="sc">Sort column</param>
        /// <param name="so">Sort order</param>
        /// <param name="pn">Page number</param>
        /// <param name="rpp">Rows per page</param>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApOlprrGetIncidentsWithStats>))]
        [ProducesResponseType(400, Type = typeof(void))]
        [ProducesResponseType(500, Type = typeof(StoreProcedureNonZeroOutputParamException))]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetIncidents([FromQuery] string deqo, [FromQuery] string stat, [FromQuery] string st, [FromQuery] string id
     , [FromQuery] int sc, [FromQuery] int so, [FromQuery] int pn, [FromQuery] int rpp)
        {
            return Ok(await _olprrReviewService.GetIncidentsStats(deqo, stat, st, id, sc, so, pn, rpp));
        }

        /// <summary>
        /// get OLPRR incident by OLRR id
        /// (apOLPRRGetIncidentDataByID)
        /// </summary>
        /// <param name="olprrId">OLPRR id</param>
        [ProducesResponseType(200, Type = typeof(IncidentDataById))]
        [ProducesResponseType(500, Type = typeof(StoreProcedureNonZeroOutputParamException))]
        [Route("incidentdatabyid/{olprrId}")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentDataById(int olprrId) => Ok(await _olprrReviewService.GetIncidentDataById(olprrId));

        /// <summary>
        /// County check
        /// (apOLPRRCheckPostalCountyData)
        /// </summary>
        /// <param name="reported">Reported county</param>
        /// <param name="uspostal">County from US Postal check</param>
        [ProducesResponseType(200, Type = typeof(ApOlprrCheckPostalCounty))]
        [Route("postalcounty")]
        [HttpGet]
        public async Task<IActionResult> GetApOlprrCheckPostalCounty([FromQuery] int reported, [FromQuery] string uspostal) => Ok(await _olprrReviewService.GetApOlprrCheckPostalCounty(reported, uspostal));

        /// <summary>
        /// Insert OLPRR review into LUST
        /// (apCreateIncidentData)
        /// </summary>
        /// <param name="olprrReviewIncident">OLPRR review incident to insert into LUST</param>
        [ProducesResponseType(200, Type = typeof(OlprrReviewIncidentResult))]
        [ProducesResponseType(400, Type = typeof(void))]
        [Route("lustincident")]
        [HttpPost]
        public async Task<IActionResult> CreateLustIncident([FromBody] Models.Request.OlprrReviewIncident olprrReviewIncident)
        {
            return Ok(await _olprrReviewService.CreateLustIncident(olprrReviewIncident));
        }
    }
}
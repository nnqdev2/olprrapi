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
    //[Route("api/Review")]
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

        [Route("lustsearch")]
        [HttpPost]
        public async Task<IActionResult> LustSearch([FromBody] Models.Request.LustSiteAddressSearch lustSiteAddressSearch)
        {
            //https://stackoverflow.com/questions/14202257/design-restful-query-api-with-a-long-list-of-query-parameters
            return Ok(await _olprrReviewService.SearchLust(lustSiteAddressSearch));
        }
        [Route("incident/{olprrId}")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentById(int olprrId)
        {
            return Ok(await _olprrReviewService.GetIncidentById(olprrId));
        }
        [Route("lustsite")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] Models.Request.LustSearchFilter lustSearchFilter)
        //public IActionResult Search([FromBody] Models.Request.LustSearchFilter lustSearchFilter)
        {
            //https://stackoverflow.com/questions/14202257/design-restful-query-api-with-a-long-list-of-query-parameters
            return Ok(await _olprrReviewService.Search(lustSearchFilter));

        }
        [Route("contact/{olprrId}/{contactType}")]
        [HttpGet]
        public async Task<IActionResult> GetContactByIdByContactType(int olprrId, string contactType)
        {
            return Ok(await _olprrReviewService.GetContactByIdByContactType(olprrId, contactType));
        }
        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetIncidents([FromQuery] string deqo, [FromQuery] string stat, [FromQuery] string st, [FromQuery] string id
        //   , [FromQuery] int sc, [FromQuery] int so, [FromQuery] int pn, [FromQuery] int rpp)
        //{
        //    return Ok(await _olprrReviewService.GetIncidentsWithStats(deqo,stat,st,id,sc,so,pn,rpp));
        //}

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetIncidents([FromQuery] string deqo, [FromQuery] string stat, [FromQuery] string st, [FromQuery] string id
        //    , [FromQuery] int sc, [FromQuery] int so, [FromQuery] int pn, [FromQuery] int rpp)
        //{
        //    return Ok(await _olprrReviewService.GetIncidents(deqo, stat, st, id, sc, so, pn, rpp));
        //}


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetIncidents([FromQuery] string deqo, [FromQuery] string stat, [FromQuery] string st, [FromQuery] string id
     , [FromQuery] int sc, [FromQuery] int so, [FromQuery] int pn, [FromQuery] int rpp)
        {
            return Ok(await _olprrReviewService.GetIncidentsStats(deqo, stat, st, id, sc, so, pn, rpp));
        }

        [Route("incidentdatabyid/{olprrId}")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentDataById(int olprrId)
        {
            return Ok(await _olprrReviewService.GetIncidentDataById(olprrId));
        }
    }
}
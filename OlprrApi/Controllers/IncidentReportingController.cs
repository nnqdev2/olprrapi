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
    //[Route("api/OLPRR")]
    [Route("olprr")]
    public class IncidentReportingController : Controller
    {
        private readonly ILogger<IncidentReportingController> _logger;
        private readonly IIncidentReportingService _olprrService;

        public IncidentReportingController(ILogger<IncidentReportingController> logger, IIncidentReportingService incidentReportingService)
        {
            _logger = logger;
            _olprrService = incidentReportingService;
        }

        [Route("confirmationtype")]
        [HttpGet]
        public async Task<IActionResult> GetConfirmationTypes()
        {
            return Ok(await _olprrService.GetConfirmationTypes());
        }

        //[Route("confirmationtype")]
        //[HttpGet]
        ////public async Task<IActionResult> GetConfirmationTypes()
        //public IActionResult GetConfirmationTypes()
        //{
        //    throw new FileNotFoundException(@"[data.txt not in c:\temp directory]");
        //    //return BadRequest("this endpoint sucks caused it failed!!");
        //    //return Ok(await _olprrService.GetConfirmationTypes());
        //}
        [Route("county")]
        [HttpGet]
        public async Task<IActionResult> GetCounties()
        {
            return Ok(await _olprrService.GetCounties());
        }
        [Route("discoverytype")]
        [HttpGet]
        public async Task<IActionResult> GetDiscoveryTypes()
        {
            return Ok(await _olprrService.GetDiscoveryTypes());
        }
        [Route("quadrant")]
        [HttpGet]
        public async Task<IActionResult> GetQuadrants()
        {
            return Ok(await _olprrService.GetQuadrants());
        }
        [Route("releasecausetype")]
        [HttpGet]
        public async Task<IActionResult> GetReleaseCauseTypes()
        {
            return Ok(await _olprrService.GetReleaseCauseTypes());
        }
        [Route("sitetype")]
        [HttpGet]
        public async Task<IActionResult> GetSiteTypes()
        {
            return Ok(await _olprrService.GetSiteTypes());
        }
        [Route("sourcetype")]
        [HttpGet]
        public async Task<IActionResult> GetSourceTypes()
        {
            return Ok(await _olprrService.GetSourceTypes());
        }
        [Route("state")]
        [HttpGet]
        public async Task<IActionResult> GetStates()
        {
            return Ok(await _olprrService.GetStates());
        }
        [Route("streettype")]
        [HttpGet]
        public async Task<IActionResult> GetStreetTypes()
        {
            return Ok(await _olprrService.GetStreetTypes());
        }
        [Route("deqoffice")]
        [HttpGet]
        public async Task<IActionResult> GetDeqOffices()
        {
            return Ok(await _olprrService.GetDeqOffices());
        }
        [Route("incidentstatus")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentStatuses()
        {
            return Ok(await _olprrService.GetIncidentStatuses());
        }
        [Route("tankstatus")]
        [HttpGet]
        public async Task<IActionResult> GetTankStatuses()
        {
            return Ok(await _olprrService.GetTankStatuses());
        }
        [Route("filestatus")]
        [HttpGet]
        public async Task<IActionResult> GetFileStatuses()
        {
            return Ok(await _olprrService.GetFileStatuses());
        }
        [Route("zipcode")]
        [HttpGet]
        public async Task<IActionResult> GetZipCodes()
        {
            return Ok(await _olprrService.GetZipCodes());
        }
        [Route("datecompare")]
        [HttpGet]
        public async Task<IActionResult> GetDateCompares()
        {
            return Ok(await _olprrService.GetDateCompares());
        }
        [Route("region")]
        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            return Ok(await _olprrService.GetRegions());
        }
        [Route("city")]
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await _olprrService.GetCities());
        }
        [Route("cleanupsitetype")]
        [HttpGet]
        public async Task<IActionResult> GetCleanupSiteTypes()
        {
            return Ok(await _olprrService.GetCleanupSiteTypes());
        }
        [Route("projectmanager")]
        [HttpGet]
        public async Task<IActionResult> GetProjectManagers()
        {
            return Ok(await _olprrService.GetProjectManagers());
        }
        [Route("sitetype2")]
        [HttpGet]
        public async Task<IActionResult> GetSiteType2s()
        {
            return Ok(await _olprrService.GetSiteType2s());
        }
        [Route("brownfield")]
        [HttpGet]
        public async Task<IActionResult> GetBrownfields()
        {
            return Ok(await _olprrService.GetBrownfields());
        }
        [Route("contacttype")]
        [HttpGet]
        public async Task<IActionResult> GetContactTypes()
        {
            return Ok(await _olprrService.GetContactTypes());
        }
        [Route("contacttype2")]
        [HttpGet]
        public async Task<IActionResult> GetContactType2s()
        {
            return Ok(await _olprrService.GetContactType2s());
        }
        [Route("incident")]
        [HttpPost]
        public async Task<IActionResult> PostIncident([FromBody] Models.Request.ApOLPRRInsertIncident apOLPRRInsertIncident)
        {
            var x = await _olprrService.InsertOLPRRIncidentRecord(apOLPRRInsertIncident);
            return Created("olprr/incident", apOLPRRInsertIncident);
        }

        [Route("log")]
        [HttpPost]
        public IActionResult PostLog([FromBody] Models.Request.OlprrLogEntry olprrLogEntry)
        {
            _olprrService.InsertOLPRRLogEntry(olprrLogEntry);
            return Created("olprr/log", olprrLogEntry);
        }

    }
}










//namespace TodoApi.Controllers
//{
//    [EnableCors("AllowSpecificOrigin")]
//    //[EnableCors("AllowAllHeaders")]
//    [Produces("application/json")]
//    //[Route("api/OLPRR")]
//    [Route("olprr")]
//    public class IncidentReportingController : Controller
//    {
//        private readonly ILogger<IncidentReportingController> _logger;
//        private readonly IIncidentReportingService _olprrService;

//        public IncidentReportingController(ILogger<IncidentReportingController> logger, IIncidentReportingService incidentReportingService)
//        {
//            _logger = logger;
//            _olprrService = incidentReportingService;
//        }

//        [Route("confirmationtype")]
//        [HttpGet]
//        public async Task<IActionResult> GetConfirmationTypes()
//        {
//            return Ok(await _olprrService.GetConfirmationTypes());
//        }
//        [Route("county")]
//        [HttpGet]
//        public async Task<IActionResult> GetCounties()
//        {
//            return Ok(await _olprrService.GetCounties());
//        }
//        [Route("discoverytype")]
//        [HttpGet]
//        public async Task<IActionResult> GetDiscoveryTypes()
//        {
//            return Ok(await _olprrService.GetDiscoveryTypes());
//        }
//        [Route("quadrant")]
//        [HttpGet]
//        public async Task<IActionResult> GetQuadrants()
//        {
//            return Ok(await _olprrService.GetQuadrants());
//        }
//        [Route("releasecausetype")]
//        [HttpGet]
//        public async Task<IActionResult> GetReleaseCauseTypes()
//        {
//            return Ok(await _olprrService.GetReleaseCauseTypes());
//        }
//        [Route("sitetype")]
//        [HttpGet]
//        public async Task<IActionResult> GetSiteTypes()
//        {
//            return Ok(await _olprrService.GetSiteTypes());
//        }
//        [Route("sourcetype")]
//        [HttpGet]
//        public async Task<IActionResult> GetSourceTypes()
//        {
//            return Ok(await _olprrService.GetSourceTypes());
//        }
//        [Route("state")]
//        [HttpGet]
//        public async Task<IActionResult> GetStates()
//        {
//            return Ok(await _olprrService.GetStates());
//        }
//        [Route("streettype")]
//        [HttpGet]
//        public async Task<IActionResult> GetStreetTypes()
//        {
//            return Ok(await _olprrService.GetStreetTypes());
//        }


//        [Route("incident")]
//        [HttpPost]
//        public async Task<IActionResult> PostIncident([FromBody] Models.Request.ApOlprrInsertIncident apOLPRRInsertIncident)
//        {
//            var x = await _olprrService.InsertOLPRRIncidentRecord(apOLPRRInsertIncident);
//            return Created("olprr/incident", apOLPRRInsertIncident);
//        }

//    }
//}
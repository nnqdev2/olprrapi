using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OlprrApi.Models.Response;
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

        /// <summary>
        /// List of confirmation types 
        /// (apGetOLPRRLookupTables {ConfirmationType})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ConfirmationType>))]
        [Route("confirmationtype")]
        [HttpGet]
        public async Task<IActionResult> GetConfirmationTypes() => Ok(await _olprrService.GetConfirmationTypes());

        /// <summary>
        /// List of counties 
        /// (apGetOLPRRLookupTables {County})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<County>))]
        [Route("county")]
        [HttpGet]
        public async Task<IActionResult> GetCounties() => Ok(await _olprrService.GetCounties());

        /// <summary>
        /// List of discovery types
        /// (apGetOLPRRLookupTables {DiscoveryType})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<DiscoveryType>))]
        [Route("discoverytype")]
        [HttpGet]
        public async Task<IActionResult> GetDiscoveryTypes() => Ok(await _olprrService.GetDiscoveryTypes());

        /// <summary>
        /// List of quadrants
        /// (apGetOLPRRLookupTables {Quadrant})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<QuadrantT>))]
        [Route("quadrant")]
        [HttpGet]
        public async Task<IActionResult> GetQuadrants() => Ok(await _olprrService.GetQuadrants());

        /// <summary>
        /// List of Release Cause Types
        /// (apGetOLPRRLookupTables {ReleaseCauseTypes})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReleaseCauseType>))]
        [Route("releasecausetype")]
        [HttpGet]
        public async Task<IActionResult> GetReleaseCauseTypes() => Ok(await _olprrService.GetReleaseCauseTypes());

        /// <summary>
        /// List of Site Types
        /// (apGetOLPRRLookupTables {SiteType})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<SiteTypeT>))]
        [Route("sitetype")]
        [HttpGet]
        public async Task<IActionResult> GetSiteTypes() => Ok(await _olprrService.GetSiteTypes());

        /// <summary>
        /// List of Source Types
        /// (apGetOLPRRLookupTables {SourceType})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<SourceType>))]
        [Route("sourcetype")]
        [HttpGet]
        public async Task<IActionResult> GetSourceTypes() => Ok(await _olprrService.GetSourceTypes());

        /// <summary>
        /// List of States
        /// (apGetOLPRRLookupTables {State})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<State>))]
        [Route("state")]
        [HttpGet]
        public async Task<IActionResult> GetStates() => Ok(await _olprrService.GetStates());

        /// <summary>
        /// List of States
        /// (apGetOLPRRLookupTables {State})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<State>))]
        [Route("streettype")]
        [HttpGet]
        public async Task<IActionResult> GetStreetTypes() => Ok(await _olprrService.GetStreetTypes());

        /// <summary>
        /// List of DEQ Offices
        /// (apGetOLPRRLookupTables {DeqOffice})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<DeqOfficeT>))]
        [Route("deqoffice")]
        [HttpGet]
        public async Task<IActionResult> GetDeqOffices() => Ok(await _olprrService.GetDeqOffices());

        /// <summary>
        /// List of Incident Statuses
        /// (apGetOLPRRLookupTables {IncidentStatus})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<IncidentStatusT>))]
        [Route("incidentstatus")]
        [HttpGet]
        public async Task<IActionResult> GetIncidentStatuses() => Ok(await _olprrService.GetIncidentStatuses());

        /// <summary>
        /// List of Tank Statuses
        /// (apGetOLPRRLookupTables {TankStatus})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<TankStatus>))]
        [Route("tankstatus")]
        [HttpGet]
        public async Task<IActionResult> GetTankStatuses() => Ok(await _olprrService.GetTankStatuses());

        /// <summary>
        /// List of File Statuses
        /// (apGetOLPRRLookupTables {FileStatus})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<FileStatus>))]
        [Route("filestatus")]
        [HttpGet]
        public async Task<IActionResult> GetFileStatuses() => Ok(await _olprrService.GetFileStatuses());

        /// <summary>
        /// List of ZipCodes
        /// (apGetOLPRRLookupTables {ZipCode})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ZipCode>))]
        [Route("zipcode")]
        [HttpGet]
        public async Task<IActionResult> GetZipCodes() => Ok(await _olprrService.GetZipCodes());

        /// <summary>
        /// List of Date Compares
        /// (apGetOLPRRLookupTables {DateCompare})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<DateCompare>))]
        [Route("datecompare")]
        [HttpGet]
        public async Task<IActionResult> GetDateCompares() => Ok(await _olprrService.GetDateCompares());

        /// <summary>
        /// List of Regions
        /// (apGetOLPRRLookupTables {Region})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<Region>))]
        [Route("region")]
        [HttpGet]
        public async Task<IActionResult> GetRegions() => Ok(await _olprrService.GetRegions());

        /// <summary>
        /// List of Cities
        /// (apGetOLPRRLookupTables {City})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<City>))]
        [Route("city")]
        [HttpGet]
        public async Task<IActionResult> GetCities() => Ok(await _olprrService.GetCities());

        /// <summary>
        /// List of Cleanup Site Types
        /// (apGetOLPRRLookupTables {CleanupSiteType})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<CleanupSiteType>))]
        [Route("cleanupsitetype")]
        [HttpGet]
        public async Task<IActionResult> GetCleanupSiteTypes() => Ok(await _olprrService.GetCleanupSiteTypes());

        /// <summary>
        /// List of ProjectManagers
        /// (apGetOLPRRLookupTables {ProjectManager})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProjectManager>))]
        [Route("projectmanager")]
        [HttpGet]
        public async Task<IActionResult> GetProjectManagers() => Ok(await _olprrService.GetProjectManagers());

        /// <summary>
        /// List of Site Types 
        /// (apGetLookupTablesByType {SiteType})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<SiteType2>))]
        [Route("sitetype2")]
        [HttpGet]
        public async Task<IActionResult> GetSiteType2s() => Ok(await _olprrService.GetSiteType2s());

        /// <summary>
        /// List of Brownfields 
        /// (apGetLookupTablesByType {Brownfield})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<Brownfield>))]
        [Route("brownfield")]
        [HttpGet]
        public async Task<IActionResult> GetBrownfields() => Ok(await _olprrService.GetBrownfields());

        /// <summary>
        /// List of Contact Types 
        /// (apGetLookupTablesByType {ContactTypes})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContactType>))]
        [Route("contacttype")]
        [HttpGet]
        public async Task<IActionResult> GetContactTypes() => Ok(await _olprrService.GetContactTypes());

        /// <summary>
        /// List of Contact Types with no Invoice
        /// (apGetLookupTablesByType {ContactTypesNoINV})
        /// </summary>
        [ProducesResponseType(200, Type = typeof(IEnumerable<ContactType>))]
        [Route("contacttype2")]
        [HttpGet]
        public async Task<IActionResult> GetContactType2s() => Ok(await _olprrService.GetContactType2s());

        /// <summary>
        /// Insert an OLPRR Incident
        /// (apOLPRRInsertIncident)
        /// </summary>
        /// <param name="apOLPRRInsertIncident">OLPRR data to insert</param>
        [ProducesResponseType(201, Type = typeof(int))]
        [ProducesResponseType(400, Type = typeof(void))]
        [Route("incident")]
        [HttpPost]
        public async Task<IActionResult> PostIncident([FromBody] Models.Request.ApOLPRRInsertIncident apOLPRRInsertIncident)
        {
            var x = await _olprrService.InsertOLPRRIncidentRecord(apOLPRRInsertIncident);
            return Created("olprr/incident", apOLPRRInsertIncident);
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
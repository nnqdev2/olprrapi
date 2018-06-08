using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using OlprrApi.Storage.Repositories;
using RequestDto = OlprrApi.Models.Request;
using ResponseDto = OlprrApi.Models.Response;
using EntityDto = OlprrApi.Storage.Entities;
using System.Text;

namespace OlprrApi.Services
{
    public class OlprrReviewService : IOlprrReviewService
    {

        private ILogger<OlprrReviewService> _logger;
        private IOlprrRepository _lustRepository;
        private readonly IMapper _mapper;
        public OlprrReviewService(ILogger<OlprrReviewService> logger, IOlprrRepository lustRepository, IMapper mapper)
        {
            _logger = logger;
            _lustRepository = lustRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseDto.LustSiteAddressSearch>> SearchLust(RequestDto.LustSiteAddressSearch lustSiteAddressSearch)
        {
            var searchFilters = _mapper.Map<RequestDto.LustSiteAddressSearch, EntityDto.LustSiteAddressSearch>(lustSiteAddressSearch);
            var resultList = new List<ResponseDto.LustSiteAddressSearch>();
            foreach (var result in await _lustRepository.GetApOLPRRGetLustLookup(searchFilters))
            {
                resultList.Add(_mapper.Map<EntityDto.ApOlprrGetLustLookup, ResponseDto.LustSiteAddressSearch>(result));
            }
            return resultList;
        }

        public async Task<ResponseDto.IncidentById> GetIncidentById(int olprrId)
        {
            var result =  await _lustRepository.ApOlprrGetIncidentById(olprrId);
            return (_mapper.Map<EntityDto.ApOlprrGetIncidentById, ResponseDto.IncidentById>(result));
        }

        public async Task<IEnumerable<ResponseDto.ApGetLustSearch>> Search(RequestDto.LustSearchFilter lustSearchFilter)
        {
            //var sqlInjectionEnabledWhereStatement = buildSqlInjectionEnabledWhereStatement(lustSearchFilter);
            var resultList = new List<ResponseDto.ApGetLustSearch>();
            foreach (var result in await _lustRepository.ApGetLustSearch("test"))
            {
                resultList.Add(_mapper.Map<EntityDto.ApGetLustSearch, ResponseDto.ApGetLustSearch>(result));
            }
            return resultList;
        }

        private string formatValue(string value, int len )
        {
            string newValue = null;
            var temp = value.Replace("'", "''");
            if (temp.Length > len)
            {
                newValue = temp.Substring(0, len);
            } else
            {
                newValue = temp;
            }
            return newValue.Trim();
        }

        private string buildSqlInjectionEnabledWhereStatement(RequestDto.LustSearchFilter lustSearchFilter)
        {
            StringBuilder where = new StringBuilder(" WHERE ( ");
            //COMPLETE LOG NUMBER SEARCH
            if ((lustSearchFilter.logCounty != null) && (lustSearchFilter.logYear != null) && (lustSearchFilter.logSeqNbr != null))
            {
                where.Append(" ( INC.LogNumber = '").Append(formatValue(lustSearchFilter.logCounty,2)).Append("-")
                    .Append(formatValue(lustSearchFilter.logYear,2)).Append("-").Append(formatValue(lustSearchFilter.logSeqNbr,4)).Append("' )  AND  ");
            } else
            {
                //'REGARDLESS OF WHICH ONE OF THE TWO COUNTY INPUT CONTROLS THIS COMES FROM, 
                //'frmSearch txtLogCounty -or- cmbCounty,
                //'THE COUNTY VALUE WILL ONLY BE ADDED ONCE.
                //'Log Number County Search
                if (lustSearchFilter.logCounty != null) {
                    where.Append(" ( INC.LogNbrCounty = '").Append(formatValue(lustSearchFilter.logCounty, 2)).Append("') AND ");
                }
                if (lustSearchFilter.logYear != null) {
                    where.Append(" ( INC.LogNbrYear = '").Append(formatValue(lustSearchFilter.logYear, 2)).Append("') AND ");
                }
                if (lustSearchFilter.logSeqNbr != null) {
                    where.Append(" ( INC.LogSeqNbr = '").Append(formatValue(lustSearchFilter.logSeqNbr, 4)).Append("') AND ");
                }
            }

            //'Facility ID
            if (lustSearchFilter.facilityId != null) {
                where.Append(" ( INC.FacilityId = '" ).Append(formatValue(lustSearchFilter.logSeqNbr, 4)).Append("') AND ");
            }

            //'Site Name
            if (lustSearchFilter.siteName != null)
            {
                var newValue = formatValue(lustSearchFilter.siteName, 40);
                where.Append(" (( INC.SiteName LIKE '").Append(newValue)
                    .Append("%') OR ( SNA.SiteNameAlias LIKE '").Append(newValue).Append("%')) AND ");
            }

            //'ADDRESS
            if (lustSearchFilter.siteAddress != null) {
                where.Append(" ( INC.SiteAddress LIKE '").Append(lustSearchFilter.siteAddress).Append("%') AND ")
                .Append(" ( INC.SiteAddress LIKE ' % ").Append(lustSearchFilter.siteAddress).Append(" % ') AND ");
            }

            //'CITY
            if (lustSearchFilter.siteCity != null)
            {
                where.Append(" ( INC.SiteCity LIKE '").Append(formatValue(lustSearchFilter.siteCity, 20)).Append("%') AND ")
                .Append(" ( INC.SiteCity LIKE ' % ").Append(formatValue(lustSearchFilter.siteCity, 20)).Append(" % ') AND ");
            }

            //'ZIP
            if (lustSearchFilter.siteZipcode != null)
            {
                where.Append(" ( INC.SiteZip LIKE '").Append(formatValue(lustSearchFilter.siteZipcode, 10)).Append("%') AND ")
                .Append(" ( INC.SiteZip LIKE ' % ").Append(formatValue(lustSearchFilter.siteZipcode, 10)).Append(" % ') AND ");
            }

            //'REGULATED TANK
            //if (lustSearchFilter.regInd) { 

            //    .Append(" ( INC.RegulatedTankInd = 1 ) AND ")
            //}

            //'HOT TANK
            //If Utility.IsObjectValid(searchCriteria.IsHotTank) _
            //And searchCriteria.IsHotTank = True Then
            //    .Append(" ( INC.HotInd = 1 ) AND ")
            //End If

            //'UNREGULATED - NON HOT TANK
            //'-- Not a Regulated Tank, and not a HOT Tank.
            //If Utility.IsObjectValid(searchCriteria.IsUnRegTank) _
            //And searchCriteria.IsUnRegTank = True Then
            //    .Append(" ( INC.RegulatedTankInd = 0 ) AND ( INC.HotInd = 0 ) AND ")
            //End If

            //'SITE TYPE
            //If Utility.IsObjectValid(searchCriteria.SiteType) Then
            //    .Append(" ( INC.SiteTypeId = '" + searchCriteria.SiteType.ToString + "')" + " AND ")
            //End If

            //'SITE STATUS
            //If Utility.IsObjectValid(searchCriteria.SiteStatus) Then
            //    .Append(" ( INC.FileStatusId = '" + searchCriteria.SiteStatus.ToString + "')" + " AND ")
            //End If

            //''PROJECT MANAGER
            //'
            //'add functionality to search by "Unassigned"
            //If Utility.IsObjectValid(searchCriteria.ProjectManager) Then
            //    Select Case searchCriteria.ProjectManager.ToString
            //        Case "1"
            //            .Append(" INC.LustId NOT IN (SELECT NoPM.LUSTID FROM LUST.dbo.ProjectManagerHistory NoPM)" + " AND ")
            //        Case Else
            //            .Append(" ( PMH.PMLogin = '" + searchCriteria.ProjectManager.ToString + "') AND PMH.EndDate IS NULL " + " AND ")
            //    End Select
            //End If





            return where.ToString();
        }

        public async Task<ResponseDto.ApOLPRRGetContactByIdByContactType> GetContactByIdByContactType(int olprrId, string contactType)
        {
            var result = await _lustRepository.ApOLPRRGetContactByIdByContactType(olprrId,contactType);
            return (_mapper.Map<EntityDto.ApOLPRRGetContactByIdByContactType, ResponseDto.ApOLPRRGetContactByIdByContactType>(result));
        }

        public async Task<IEnumerable<ResponseDto.ApOlprrGetIncidents>> GetIncidents(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var resultList = new List<ResponseDto.ApOlprrGetIncidents>();
            foreach (var result in await _lustRepository.ApOlprrGetIncidents(office, status, siteType, olprrId, sortColumn, sortOrder, pageNumber, rowsPerPage))
            {
                resultList.Add(_mapper.Map<EntityDto.ApOlprrGetIncidents, ResponseDto.ApOlprrGetIncidents>(result));
            }
            return resultList;
        }

        public async Task<ResponseDto.ApOlprrGetIncidentsWithStats> GetIncidentsWithStats(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var result = await _lustRepository.ApOlprrGetIncidentsWithStats(office, status, siteType, olprrId, sortColumn, sortOrder, pageNumber, rowsPerPage);
            return (_mapper.Map<EntityDto.ApOlprrGetIncidentsWithStats, ResponseDto.ApOlprrGetIncidentsWithStats>(result));
        }

        public async Task<IEnumerable<ResponseDto.ApOlprrGetIncidentsStats>> GetIncidentsStats(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var resultList = new List<ResponseDto.ApOlprrGetIncidentsStats>();
            foreach (var result in await _lustRepository.ApOlprrGetIncidentsStats(office, status, siteType, olprrId, sortColumn, sortOrder, pageNumber, rowsPerPage))
            {
                resultList.Add(_mapper.Map<EntityDto.ApOlprrGetIncidentsStats, ResponseDto.ApOlprrGetIncidentsStats>(result));
            }
            return resultList;
        }
    }
}

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

        public async Task<IEnumerable<ResponseDto.ApGetLustSearchDataStats>> Search(RequestDto.LustSearchFilter lustSearchFilter)
        {
            var searchFilters = _mapper.Map<RequestDto.LustSearchFilter, EntityDto.LustSearchFilter>(lustSearchFilter);
            var resultList = new List<ResponseDto.ApGetLustSearchDataStats>();
            foreach (var result in await _lustRepository.ApGetLustSearchData(searchFilters))
            {
                resultList.Add(_mapper.Map<EntityDto.ApGetLustSearchDataStats, ResponseDto.ApGetLustSearchDataStats>(result));
            }
            return resultList;
        }

        public async Task<IEnumerable<ResponseDto.ApOlprrGetUstLookupDataStats>> Search(RequestDto.UstSearchFilter ustSearchFilter)
        {
            var searchFilters = _mapper.Map<RequestDto.UstSearchFilter, EntityDto.UstSearchFilter>(ustSearchFilter);
            var resultList = new List<ResponseDto.ApOlprrGetUstLookupDataStats>();
            foreach (var result in await _lustRepository.ApOlprrGetUstLookupData(searchFilters))
            {
                resultList.Add(_mapper.Map<EntityDto.ApOlprrGetUstLookupDataStats, ResponseDto.ApOlprrGetUstLookupDataStats>(result));
            }
            return resultList;
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

        public async Task<ResponseDto.IncidentDataById> GetIncidentDataById(int olprrId)
        {
            foreach (var result in await _lustRepository.ApOlprrGetIncidentDataById(olprrId))
            {
                return(_mapper.Map<EntityDto.ApOlprrGetIncidentDataById, ResponseDto.IncidentDataById>(result));
            }
            return null;
        }

        public async Task<ResponseDto.ApOlprrCheckPostalCounty> GetApOlprrCheckPostalCounty(int reportedCountyCode, string usPostalCountyCodeFips)
        {
            var result = await _lustRepository.ApOlprrCheckPostalCounty(reportedCountyCode, (usPostalCountyCodeFips??"000"));
            return (_mapper.Map<EntityDto.ApOlprrCheckPostalCounty, ResponseDto.ApOlprrCheckPostalCounty>(result));

        }

        public async Task<ResponseDto.OlprrReviewIncidentResult> CreateLustIncident(RequestDto.OlprrReviewIncident olprrReviewIncident)
        {
            var incidentData = _mapper.Map<RequestDto.OlprrReviewIncident, EntityDto.OlprrReviewIncident>(olprrReviewIncident);
            var result = await _lustRepository.ApCreateIncidentData(incidentData);
            return (_mapper.Map<EntityDto.OlprrReviewIncidentResult, ResponseDto.OlprrReviewIncidentResult>(result));
        }

    }
}

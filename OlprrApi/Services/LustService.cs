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
    public class LustService : ILustService
    {
        private ILogger<LustService> _logger;
        private ILustRepository _lustRepository;
        private readonly IMapper _mapper;
        public LustService(ILogger<LustService> logger, ILustRepository lustRepository, IMapper mapper)
        {
            _logger = logger;
            _lustRepository = lustRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseDto.ApGetSiteAliasByLustId2>> GetSiteAliases(int lustId)
        {
            var resultList = new List<ResponseDto.ApGetSiteAliasByLustId2>();
            foreach (var result in await _lustRepository.ApGetSiteAliasByLustId(lustId))
            {
                resultList.Add(_mapper.Map<EntityDto.ApGetSiteAliasByLustId2, ResponseDto.ApGetSiteAliasByLustId2>(result));
            }
            return resultList;
        }
        public async Task<ResponseDto.ApGetSiteAliasByLustId2> GetSiteAlias(int siteNameAliasId)
        {
            var result = await _lustRepository.ApGetSiteAliasBySiteNameAliasIdData(siteNameAliasId);
            return _mapper.Map<EntityDto.ApGetSiteAliasByLustId2, ResponseDto.ApGetSiteAliasByLustId2>(result);
        }
        public async Task<int> InsUpdSiteAlias(RequestDto.ApInsUpdSiteAlias apInsUpdSiteAlias)
        {
            var siteAliasData = _mapper.Map<RequestDto.ApInsUpdSiteAlias, EntityDto.ApInsUpdSiteAlias>(apInsUpdSiteAlias);
            return await _lustRepository.ApInsUpdSiteAlias(siteAliasData);
        }
        public async Task ApDltSiteNameAlias(int siteNameAliasId)
        {
            await _lustRepository.ApDltSiteNameAlias(siteNameAliasId);
        }
        public async Task<IEnumerable<ResponseDto.ContactsStats>> GetContacts(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            if (fname != null && fname == "null") fname = null;
            if (lname != null && lname == "null") lname = null;
            if (org != null && org == "null") org = null;
            var resultList = new List<ResponseDto.ContactsStats>();
            foreach (var result in await _lustRepository.ApGetPartyByFirstLastOrgName(fname, lname, org, sortColumn, sortOrder, pageNumber, rowsPerPage))
            {
                resultList.Add(_mapper.Map<EntityDto.ContactsStats, ResponseDto.ContactsStats>(result));
            }
            return resultList;
        }

        public async Task<ResponseDto.ApGetCountyIdAndNameFromZP4Fips> GetCountyIdAndNameFromZP4Fips(int usPostalCountyCodeFips)
        {
            var result = await _lustRepository.ApGetCountyIdAndNameFromZP4Fips((usPostalCountyCodeFips));
            return (_mapper.Map<EntityDto.ApGetCountyIdAndNameFromZP4Fips, ResponseDto.ApGetCountyIdAndNameFromZP4Fips>(result));
        }
        public async Task<ResponseDto.LustIncident> GetIncidentByIdData(int lustId)
        {
            foreach (var result in await _lustRepository.ApGetIncidentByIdData(lustId))
            {
                return (_mapper.Map<EntityDto.LustIncident, ResponseDto.LustIncident>(result));
            }
            return null;
        }
        public async Task<IEnumerable<ResponseDto.ProjectManager>> GetCurrentProjMgr(int lustId)
        {
            var resultList = new List<ResponseDto.ProjectManager>();
            foreach (var result in await _lustRepository.ApGetCurrentProjMgr(lustId))
            {
                resultList.Add(_mapper.Map<EntityDto.ProjectManagerIncident, ResponseDto.ProjectManager>(result));
            }
            return resultList;
        }

        public async Task<ResponseDto.ApInsUpdIncidentDataResult> InsUpdLustIncident(RequestDto.ApInsUpdIncidentData apInsUpdIncidentData)
        {
            var lustData = _mapper.Map<RequestDto.ApInsUpdIncidentData, EntityDto.ApInsUpdIncidentData>(apInsUpdIncidentData);
            var result = await _lustRepository.ApInsUpdIncidentData(lustData);
            return (_mapper.Map<EntityDto.ApInsUpdIncidentDataResult, ResponseDto.ApInsUpdIncidentDataResult>(result));
        }
    }
}

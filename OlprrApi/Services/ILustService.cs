using OlprrApi.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using RequestDto = OlprrApi.Models.Request;
using ResponseDto = OlprrApi.Models.Response;

namespace OlprrApi.Services
{
    public interface ILustService
    {
        Task<IEnumerable<ApGetSiteAliasByLustId2>> GetSiteAliases(int lustId);
        Task<ApGetSiteAliasByLustId2> GetSiteAlias(int siteNameAliasId);
        Task<int> InsUpdSiteAlias(RequestDto.ApInsUpdSiteAlias apInsUpdSiteAlias);
        Task ApDltSiteNameAlias(int siteNameAliasId);
        Task<IEnumerable<ResponseDto.ContactsStats>> GetContacts(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);
        Task<ResponseDto.ApGetCountyIdAndNameFromZP4Fips> GetCountyIdAndNameFromZP4Fips(int usPostalCountyCodeFips);
        Task<ResponseDto.LustIncident> GetIncidentByIdData(int lustId);
        Task<IEnumerable<ResponseDto.ProjectManager>> GetCurrentProjMgr(int lustId);
        Task<ApInsUpdIncidentDataResult> InsUpdLustIncident(RequestDto.ApInsUpdIncidentData apInsUpdIncidentData);
        Task<ApGetLogNumber> GetLogNumber(int lustId);
        Task<ApGetAffilById> GetAffilById(int affilId);
        Task<IEnumerable<ApGetAffilById>> GetPartyGridByLustIdData(int lustId);
        Task<ApInsUpdLustAffilPartyDataResult> InsUpdLustAffilPartyData (RequestDto.ApInsUpdLustAffilPartyData apInsUpdLustAffilPartyData);
    }
}

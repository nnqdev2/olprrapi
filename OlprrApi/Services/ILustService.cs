using OlprrApi.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using RequestDto = OlprrApi.Models.Request;
using ResponseDto = OlprrApi.Models.Response;

namespace OlprrApi.Services
{
    public interface ILustService
    {
        Task<IEnumerable<ApGetSiteAliasByLustId2>> GetSiteAlias(int lustId);
        Task<int> InsUpdSiteAlias(RequestDto.ApInsUpdSiteAlias apInsUpdSiteAlias);
        Task ApDltSiteNameAlias(int siteNameAliasId);
        Task<IEnumerable<ResponseDto.ContactsStats>> GetContacts(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);
        Task<ResponseDto.ApGetCountyIdAndNameFromZP4Fips> GetCountyIdAndNameFromZP4Fips(int usPostalCountyCodeFips);
    }
}

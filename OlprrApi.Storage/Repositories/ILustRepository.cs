using System.Collections.Generic;
using System.Threading.Tasks;
using OlprrApi.Storage.Entities;

namespace OlprrApi.Storage.Repositories
{
    public interface ILustRepository
    {
        Task<IEnumerable<ApGetSiteAliasByLustId2>> ApGetSiteAliasByLustId(int lustId);
        Task<ApGetSiteAliasByLustId2> ApGetSiteAliasBySiteNameAliasIdData(int siteNameAliasId);
        Task<int> ApInsUpdSiteAlias(ApInsUpdSiteAlias apInsUpdSiteAlias);
        Task ApDltSiteNameAlias(int siteNameAliasId);
        Task<IEnumerable<ContactsStats>> ApGetPartyByFirstLastOrgName(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);
        Task<ApGetCountyIdAndNameFromZP4Fips> ApGetCountyIdAndNameFromZP4Fips(int usPostalCountyCodeFips);
        Task<IEnumerable<LustIncident>> ApGetIncidentByIdData (int lustId);
        Task<IEnumerable<ProjectManagerIncident>> ApGetCurrentProjMgr(int lustId);
        Task<ApInsUpdIncidentDataResult> ApInsUpdIncidentData(ApInsUpdIncidentData apInsUpdIncidentData);
        Task<ApGetLogNumber> ApGetLogNumber(int lustId);
        Task<ApGetAffilById> ApGetAffilById(int affilId);
        Task<IEnumerable<ApGetAffilById>> ApGetPartyGridByLustIdData(int lustId);
        Task<ApInsUpdLustAffilPartyDataResult> ApInsUpdLustAffilPartyData(ApInsUpdLustAffilPartyData apInsUpdLustAffilPartyData);
        Task ApDltLustContactByAffilId(int affilId);
        Task ApDltIncidentByLustId(int lustId);
    }
}

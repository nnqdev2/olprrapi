using System.Collections.Generic;
using System.Threading.Tasks;
using OlprrApi.Storage.Entities;

namespace OlprrApi.Storage.Repositories
{
    public interface IOlprrRepository
    {
        // Olprr external web form
        Task<IEnumerable<ConfirmationType>> GetConfirmationTypes();
        Task<IEnumerable<County>> GetCounties();
        Task<IEnumerable<DiscoveryType>> GetDiscoveryTypes();
        Task<IEnumerable<QuadrantT>> GetQuadrants();
        Task<IEnumerable<ReleaseCauseType>> GetReleaseCauseTypes();
        Task<IEnumerable<SiteTypeT>> GetSiteTypes();
        Task<IEnumerable<SourceType>> GetSourceTypes();
        Task<IEnumerable<State>> GetStates();
        Task<IEnumerable<StreetTypeT>> GetStreetTypes();
        Task<IEnumerable<DeqOfficeT>> GetDeqOffices();
        Task<IEnumerable<IncidentStatusT>> GetIncidentStatuses();
        Task<IEnumerable<City>> GetCities();
        Task<IEnumerable<FileStatus>> GetFileStatuses();
        Task<IEnumerable<TankStatus>> GetTankStatuses();
        Task<IEnumerable<CleanupSiteType>> GetCleanupSiteTypes();
        Task<IEnumerable<ZipCode>> GetZipCodes();
        Task<IEnumerable<Region>> GetRegions();
        Task<IEnumerable<DateCompare>> GetDateCompares();
        Task<IEnumerable<ProjectManager>> GetProjectManagers();



        Task<int> InsertOLPRRIncidentRecord(ApOlprrInsertIncident apOLPRRInsertIncident);
        Task<IEnumerable<ApOlprrGetLustLookup>> GetApOLPRRGetLustLookup(LustSiteAddressSearch lustSiteAddressSearch);
        Task<ApOlprrGetIncidentById> ApOlprrGetIncidentById(int olprrId);
        Task<ApOLPRRGetContactByIdByContactType> ApOLPRRGetContactByIdByContactType(int olprrId,string contactType);
        Task<IEnumerable<ApGetLustSearchDataStats>> ApGetLustSearchData(LustSearchFilter lustSearchFilter);
        Task<IEnumerable<ApOlprrGetUstLookupDataStats>> ApOlprrGetUstLookupData(UstSearchFilter ustSearchFilter);

        // Olprr review form
        void ApRetrieveGeoLocId(string appId);
        Task<ApOlprrGetIncidentsWithStats> ApOlprrGetIncidentsWithStats(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);

        Task<IEnumerable<ApOlprrGetIncidents>> ApOlprrGetIncidents(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);

        Task<IEnumerable<ApOlprrGetIncidentsStats>> ApOlprrGetIncidentsStats(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);

        Task<IEnumerable<ApOlprrGetIncidentDataById>> ApOlprrGetIncidentDataById(int olprrId);
        Task<ApOlprrCheckPostalCounty> ApOlprrCheckPostalCounty(int reportedCountyCode, string usPostalCountyCodeFips);

        Task<OlprrReviewIncidentResult> ApCreateIncidentData(OlprrReviewIncident olprrReviewIncident);

        Task<IEnumerable<ApGetSiteAliasByLustId2>> ApGetSiteAliasByLustId(int lustId);

        Task<int> ApInsUpdSiteAlias(ApInsUpdSiteAlias apInsUpdSiteAlias);

    }
}

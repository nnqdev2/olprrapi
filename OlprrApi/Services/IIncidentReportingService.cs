using System.Collections.Generic;
using System.Threading.Tasks;
using OlprrApi.Models.Request;
using OlprrApi.Models.Response;

namespace OlprrApi.Services
{
    public interface IIncidentReportingService
    {
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


        Task<IEnumerable<FileStatus>> GetFileStatuses();
        Task<IEnumerable<TankStatus>> GetTankStatuses();
        Task<IEnumerable<ZipCode>> GetZipCodes();
        Task<IEnumerable<DateCompare>> GetDateCompares();
        Task<IEnumerable<CleanupSiteType>> GetCleanupSiteTypes();
        Task<IEnumerable<City>> GetCities();
        Task<IEnumerable<Region>> GetRegions();
        Task<IEnumerable<ProjectManager>> GetProjectManagers();
        Task<IEnumerable<SiteType2>> GetSiteType2s();
        Task<IEnumerable<Brownfield>> GetBrownfields();
        Task<IEnumerable<ContactType>> GetContactTypes();
        Task<IEnumerable<ContactType>> GetContactType2s();

        Task<int> InsertOLPRRIncidentRecord(ApOLPRRInsertIncident apOLPRRInsertIncident);
        void InsertOLPRRLogEntry(OlprrLogEntry olprrLogEntry);
    }
}

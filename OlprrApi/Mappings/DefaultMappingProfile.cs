using AutoMapper;

namespace OlprrApi.Mappings
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Storage.Entities.ConfirmationType, Models.Response.ConfirmationType>();
            CreateMap<Storage.Entities.County, Models.Response.County>();
            CreateMap<Storage.Entities.DiscoveryType, Models.Response.DiscoveryType>();
            CreateMap<Storage.Entities.QuadrantT, Models.Response.QuadrantT>();
            CreateMap<Storage.Entities.ReleaseCauseType, Models.Response.ReleaseCauseType>();
            CreateMap<Storage.Entities.SiteTypeT, Models.Response.SiteTypeT>();
            CreateMap<Storage.Entities.SourceType, Models.Response.SourceType>();
            CreateMap<Storage.Entities.State, Models.Response.State>();
            CreateMap<Storage.Entities.SiteTypeT, Models.Response.SiteTypeT>();
            CreateMap<Storage.Entities.StreetTypeT, Models.Response.StreetTypeT>();
            CreateMap<Storage.Entities.DeqOfficeT, Models.Response.DeqOfficeT>();
            CreateMap<Storage.Entities.IncidentStatusT, Models.Response.IncidentStatusT>();
            CreateMap<Models.Request.ApOLPRRInsertIncident, Storage.Entities.ApOlprrInsertIncident>();
            CreateMap<Models.Request.LustSiteAddressSearch, Storage.Entities.LustSiteAddressSearch>();
            CreateMap<Storage.Entities.ApOlprrGetLustLookup, Models.Response.LustSiteAddressSearch>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentById, Models.Response.IncidentById>();
            CreateMap<Storage.Entities.ApGetLustSearch, Models.Response.ApGetLustSearch>();
            CreateMap<Storage.Entities.ApOLPRRGetContactByIdByContactType, Models.Response.ApOLPRRGetContactByIdByContactType>();
            CreateMap<Storage.Entities.ApOlprrGetIncidents, Models.Response.ApOlprrGetIncidents>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentsWithStats, Models.Response.ApOlprrGetIncidentsWithStats>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentsStats, Models.Response.ApOlprrGetIncidentsStats>();
        }
    }
}


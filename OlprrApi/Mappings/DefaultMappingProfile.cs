﻿using AutoMapper;

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

            CreateMap<Storage.Entities.FileStatus, Models.Response.FileStatus>();
            CreateMap<Storage.Entities.TankStatus, Models.Response.TankStatus>();
            CreateMap<Storage.Entities.CleanupSiteType, Models.Response.CleanupSiteType>();
            CreateMap<Storage.Entities.Region, Models.Response.Region>();
            CreateMap<Storage.Entities.ZipCode, Models.Response.ZipCode>();
            CreateMap<Storage.Entities.City, Models.Response.City>();
            CreateMap<Storage.Entities.DateCompare, Models.Response.DateCompare>();
            CreateMap<Storage.Entities.ProjectManageIncident, Models.Response.ProjectManager>();
            CreateMap<Storage.Entities.SiteType2, Models.Response.SiteType2>();
            CreateMap<Storage.Entities.Brownfield, Models.Response.Brownfield>();
            CreateMap<Storage.Entities.ContactType, Models.Response.ContactType>();

            CreateMap<Models.Request.ApOLPRRInsertIncident, Storage.Entities.ApOlprrInsertIncident>();
            CreateMap<Models.Request.LustSiteAddressSearch, Storage.Entities.LustSiteAddressSearch>();
            CreateMap<Storage.Entities.ApOlprrGetLustLookup, Models.Response.LustSiteAddressSearch>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentById, Models.Response.IncidentById>();
            CreateMap<Storage.Entities.ApGetLustSearchDataStats, Models.Response.ApGetLustSearch>();
            CreateMap<Storage.Entities.ApOLPRRGetContactByIdByContactType, Models.Response.ApOLPRRGetContactByIdByContactType>();
            CreateMap<Storage.Entities.ApOlprrGetIncidents, Models.Response.ApOlprrGetIncidents>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentsWithStats, Models.Response.ApOlprrGetIncidentsWithStats>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentsStats, Models.Response.ApOlprrGetIncidentsStats>();
            CreateMap<Storage.Entities.ApOlprrGetIncidentDataById, Models.Response.IncidentDataById>();
            CreateMap<Models.Request.LustSearchFilter, Storage.Entities.LustSearchFilter>();
            CreateMap<Storage.Entities.ApGetLustSearchDataStats, Models.Response.ApGetLustSearchDataStats>();
            CreateMap<Models.Request.UstSearchFilter, Storage.Entities.UstSearchFilter>();
            CreateMap<Storage.Entities.ApOlprrGetUstLookupDataStats, Models.Response.ApOlprrGetUstLookupDataStats>();
            CreateMap<Storage.Entities.ApOlprrCheckPostalCounty, Models.Response.ApOlprrCheckPostalCounty>();

            CreateMap<Models.Request.OlprrReviewIncident, Storage.Entities.OlprrReviewIncident>();
            CreateMap<Storage.Entities.OlprrReviewIncidentResult, Models.Response.OlprrReviewIncidentResult>();

            CreateMap<Storage.Entities.ApGetSiteAliasByLustId, Models.Response.ApGetSiteAliasByLustId>();
            CreateMap<Storage.Entities.ApGetSiteAliasByLustId2, Models.Response.ApGetSiteAliasByLustId2>();
            CreateMap<Models.Request.ApInsUpdSiteAlias, Storage.Entities.ApInsUpdSiteAlias>();

            CreateMap<Storage.Entities.Contact, Models.Response.Contact>();
            CreateMap<Storage.Entities.ContactsStats, Models.Response.ContactsStats>();
            CreateMap<Storage.Entities.ApGetCountyIdAndNameFromZP4Fips, Models.Response.ApGetCountyIdAndNameFromZP4Fips>();
            CreateMap<Storage.Entities.LustIncident, Models.Response.LustIncident>();
            CreateMap<Storage.Entities.ProjectManagerIncident, Models.Response.ProjectManager>();
            CreateMap<Models.Request.ApInsUpdIncidentData, Storage.Entities.ApInsUpdIncidentData>();
            CreateMap<Storage.Entities.ApInsUpdIncidentDataResult, Models.Response.ApInsUpdIncidentDataResult>();
            CreateMap<Storage.Entities.ApGetLogNumber, Models.Response.ApGetLogNumber>();
            CreateMap<Storage.Entities.ApGetAffilById, Models.Response.ApGetAffilById>();
            CreateMap<Models.Request.ApInsUpdLustAffilPartyData, Storage.Entities.ApInsUpdLustAffilPartyData>();
            CreateMap<Storage.Entities.ApInsUpdLustAffilPartyDataResult, Models.Response.ApInsUpdLustAffilPartyDataResult>();
        }
    }
}


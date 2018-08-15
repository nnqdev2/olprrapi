using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using OlprrApi.Storage.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System;
using OlprrApi.Common.Exceptions;
using Newtonsoft.Json;

namespace OlprrApi.Storage.Repositories
{
    public class OlprrRepository : IOlprrRepository
    {
        public const string ExecuteApGetOLPRRLookupTables = "execute dbo.apGetOLPRRLookupTables {0}";
        public const string ConfirmationTypeTable = "ConfirmationType";
        public const string CountiesTable = "Counties";
        public const string DiscoveryTypeTable = "DiscoveryType";
        public const string QuadrantTable = "Quadrant";
        public const string ReleaseCauseTypeTable = "ReleaseCauseType";
        public const string SiteTypeTable = "SiteType";
        public const string SourceTypeTable = "SourceType";
        public const string StatesTable = "States";
        public const string StreetTypeTable = "StreetType";
        public const string DeqOfficeTable = "DeqOffice";
        public const string IncidentStatusTable = "IncidentStatus";
        public const string TankStatusTable = "TankStatus";
        public const string CleanupSiteTypeTable = "CleanupSiteType";
        public const string RegionTable = "Region";
        public const string FileStatusTable = "FileStatus";
        public const string CityTable = "City";
        public const string DateCompareTable = "DateCompare";
        public const string ZipCodeTable = "ZipCode";
        public const string ProjectManagerTable = "ProjectManager";

        private LustDbContext _dbContext;
        private ILogger<OlprrRepository> _logger;
        public OlprrRepository(ILogger<OlprrRepository> logger, LustDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<ConfirmationType>> GetConfirmationTypes()
        {
            return await _dbContext.Set<ConfirmationType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, ConfirmationTypeTable).ToListAsync();
        }

        public async Task<IEnumerable<County>> GetCounties()
        {
            return await _dbContext.Set<County>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, CountiesTable).ToListAsync();
        }

        public async Task<IEnumerable<DiscoveryType>> GetDiscoveryTypes()
        {
            return await _dbContext.Set<DiscoveryType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, DiscoveryTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<QuadrantT>> GetQuadrants()
        {
            return await _dbContext.Set<QuadrantT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, QuadrantTable).ToListAsync();
        }
        public async Task<IEnumerable<ReleaseCauseType>> GetReleaseCauseTypes()
        {
            return await _dbContext.Set<ReleaseCauseType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, ReleaseCauseTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<SiteTypeT>> GetSiteTypes()
        {
            return await _dbContext.Set<SiteTypeT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, SiteTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<SourceType>> GetSourceTypes()
        {
            return await _dbContext.Set<SourceType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, SourceTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<State>> GetStates()
        {
            return await _dbContext.Set<State>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, StatesTable).ToListAsync();
        }
        public async Task<IEnumerable<StreetTypeT>> GetStreetTypes()
        {
            return await _dbContext.Set<StreetTypeT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, StreetTypeTable).ToListAsync();
        }

        public async Task<IEnumerable<DeqOfficeT>> GetDeqOffices()
        {
            return await _dbContext.Set<DeqOfficeT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, DeqOfficeTable).ToListAsync();
        }

        public async Task<IEnumerable<IncidentStatusT>> GetIncidentStatuses()
        {
            return await _dbContext.Set<IncidentStatusT>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables,IncidentStatusTable).ToListAsync();
        }
        public async Task<IEnumerable<TankStatus>> GetTankStatuses()
        {
            return await _dbContext.Set<TankStatus>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, TankStatusTable).ToListAsync();
        }
        public async Task<IEnumerable<FileStatus>> GetFileStatuses()
        {
            return await _dbContext.Set<FileStatus>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, FileStatusTable).ToListAsync();
        }
        public async Task<IEnumerable<Region>> GetRegions()
        {
            return await _dbContext.Set<Region>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, RegionTable).ToListAsync();
        }
        public async Task<IEnumerable<City>> GetCities()
        {
            return await _dbContext.Set<City>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, CityTable).ToListAsync();
        }
        public async Task<IEnumerable<ZipCode>> GetZipCodes()
        {
            return await _dbContext.Set<ZipCode>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, ZipCodeTable).ToListAsync();
        }
        public async Task<IEnumerable<CleanupSiteType>> GetCleanupSiteTypes()
        {
            return await _dbContext.Set<CleanupSiteType>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, CleanupSiteTypeTable).ToListAsync();
        }
        public async Task<IEnumerable<DateCompare>> GetDateCompares()
        {
            return await _dbContext.Set<DateCompare>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, DateCompareTable).ToListAsync();
        }
        public async Task<IEnumerable<ProjectManager>> GetProjectManagers()
        {
            return await _dbContext.Set<ProjectManager>().AsNoTracking().FromSql(ExecuteApGetOLPRRLookupTables, ProjectManagerTable).ToListAsync();
        }
        public async Task<int> InsertOLPRRIncidentRecord(ApOlprrInsertIncident apOLPRRInsertIncident)
        {
            var errNumParam = (new SqlParameter { ParameterName = "@ErrNum", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            var contractorUidParam = (new SqlParameter("@CONTRACTOR_UID", apOLPRRInsertIncident.ContractorUid));
            var contractorPwdParam = (new SqlParameter("@CONTRACTOR_PWD", apOLPRRInsertIncident.ContractorPwd));
            var reportedByParam    = (new SqlParameter("@REPORTED_BY", apOLPRRInsertIncident.ReportedBy));
            var reportedByPhoneParam = (new SqlParameter("@REPORTED_BY_PHONE", apOLPRRInsertIncident.ReportedByPhone));
            var reportedByEmailParam = (new SqlParameter("@REPORTED_BY_EMAIL", apOLPRRInsertIncident.ReportedByEmail));
            var releaseTypeParam = (new SqlParameter("@RELEASE_TYPE", apOLPRRInsertIncident.ReleaseType));
            var dateReceivedParam = (new SqlParameter("@DATE_RECEIVED", apOLPRRInsertIncident.DateReceived));
            var facilityIdParam = (new SqlParameter("@FACILITY_ID", apOLPRRInsertIncident.FacilityId));
            var siteNameParam = (new SqlParameter("@SITE_NAME", apOLPRRInsertIncident.SiteName));
            var siteCountyParam = (new SqlParameter("@SITE_COUNTY", apOLPRRInsertIncident.SiteCounty));
            var streetNbrParam = (new SqlParameter("@STREET_NBR", apOLPRRInsertIncident.StreetNbr));
            var streetQuadParam = (new SqlParameter("@STREET_QUAD", apOLPRRInsertIncident.StreetQuad));
            var streetNameParam = (new SqlParameter("@STREET_NAME", apOLPRRInsertIncident.StreetName));
            var streetTypeParam = (new SqlParameter("@STREET_TYPE", apOLPRRInsertIncident.StreetType));
            var siteAddressParam = (new SqlParameter("@SITE_ADDRESS", apOLPRRInsertIncident.SiteAddress));
            var siteCityParam = (new SqlParameter("@SITE_CITY", apOLPRRInsertIncident.SiteCity));
            var siteZipcodeParam = (new SqlParameter("@SITE_ZIPCODE", apOLPRRInsertIncident.SiteZipcode));
            var sitePhoneParam = (new SqlParameter("@SITE_PHONE", apOLPRRInsertIncident.SitePhone));
            var initialCommentParam = (new SqlParameter("@INITIAL_COMMENT", apOLPRRInsertIncident.InitialComment));
            var discoveryDateParam = (new SqlParameter("@DISCOVERY_DATE", apOLPRRInsertIncident.DiscoveryDate));
            var confirmationCodeParam = (new SqlParameter("@CONFIRMATION_CODE", apOLPRRInsertIncident.ConfirmationCode));
            var discoveryCodeParam = (new SqlParameter("@DISCOVERY_CODE", apOLPRRInsertIncident.DiscoveryCode));
            var causeCodeParam = (new SqlParameter("@CAUSE_CODE", apOLPRRInsertIncident.CauseCode));
            var sourceIdParam = (new SqlParameter("@SOURCEID", apOLPRRInsertIncident.SourceId));
            var rpFistNameParam = (new SqlParameter("@RP_FIRSTNAME", apOLPRRInsertIncident.RpFirstName));
            var rpLastNameParam = (new SqlParameter("@RP_LASTNAME", apOLPRRInsertIncident.RpLastName));
            var rpOrganizationParam = (new SqlParameter("@RP_ORGANIZATION", apOLPRRInsertIncident.RpOrganization));
            var rpAddressParam = (new SqlParameter("@RP_ADDRESS", apOLPRRInsertIncident.RpAddress));
            var rpAddress2Param = (new SqlParameter("@RP_ADDRESS2", apOLPRRInsertIncident.RpAddress2));
            var rpCityParam = (new SqlParameter("@RP_CITY", apOLPRRInsertIncident.RpCity));
            var rpStateParam = (new SqlParameter("@RP_STATE", apOLPRRInsertIncident.RpState));
            var rpZipcodeParam = (new SqlParameter("@RP_ZIPCODE", apOLPRRInsertIncident.RpZipcode));
            var rpPhoneParam = (new SqlParameter("@RP_PHONE", apOLPRRInsertIncident.RpPhone));
            var rpEmailParam = (new SqlParameter("@RP_EMAIL", apOLPRRInsertIncident.RpEmail));
            var icFirstNameParam = (new SqlParameter("@IC_FIRSTNAME", apOLPRRInsertIncident.IcFirstName));
            var icLastNameParam = (new SqlParameter("@IC_LASTNAME", apOLPRRInsertIncident.IcLastName));
            var icOrganizationParam = (new SqlParameter("@IC_ORGANIZATION", apOLPRRInsertIncident.IcOrganization));
            var icAddressParam = (new SqlParameter("@IC_ADDRESS", apOLPRRInsertIncident.IcAddress));
            var icAddress2Param = (new SqlParameter("@IC_ADDRESS2", apOLPRRInsertIncident.IcAddress2));
            var icCityParam = (new SqlParameter("@IC_CITY", apOLPRRInsertIncident.IcCity));
            var icStateParam = (new SqlParameter("@IC_STATE", apOLPRRInsertIncident.IcState));
            var icZipcodeParam = (new SqlParameter("@IC_ZIPCODE", apOLPRRInsertIncident.IcZipcode));
            var icPhoneParam = (new SqlParameter("@IC_PHONE", apOLPRRInsertIncident.IcPhone));
            var icEmailParam = (new SqlParameter("@IC_EMAIL", apOLPRRInsertIncident.IcEmail));
            var groundWaterParam = (new SqlParameter("@GROUNDWATER", apOLPRRInsertIncident.GroundWater));
            var surfaceWaterParam = (new SqlParameter("@SURFACEWATER", apOLPRRInsertIncident.SurfaceWater));
            var drinkingWaterdParam = (new SqlParameter("@DRINKINGWATER", apOLPRRInsertIncident.DringkingWater));
            var soilParam = (new SqlParameter("@SOIL", apOLPRRInsertIncident.Soil));
            var vaporParam = (new SqlParameter("@VAPOR", apOLPRRInsertIncident.Vapor));
            var freeProductParam = (new SqlParameter("@FREEPRODUCT", apOLPRRInsertIncident.FreeProduct));
            var unleadedGasParam = (new SqlParameter("@UNLEADEDGAS", apOLPRRInsertIncident.UnleadedGas));
            var leadedGasParam = (new SqlParameter("@LEADEDGAS", apOLPRRInsertIncident.LeadedGas));
            var miscGasParam = (new SqlParameter("@MISCGAS", apOLPRRInsertIncident.MisGas));
            var dieselParam = (new SqlParameter("@DIESEL", apOLPRRInsertIncident.Diesel));
            var wasteOilParam = (new SqlParameter("@WASTEOIL", apOLPRRInsertIncident.WasteOil));
            var heatingOilParam = (new SqlParameter("@HEATINGOIL", apOLPRRInsertIncident.HeatingOil));
            var lubricantParam = (new SqlParameter("@LUBRICANT", apOLPRRInsertIncident.Lubricant));
            var solventParam = (new SqlParameter("@SOLVENT", apOLPRRInsertIncident.Solvent));
            var otherPetParam = (new SqlParameter("@OTHERPET", apOLPRRInsertIncident.OtherPet));
            var chemicalParam = (new SqlParameter("@CHEMICAL", apOLPRRInsertIncident.Chemical));
            var unknownParam = (new SqlParameter("@UNKNOWN", apOLPRRInsertIncident.Unknown));
            var mtbeParam = (new SqlParameter("@MTBE", apOLPRRInsertIncident.Mtbe));
            var submitDateTimeParam = (new SqlParameter("@SUBMIT_DATETIME", apOLPRRInsertIncident.DateReceived));
            var deqOfficedParam = (new SqlParameter("@DEQ_OFFICE", apOLPRRInsertIncident.DeqOffice));


            if (icFirstNameParam.Value == null) icFirstNameParam.Value = DBNull.Value;
            if (icLastNameParam.Value == null) icLastNameParam.Value = DBNull.Value;
            if (icAddressParam.Value == null) icAddressParam.Value = DBNull.Value;
            if (icAddress2Param.Value == null) icAddress2Param.Value = DBNull.Value;
            if (icCityParam.Value == null) icCityParam.Value = DBNull.Value;
            if (icStateParam.Value == null) icStateParam.Value = DBNull.Value;
            if (icZipcodeParam.Value == null) icZipcodeParam.Value = DBNull.Value;
            if (icPhoneParam.Value == null) icPhoneParam.Value = DBNull.Value;
            if (icEmailParam.Value == null) icEmailParam.Value = DBNull.Value;
            if (facilityIdParam.Value == null) facilityIdParam.Value = DBNull.Value;
            if (streetQuadParam.Value == null) streetQuadParam.Value = DBNull.Value;
            if (streetTypeParam.Value == null) streetTypeParam.Value = DBNull.Value;
            if (sitePhoneParam.Value == null) sitePhoneParam.Value = DBNull.Value;
            if (rpOrganizationParam.Value == null) rpOrganizationParam.Value = DBNull.Value;
            if (icOrganizationParam.Value == null) icOrganizationParam.Value = DBNull.Value;
            if (rpEmailParam.Value == null) rpEmailParam.Value = DBNull.Value;
            if (icEmailParam.Value == null) icEmailParam.Value = DBNull.Value;

            var result = await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.apOLPRRInsertIncident " +
            "  @ErrNum OUTPUT,@CONTRACTOR_UID, @CONTRACTOR_PWD, @REPORTED_BY, @REPORTED_BY_PHONE,  @REPORTED_BY_EMAIL, @RELEASE_TYPE, @DATE_RECEIVED, @FACILITY_ID" +
            ", @SITE_NAME,@SITE_COUNTY,@STREET_NBR, @STREET_QUAD,@STREET_NAME,@STREET_TYPE,@SITE_ADDRESS,@SITE_CITY,@SITE_ZIPCODE,@SITE_PHONE" +
            ", @INITIAL_COMMENT, @DISCOVERY_DATE, @CONFIRMATION_CODE,@DISCOVERY_CODE,@CAUSE_CODE,@SOURCEID" +
            " ,@RP_FIRSTNAME,@RP_LASTNAME,@RP_ORGANIZATION,@RP_ADDRESS,@RP_ADDRESS2,@RP_CITY,@RP_STATE,@RP_ZIPCODE,@RP_PHONE,@RP_EMAIL" +
            ", @IC_FIRSTNAME,@IC_LASTNAME,@IC_ORGANIZATION,@IC_ADDRESS,@IC_ADDRESS2,@IC_CITY,@IC_STATE,@IC_ZIPCODE,@IC_PHONE,@IC_EMAIL" +
            ", @GROUNDWATER,@SURFACEWATER,@DRINKINGWATER,@SOIL,@VAPOR,@FREEPRODUCT,@UNLEADEDGAS,@LEADEDGAS,@MISCGAS,@DIESEL,@WASTEOIL,@HEATINGOIL,@LUBRICANT,@SOLVENT" +
            ", @OTHERPET,@CHEMICAL,@UNKNOWN,@MTBE,@SUBMIT_DATETIME,@DEQ_OFFICE", 
            errNumParam, contractorUidParam, contractorPwdParam, reportedByParam, reportedByPhoneParam, reportedByEmailParam, releaseTypeParam, dateReceivedParam, facilityIdParam
            , siteNameParam, siteCountyParam, streetNbrParam, streetQuadParam, streetNameParam, streetTypeParam, siteAddressParam, siteCityParam, siteZipcodeParam, sitePhoneParam
            , initialCommentParam, discoveryDateParam, confirmationCodeParam, discoveryCodeParam, causeCodeParam, sourceIdParam
            , rpFistNameParam, rpLastNameParam, rpOrganizationParam, rpAddressParam, rpAddress2Param, rpCityParam, rpStateParam, rpZipcodeParam, rpPhoneParam, rpEmailParam
            ,icFirstNameParam, icLastNameParam, icOrganizationParam, icAddressParam, icAddress2Param, icCityParam, icStateParam, icZipcodeParam, icPhoneParam, icEmailParam
            ,groundWaterParam, surfaceWaterParam, drinkingWaterdParam, soilParam, vaporParam, freeProductParam, unleadedGasParam, leadedGasParam, miscGasParam, dieselParam, wasteOilParam, heatingOilParam, lubricantParam, solventParam
            ,otherPetParam, chemicalParam, unknownParam, mtbeParam, submitDateTimeParam, deqOfficedParam     
            );

            return result;
        }

        public async Task<IEnumerable<ApOlprrGetLustLookup>> GetApOLPRRGetLustLookup(LustSiteAddressSearch lustSiteAddressSearch)
        {

            var siteNameParam = new SqlParameter("@SiteName", lustSiteAddressSearch.SiteName);
            var siteAddressParam = new SqlParameter("@SiteAddress", lustSiteAddressSearch.SiteAddress);
            var siteCityParam = new SqlParameter("@SiteCity", lustSiteAddressSearch.SiteCity);
            var siteZipParam= new SqlParameter("@SiteZip", lustSiteAddressSearch.SiteZip);
            var orderByParam = new SqlParameter("@OrderBy", lustSiteAddressSearch.OrderBy);
            var resultOutParam = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            if (siteNameParam.Value == null)
                siteNameParam.Value = DBNull.Value;
            if (siteAddressParam.Value == null)
                siteAddressParam.Value = DBNull.Value;
            if (siteCityParam.Value == null)
                siteCityParam.Value = DBNull.Value;
            if (siteZipParam.Value == null)
                siteZipParam.Value = DBNull.Value;

            const string ExecuteApOLPRRGetLustLookup = "execute dbo.apOLPRRGetLustLookup @SiteName, @SiteAddress, @SiteCity" +
                ", @SiteZip, @OrderBy, @Result OUTPUT";

            var result = await _dbContext.Set<ApOlprrGetLustLookup>().AsNoTracking().FromSql(ExecuteApOLPRRGetLustLookup
                , siteNameParam, siteAddressParam, siteCityParam, siteZipParam, orderByParam, resultOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode == 0)
            {
                var json = JsonConvert.SerializeObject(lustSiteAddressSearch);
                var errorMsg = $"{ExecuteApOLPRRGetLustLookup} returned status code = {resultCode}. Post payload {json}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            } 

            return result;

            //https://stackoverflow.com/questions/18510901/return-multiple-recordsets-from-stored-proc-in-c-sharp
            //https://stackoverflow.com/questions/43688324/why-does-ef-core-always-return-1-with-this-stored-procedure
            //https://stackoverflow.com/questions/45252959/entity-framework-core-using-stored-procedure-with-output-parameters
        }

        public async Task<ApOlprrGetIncidentById> ApOlprrGetIncidentById(int olprrId)
        {
            var olprrIdParam = (new SqlParameter("@OlprrId", olprrId));
            var releaseTypeParam = (new SqlParameter { ParameterName = "@ReleaseType", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 1});
            var receiveDateParam = (new SqlParameter { ParameterName = "@ReceiveDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Output });
            var facilityIdParam = (new SqlParameter { ParameterName = "@FacilityId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
            var siteNameParam = (new SqlParameter { ParameterName = "@SiteName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40 });
            var siteCountyParam = (new SqlParameter { ParameterName = "@SiteCounty", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 2 });
            var siteAddressParam = (new SqlParameter { ParameterName = "@SiteAddress", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40});
            var otherAddressParam = (new SqlParameter { ParameterName = "@OtherAddress", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40 });
            var siteCityParam = (new SqlParameter { ParameterName = "@SiteCity", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 10 });
            var siteZipCodeParam = (new SqlParameter { ParameterName = "@SiteZipCode", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 10 });
            var sitePhoneParam = (new SqlParameter { ParameterName = "@SitePhone", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 25 });
            var siteCommentParam = (new SqlParameter { ParameterName = "@SiteComment", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 720 });
            var contractorIdParam = (new SqlParameter { ParameterName = "@ContractorId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
            var siteStatusParam = (new SqlParameter { ParameterName = "@SiteStatus", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 8 });
            var reportedByParam = (new SqlParameter { ParameterName = "@ReportedBy", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 50 });
            var reportedByPhoneParam = (new SqlParameter { ParameterName = "@ReportedByPhone", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 25 });
            var contractorNameParam = (new SqlParameter { ParameterName = "@ContractorName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 50 });
            var contractorEmailParam = (new SqlParameter { ParameterName = "@ContractorEmail", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 50 });
            var resultParam = (new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });

            await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.apOlprrGetIncidentById " +
                " @OlprrId, @ReleaseType OUTPUT, @ReceiveDate OUTPUT, @FacilityId OUTPUT, @SiteName OUTPUT,  @SiteCounty OUTPUT, @SiteAddress OUTPUT, @OtherAddress OUTPUT" +
                ", @SiteCity OUTPUT, @SiteZipCode OUTPUT, @SitePhone OUTPUT, @SiteComment OUTPUT,  @ContractorId OUTPUT" +
                ", @SiteStatus OUTPUT, @ReportedBy OUTPUT, @ReportedByPhone OUTPUT, @ContractorName OUTPUT, @ContractorEmail OUTPUT, @Result OUTPUT"
                , olprrIdParam, releaseTypeParam, receiveDateParam, facilityIdParam, siteNameParam, siteCountyParam, siteAddressParam, otherAddressParam
                , siteCityParam, siteZipCodeParam, sitePhoneParam, siteCommentParam, contractorIdParam
                , siteStatusParam, reportedByParam, reportedByPhoneParam, contractorNameParam, contractorEmailParam, resultParam);

            var resultCode = (Int32)(resultParam.Value);
            if (resultCode != 0)
            {
                var errorMsg = $"execute dbo.apOlprrGetIncidentById for olprrId {olprrId} returned status code = {resultCode}";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            //var apOlprrGetIncidentById = new ApOlprrGetIncidentById();
            //apOlprrGetIncidentById.OlprrId = olprrId;
            //apOlprrGetIncidentById.ReleaseType = (releaseTypeParam.Value == DBNull.Value) ? null : (string)releaseTypeParam.Value;
            //apOlprrGetIncidentById.DateReceived = (DateTime)receiveDateParam.Value;
            //apOlprrGetIncidentById.FacilityId = String.IsNullOrEmpty(facilityIdParam.Value.ToString())? 0: (int)facilityIdParam.Value;
            //apOlprrGetIncidentById.SiteName = (siteNameParam.Value == DBNull.Value) ? null : (string)siteNameParam.Value;
            //apOlprrGetIncidentById.SiteCounty = (siteCountyParam.Value == DBNull.Value) ? null : (string)siteCountyParam.Value;
            //apOlprrGetIncidentById.SiteAddress = (siteAddressParam.Value == DBNull.Value) ? null : (string)siteAddressParam.Value;
            //apOlprrGetIncidentById.OtherAddress = (otherAddressParam.Value == DBNull.Value) ? null : (string)otherAddressParam.Value;
            //apOlprrGetIncidentById.SiteCity = (siteCityParam.Value == DBNull.Value) ? null : (string)siteCityParam.Value;
            //apOlprrGetIncidentById.SiteZipcode = (siteZipCodeParam.Value == DBNull.Value) ? null : (string)siteZipCodeParam.Value;
            //apOlprrGetIncidentById.SitePhone = (sitePhoneParam.Value == DBNull.Value) ? null : (string)sitePhoneParam.Value;
            //apOlprrGetIncidentById.SiteComment = (siteCommentParam.Value == DBNull.Value) ? null : (string)siteCommentParam.Value;
            //apOlprrGetIncidentById.ContractorId = (int)contractorIdParam.Value;
            //apOlprrGetIncidentById.SiteStatus = (siteStatusParam.Value == DBNull.Value) ? null : (string)siteStatusParam.Value;
            //apOlprrGetIncidentById.ReportedBy = (reportedByParam.Value == DBNull.Value) ? null : (string)reportedByParam.Value;
            //apOlprrGetIncidentById.ReportedByPhone = (reportedByPhoneParam.Value == DBNull.Value) ? null : (string)reportedByPhoneParam.Value;
            //apOlprrGetIncidentById.ContractorName = (contractorNameParam.Value == DBNull.Value) ? null : (string)contractorNameParam.Value;
            //apOlprrGetIncidentById.ContractorEmail = (contractorEmailParam.Value == DBNull.Value) ? null : (string)contractorEmailParam.Value;
            //apOlprrGetIncidentById.Result = resultCode;
            //return apOlprrGetIncidentById;

            return new ApOlprrGetIncidentById
            {
                OlprrId = olprrId,
                ReleaseType = (releaseTypeParam.Value == DBNull.Value) ? null : (string)releaseTypeParam.Value,
                DateReceived = (DateTime)receiveDateParam.Value,
                FacilityId = String.IsNullOrEmpty(facilityIdParam.Value.ToString()) ? 0 : (int)facilityIdParam.Value,
                SiteName = (siteNameParam.Value == DBNull.Value) ? null : (string)siteNameParam.Value,
                SiteCounty = (siteCountyParam.Value == DBNull.Value) ? null : (string)siteCountyParam.Value,
                SiteAddress = (siteAddressParam.Value == DBNull.Value) ? null : (string)siteAddressParam.Value,
                OtherAddress = (otherAddressParam.Value == DBNull.Value) ? null : (string)otherAddressParam.Value,
                SiteCity = (siteCityParam.Value == DBNull.Value) ? null : (string)siteCityParam.Value,
                SiteZipcode = (siteZipCodeParam.Value == DBNull.Value) ? null : (string)siteZipCodeParam.Value,
                SitePhone = (sitePhoneParam.Value == DBNull.Value) ? null : (string)sitePhoneParam.Value,
                SiteComment = (siteCommentParam.Value == DBNull.Value) ? null : (string)siteCommentParam.Value,
                ContractorId = (int)contractorIdParam.Value,
                SiteStatus = (siteStatusParam.Value == DBNull.Value) ? null : (string)siteStatusParam.Value,
                ReportedBy = (reportedByParam.Value == DBNull.Value) ? null : (string)reportedByParam.Value,
                ReportedByPhone = (reportedByPhoneParam.Value == DBNull.Value) ? null : (string)reportedByPhoneParam.Value,
                ContractorName = (contractorNameParam.Value == DBNull.Value) ? null : (string)contractorNameParam.Value,
                ContractorEmail = (contractorEmailParam.Value == DBNull.Value) ? null : (string)contractorEmailParam.Value,
                Result = resultCode
            };
        }

        public async Task<IEnumerable<ApGetLustSearchDataStats>> ApGetLustSearchData(LustSearchFilter lustSearchFilter)
        {

            var logCountyParam = new SqlParameter("@LogCounty", lustSearchFilter.LogCounty);
            var logYearParam = new SqlParameter("@LogYear", lustSearchFilter.LogYear);
            var logSeqNbrParam = new SqlParameter("@LogSeqNbr", lustSearchFilter.LogSeqNbr);
            var facilityIdParam = new SqlParameter("@FacilityId", lustSearchFilter.FacilityId);
            var siteNameParam = new SqlParameter("@SiteName", lustSearchFilter.SiteName);
            var siteAddressParam = new SqlParameter("@SiteAddress", lustSearchFilter.SiteAddress);
            var siteCityParam = new SqlParameter("@SiteCity", lustSearchFilter.SiteCity);
            var siteZipParam = new SqlParameter("@SiteZipcode", lustSearchFilter.SiteZipcode);
            var regionCodeParam = new SqlParameter("@RegionCode", lustSearchFilter.RegionCode);
            var releaseSiteTypeCodeParam = new SqlParameter("@ReleaseSiteTypeCode", lustSearchFilter.ReleaseSiteTypeCode);
            var cleanUpSiteTypeIdParam = new SqlParameter("@CleanUpSiteTypeId", lustSearchFilter.CleanUpSiteTypeId);
            var fileStatusIdParam = new SqlParameter("@FileStatusId", lustSearchFilter.FileStatusId);
            var projectManagerParam = new SqlParameter("@ProjectManagerCode", lustSearchFilter.ProjectManagerCode);
            var contactFirstNameParam = new SqlParameter("@ContactFirstName", lustSearchFilter.ContactFirstName);
            var contactLastNameParam = new SqlParameter("@ContactLastName", lustSearchFilter.ContactLastName);
            var contactOrganizationParam = new SqlParameter("@ContactOrganization", lustSearchFilter.ContactOrganization);
            var tankStatusIdParam = new SqlParameter("@TankStatusId", lustSearchFilter.TankStatusId);
            var hotAuditRejectIndParam = new SqlParameter("@HotAuditRejectInd", lustSearchFilter.HotAuditRejectInd);
            var compareDate1IdParam = new SqlParameter("@CompareDate1Id", lustSearchFilter.CompareDate1Id);
            var compareDate2IdParam = new SqlParameter("@CompareDate2Id", lustSearchFilter.CompareDate2Id);
            var compareDate1IdFromDateParam = new SqlParameter("@CompareDate1IdFromDate", lustSearchFilter.CompareDate1IdFromDate);
            var compareDate1IdToDateParam = new SqlParameter("@CompareDate1IdToDate", lustSearchFilter.CompareDate1IdToDate);
            var compareDate2IdFromDateParam = new SqlParameter("@CompareDate2IdFromDate", lustSearchFilter.CompareDate2IdFromDate);
            var compareDate2IdToDateParam = new SqlParameter("@CompareDate2IdToDate", lustSearchFilter.CompareDate2IdToDate);
            var sortColParam = new SqlParameter("@SortColumn", lustSearchFilter.SortColumn);
            var sortOrderParam = new SqlParameter("@SortOrder", lustSearchFilter.SortOrder);
            var pageNumberParam = new SqlParameter("@PageNumber", lustSearchFilter.PageNumber);
            var rowsPerPageParam = new SqlParameter("@RowsPerPage", lustSearchFilter.RowsPerPage);
            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            if (logCountyParam.Value == null)           logCountyParam.Value = DBNull.Value;
            if (logYearParam.Value == null)             logYearParam.Value = DBNull.Value;
            if (logSeqNbrParam.Value == null)           logSeqNbrParam.Value = DBNull.Value;
            if (facilityIdParam.Value == null)          facilityIdParam.Value = DBNull.Value;
            if (siteNameParam.Value == null)            siteNameParam.Value = DBNull.Value;
            if (siteAddressParam.Value == null)         siteAddressParam.Value = DBNull.Value;
            if (siteCityParam.Value == null)            siteCityParam.Value = DBNull.Value;
            if (siteZipParam.Value == null)             siteZipParam.Value = DBNull.Value;
            if (regionCodeParam.Value == null)          regionCodeParam.Value = DBNull.Value;
            if (releaseSiteTypeCodeParam.Value == null) releaseSiteTypeCodeParam.Value = DBNull.Value;
            if (cleanUpSiteTypeIdParam.Value == null)   cleanUpSiteTypeIdParam.Value = DBNull.Value;
            if (fileStatusIdParam.Value == null)        fileStatusIdParam.Value = DBNull.Value;
            if (projectManagerParam.Value == null)      projectManagerParam.Value = DBNull.Value;
            if (contactFirstNameParam.Value == null)    contactFirstNameParam.Value = DBNull.Value;
            if (contactLastNameParam.Value == null)     contactLastNameParam.Value = DBNull.Value;
            if (contactOrganizationParam.Value == null) contactOrganizationParam.Value = DBNull.Value;
            if (tankStatusIdParam.Value == null)        tankStatusIdParam.Value = DBNull.Value;
            if (hotAuditRejectIndParam.Value == null)   hotAuditRejectIndParam.Value = DBNull.Value;
            if (compareDate1IdParam.Value == null)      compareDate1IdParam.Value = DBNull.Value;
            if (compareDate2IdParam.Value == null)      compareDate2IdParam.Value = DBNull.Value;
            if (compareDate1IdFromDateParam.Value == null)  compareDate1IdFromDateParam.Value = DBNull.Value;
            if (compareDate1IdToDateParam.Value == null)    compareDate1IdToDateParam.Value = DBNull.Value;
            if (compareDate2IdFromDateParam.Value == null)  compareDate2IdFromDateParam.Value = DBNull.Value;
            if (compareDate2IdToDateParam.Value == null)    compareDate2IdToDateParam.Value = DBNull.Value;
            if (sortColParam.Value == null)             sortColParam.Value = DBNull.Value;
            if (sortOrderParam.Value == null)           sortOrderParam.Value = DBNull.Value;
            if (pageNumberParam.Value == null)          pageNumberParam.Value = DBNull.Value;
            if (rowsPerPageParam.Value == null)         rowsPerPageParam.Value = DBNull.Value;


            var exeSp = "execute dbo.apGetLustSearchData  @LogCounty, @LogYear, @LogSeqNbr, @FacilityId, @SiteName, @SiteAddress, @SiteCity "
                + ", @SiteZipcode, @RegionCode, @ReleaseSiteTypeCode, @CleanUpSiteTypeId, @FileStatusId, @ProjectManagerCode, @ContactFirstName "
                + ", @ContactLastName, @ContactOrganization, @TankStatusId, @HotAuditRejectInd, @CompareDate1Id, @CompareDate2Id "
                + ", @CompareDate1IdFromDate, @CompareDate1IdToDate, @CompareDate2IdFromDate, @CompareDate2IdToDate "
                + " ,@SortColumn, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT, @RESULT OUTPUT ";


            var result = await _dbContext.Set<ApGetLustSearchData>().AsNoTracking().FromSql(exeSp, logCountyParam, logYearParam, logSeqNbrParam, facilityIdParam
                , siteNameParam, siteAddressParam, siteCityParam, siteZipParam, regionCodeParam, releaseSiteTypeCodeParam, cleanUpSiteTypeIdParam
                , fileStatusIdParam, projectManagerParam, contactFirstNameParam, contactLastNameParam, contactOrganizationParam, tankStatusIdParam
                , hotAuditRejectIndParam, compareDate1IdParam, compareDate2IdParam, compareDate1IdFromDateParam, compareDate1IdToDateParam
                , compareDate2IdFromDateParam, compareDate2IdToDateParam
                , sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode != 0)
            {
                var json = JsonConvert.SerializeObject(lustSearchFilter);
                var errorMsg = $"{exeSp} returned status code = {resultCode}. Post payload {json}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            var rList = new List<ApGetLustSearchDataStats>();
            foreach (var res in result)
            {
                rList.Add(
                    new ApGetLustSearchDataStats()
                    {
                        ReqPageNumber = lustSearchFilter.PageNumber,
                        ReqRowsPerPage = lustSearchFilter.RowsPerPage,
                        ReqSortColumn = lustSearchFilter.SortColumn,
                        ReqSortOrder = lustSearchFilter.SortOrder,
                        TotalPages = (Int16)(totalPagesOutParam.Value),
                        TotalRows = (Int16)(totalRowsOutParam.Value),
                        LustId = res.LustId,
                        LogNumber = res.LogNumber,
                        SiteName = res.SiteName,
                        SiteAddress = res.SiteAddress,
                        FirDt = res.FirDt,
                        ClosedDt = res.ClosedDt,
                        FacilityId = res.FacilityId,
                        SiteScore = res.SiteScore
                    }
                );
            }
            return rList;

        }

        public async Task<IEnumerable<ApOlprrGetUstLookupDataStats>> ApOlprrGetUstLookupData(UstSearchFilter ustSearchFilter)
        {
            var facilityNameParam = new SqlParameter("@FacilityName", ustSearchFilter.FacilityName);
            var facilityAddressParam = new SqlParameter("@FacilityAddress", ustSearchFilter.FacilityAddress);
            var facilityCityParam = new SqlParameter("@FacilityCity", ustSearchFilter.FacilityCity);
            var facilityZipParam = new SqlParameter("@FacilityZip", ustSearchFilter.FacilityZip);
            var sortColParam = new SqlParameter("@SortColumn", ustSearchFilter.SortColumn);
            var sortOrderParam = new SqlParameter("@SortOrder", ustSearchFilter.SortOrder);
            var pageNumberParam = new SqlParameter("@PageNumber", ustSearchFilter.PageNumber);
            var rowsPerPageParam = new SqlParameter("@RowsPerPage", ustSearchFilter.RowsPerPage);
            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            if (facilityNameParam.Value == null) facilityNameParam.Value = DBNull.Value;
            if (facilityAddressParam.Value == null) facilityAddressParam.Value = DBNull.Value;
            if (facilityCityParam.Value == null) facilityCityParam.Value = DBNull.Value;
            if (facilityZipParam.Value == null) facilityZipParam.Value = DBNull.Value;
            if (sortColParam.Value == null) sortColParam.Value = DBNull.Value;
            if (sortOrderParam.Value == null) sortOrderParam.Value = DBNull.Value;
            if (pageNumberParam.Value == null) pageNumberParam.Value = DBNull.Value;
            if (rowsPerPageParam.Value == null) rowsPerPageParam.Value = DBNull.Value;


            var exeSp = "execute dbo.apOLPRRGetUstLookupData  @FacilityName, @FacilityAddress, @FacilityCity, @FacilityZip "
                + " ,@SortColumn, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT, @RESULT OUTPUT ";


            var result = await _dbContext.Set<ApOlprrGetUstLookupData>().AsNoTracking().FromSql(exeSp, facilityNameParam, facilityAddressParam, facilityCityParam, facilityZipParam
                , sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode != 0)
            {
                var json = JsonConvert.SerializeObject(ustSearchFilter);
                var errorMsg = $"{exeSp} returned status code = {resultCode}. Post payload {json}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            var rList = new List<ApOlprrGetUstLookupDataStats>();
            foreach (var res in result)
            {
                rList.Add(
                    new ApOlprrGetUstLookupDataStats()
                    {
                        ReqPageNumber = ustSearchFilter.PageNumber,
                        ReqRowsPerPage = ustSearchFilter.RowsPerPage,
                        ReqSortColumn = ustSearchFilter.SortColumn,
                        ReqSortOrder = ustSearchFilter.SortOrder,
                        TotalPages = (Int16)(totalPagesOutParam.Value),
                        TotalRows = (Int16)(totalRowsOutParam.Value),
                        FacilityId = res.FacilityId,
                        FacilityName = res.FacilityName,
                        FacilityAddress = res.FacilityAddress,
                        FacilityCity = res.FacilityCity,
                        FacilityZip = res.FacilityZip,
                    }
                );
            }
            return rList;
        }

        public void ApRetrieveGeoLocId(string appId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApOLPRRGetContactByIdByContactType> ApOLPRRGetContactByIdByContactType(int olprrId, string contactType)
        {
            var olprrIdParam = (new SqlParameter("@OlprrId", olprrId));
            var contactTypeParam = (new SqlParameter("@ContactType", contactType));
            var firstNameParam = (new SqlParameter { ParameterName = "@FirstName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 30 });
            var lastNameParam = (new SqlParameter { ParameterName = "@LastName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 30 });
            var organizationParam = (new SqlParameter { ParameterName = "@Organization", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40 });
            var addressParam = (new SqlParameter { ParameterName = "@Address", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40 });
            var address2Param = (new SqlParameter { ParameterName = "@Address2", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40 });
            var cityParam = (new SqlParameter { ParameterName = "@City", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 25 });
            var stateParam = (new SqlParameter { ParameterName = "@State", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 2 });
            var zipCodeParam = (new SqlParameter { ParameterName = "@ZipCode", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 10 });
            var phoneParam = (new SqlParameter { ParameterName = "@Phone", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 25 });
            var emailAddressParam = (new SqlParameter { ParameterName = "@EmailAddress", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output, Size = 40 });
            var resultParam = (new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });

            await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.ApOLPRRGetContactByIdByContactType " +
                " @OlprrId, @ContactType, @FirstName OUTPUT, @LastName OUTPUT, @Organization OUTPUT, @Address OUTPUT,  @Address2 OUTPUT, @City OUTPUT, @State OUTPUT, @ZipCode OUTPUT" +
                ", @Phone OUTPUT, @EmailAddress OUTPUT, @RESULT OUTPUT "
                , olprrIdParam, contactTypeParam, firstNameParam, lastNameParam, organizationParam
                , addressParam, address2Param, cityParam, stateParam, zipCodeParam, phoneParam, emailAddressParam, resultParam);

            var resultCode = (Int32)(resultParam.Value);
            if (resultCode != 0)
            {
                var errorMsg = $"execute dbo.ApOLPRRGetContactByIdByContactType for olprrId {olprrId} contactType {contactType} returned status code = {resultCode}";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            return new ApOLPRRGetContactByIdByContactType
            {
                OlprrId = olprrId,
                ContactType = contactType,
                FirstName = (firstNameParam.Value == DBNull.Value) ? null : (string)firstNameParam.Value,
                LastName = (lastNameParam.Value == DBNull.Value) ? null : (string)lastNameParam.Value,
                Organization = (organizationParam.Value == DBNull.Value) ? null : (string)organizationParam.Value,
                Address = (addressParam.Value == DBNull.Value) ? null : (string)addressParam.Value,
                Address2 = (address2Param.Value == DBNull.Value) ? null : (string)address2Param.Value,
                City = (cityParam.Value == DBNull.Value) ? null : (string)cityParam.Value,
                State = (stateParam.Value == DBNull.Value) ? null : (string)stateParam.Value,
                Zipcode = (zipCodeParam.Value == DBNull.Value) ? null : (string)zipCodeParam.Value,
                Phone = (phoneParam.Value == DBNull.Value) ? null : (string)phoneParam.Value,
                EmailAddress = (emailAddressParam.Value == DBNull.Value) ? null : (string)emailAddressParam.Value,
                Result = resultCode
            };
        }

        //public async Task<IEnumerable<ApOlprrGetIncidents>> ApOlprrGetIncidents(string office, string status, string siteType, string olprrId)
        //{
        //    var sortColumn = 1;
        //    var sortOrder = 1;
        //    var pageNumber = 1;
        //    var rowsPerPage = 30;
        //    var statusParam = new SqlParameter("@OlprrStatus", status);
        //    var officeParam = new SqlParameter("@OlprrOffice", office);
        //    var siteTypeParam = new SqlParameter("@SiteType", siteType);
        //    var olprrIdParam = new SqlParameter("@OlprrId", olprrId);
        //    var sortColParam = new SqlParameter("@SortCol", sortColumn);
        //    var sortOrderParam = new SqlParameter("@SortOrder", sortOrder);
        //    var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
        //    var rowsPerPageParam = new SqlParameter("@RowsPerPage", rowsPerPage);

        //    var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
        //    var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
        //    var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

        //    if (statusParam.Value == null)
        //        statusParam.Value = DBNull.Value;
        //    if (officeParam.Value == null)
        //        officeParam.Value = DBNull.Value;
        //    if (siteTypeParam.Value == null)
        //        siteTypeParam.Value = DBNull.Value;
        //    if (olprrIdParam.Value == null)
        //        olprrIdParam.Value = DBNull.Value;

        //    var exeSp = "execute dbo.apOLPRRGetIncidents  @OlprrStatus, @OlprrOffice, @SiteType, @OlprrId, @SortCol, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT, @RESULT OUTPUT ";
        //    var result = await _dbContext.Set<ApOlprrGetIncidents>().AsNoTracking().FromSql(exeSp, statusParam, officeParam, siteTypeParam, olprrIdParam
        //        , sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();

        //    var resultCode = (Int16)(resultOutParam.Value);

        //    if (resultCode != 0)
        //    {
        //        var errorMsg = $"{exeSp} returned status code = {resultCode} for OlprrStatus {status}  OlprrOffice {office}.";
        //        _logger.LogError(errorMsg);
        //        throw new StoreProcedureNonZeroOutputParamException(errorMsg);
        //    }

        //    return result;
        //}

        public async Task<ApOlprrGetIncidentsWithStats> ApOlprrGetIncidentsWithStats(string office, string status, string siteType, string olprrId
            ,int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var statusParam = new SqlParameter("@OlprrStatus", status);
            var officeParam = new SqlParameter("@OlprrOffice", office);
            var siteTypeParam = new SqlParameter("@SiteType", siteType);
            var olprrIdParam = new SqlParameter("@OlprrId", olprrId);
            var sortColParam = new SqlParameter("@SortCol", sortColumn);
            var sortOrderParam = new SqlParameter("@SortOrder", sortOrder);
            var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
            var rowsPerPageParam = new SqlParameter("@RowsPerPage", rowsPerPage);

            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            if (statusParam.Value == null)
                statusParam.Value = DBNull.Value;
            if (officeParam.Value == null)
                officeParam.Value = DBNull.Value;
            if (siteTypeParam.Value == null)
                siteTypeParam.Value = DBNull.Value;
            if (olprrIdParam.Value == null)
                olprrIdParam.Value = DBNull.Value;

            var exeSp = "execute dbo.apOLPRRGetIncidents  @OlprrStatus, @OlprrOffice, @SiteType, @OlprrId, @SortCol, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT, @RESULT OUTPUT ";
            var result = await _dbContext.Set<ApOlprrGetIncidents>().AsNoTracking().FromSql(exeSp, statusParam, officeParam, siteTypeParam, olprrIdParam
                , sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode != 0)
            {
                var errorMsg = $"{exeSp} returned status code = {resultCode} for OlprrStatus {status}  OlprrOffice {office}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            var apOlprrGetIncidentsWithStats = new ApOlprrGetIncidentsWithStats();
            apOlprrGetIncidentsWithStats.DeqOffice = office;
            apOlprrGetIncidentsWithStats.IncidentStatus = status;
            apOlprrGetIncidentsWithStats.SiteType = siteType;
            apOlprrGetIncidentsWithStats.OlprrId = olprrId;
            apOlprrGetIncidentsWithStats.PageNumber = pageNumber;
            apOlprrGetIncidentsWithStats.RowsPerPage = rowsPerPage;
            apOlprrGetIncidentsWithStats.SortColumn = sortColumn;
            apOlprrGetIncidentsWithStats.SortOrder = sortOrder;
            apOlprrGetIncidentsWithStats.TotalPages = (Int16)(totalPagesOutParam.Value);
            apOlprrGetIncidentsWithStats.TotalRows = (Int16)(totalRowsOutParam.Value);
            apOlprrGetIncidentsWithStats.ApOlprrGetIncidents = result;

            return apOlprrGetIncidentsWithStats;
        }
        
        public async Task<IEnumerable<ApOlprrGetIncidents>> ApOlprrGetIncidents(string office, string status, string siteType, string olprrId
                                        , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var statusParam = new SqlParameter("@OlprrStatus", status);
            var officeParam = new SqlParameter("@OlprrOffice", office);
            var siteTypeParam = new SqlParameter("@SiteType", siteType);
            var olprrIdParam = new SqlParameter("@OlprrId", olprrId);
            var sortColParam = new SqlParameter("@SortCol", sortColumn);
            var sortOrderParam = new SqlParameter("@SortOrder", sortOrder);
            var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
            var rowsPerPageParam = new SqlParameter("@RowsPerPage", rowsPerPage);

            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            if (statusParam.Value == null)
                statusParam.Value = DBNull.Value;
            if (officeParam.Value == null)
                officeParam.Value = DBNull.Value;
            if (siteTypeParam.Value == null)
                siteTypeParam.Value = DBNull.Value;
            if (olprrIdParam.Value == null)
                olprrIdParam.Value = DBNull.Value;

            var exeSp = "execute dbo.apOLPRRGetIncidents  @OlprrStatus, @OlprrOffice, @SiteType, @OlprrId, @SortCol, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT, @RESULT OUTPUT ";
            var result = await _dbContext.Set<ApOlprrGetIncidents>().AsNoTracking().FromSql(exeSp, statusParam, officeParam, siteTypeParam, olprrIdParam
                , sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode != 0)
            {
                var errorMsg = $"{exeSp} returned status code = {resultCode} for OlprrStatus {status}  OlprrOffice {office}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            return result;
        }

        public async Task<IEnumerable<ApOlprrGetIncidentsStats>> ApOlprrGetIncidentsStats(string office, string status, string siteType, string olprrId
                                , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var statusParam = new SqlParameter("@OlprrStatus", status);
            var officeParam = new SqlParameter("@OlprrOffice", office);
            var siteTypeParam = new SqlParameter("@SiteType", siteType);
            var olprrIdParam = new SqlParameter("@OlprrId", olprrId);
            var sortColParam = new SqlParameter("@SortCol", sortColumn);
            var sortOrderParam = new SqlParameter("@SortOrder", sortOrder);
            var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
            var rowsPerPageParam = new SqlParameter("@RowsPerPage", rowsPerPage);

            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            if (statusParam.Value == null)
                statusParam.Value = DBNull.Value;
            if (officeParam.Value == null)
                officeParam.Value = DBNull.Value;
            if (siteTypeParam.Value == null)
                siteTypeParam.Value = DBNull.Value;
            if (olprrIdParam.Value == null)
                olprrIdParam.Value = DBNull.Value;

            var exeSp = "execute dbo.apOLPRRGetIncidents  @OlprrStatus, @OlprrOffice, @SiteType, @OlprrId, @SortCol, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT, @RESULT OUTPUT ";
            var result = await _dbContext.Set<ApOlprrGetIncidents>().AsNoTracking().FromSql(exeSp, statusParam, officeParam, siteTypeParam, olprrIdParam
                , sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode != 0)
            {
                var errorMsg = $"{exeSp} returned status code = {resultCode} for OlprrStatus {status}  OlprrOffice {office}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            var apOlprrGetIncidentsStats = new List<ApOlprrGetIncidentsStats>();
            foreach (var res in result)
            {
                apOlprrGetIncidentsStats.Add(
                    new ApOlprrGetIncidentsStats()
                    {
                        ReqDeqOffice = office,
                        ReqIncidentStatus = status,
                        ReqSiteType = siteType,
                        ReqOlprrId = olprrId,
                        ReqPageNumber = pageNumber,
                        ReqRowsPerPage = rowsPerPage,
                        ReqSortColumn = sortColumn,
                        ReqSortOrder = sortOrder,
                        TotalPages = (Int16)(totalPagesOutParam.Value),
                        TotalRows = (Int16)(totalRowsOutParam.Value),
                        OlprrId = res.OlprrId,
                        ReleaseType = res.ReleaseType,
                        ReleaseTypeName = res.ReleaseTypeName,
                        ReceiveDate = res.ReceiveDate,
                        FacilityId = res.FacilityId,
                        SiteName = res.SiteName,
                        SiteCounty = res.SiteCounty,
                        SiteAddress = res.SiteAddress,
                        OtherAddress = res.OtherAddress,
                        SiteCity = res.SiteCity,
                        SiteZipcode = res.SiteZipcode,
                        SitePhone = res.SitePhone,
                        SiteComment = res.SiteComment,
                        ContractorId = res.ContractorId,
                        SiteStatus = res.SiteStatus,
                        ReportedBy = res.ReportedBy,
                        ReportedByPhone = res.ReportedByPhone,
                        CompanyName = res.CompanyName,
                        EmailAddress = res.EmailAddress,
                        CountyName = res.CountyName
                    }
                );
            }
            return apOlprrGetIncidentsStats;
        }

        public async Task<IEnumerable<ApOlprrGetIncidentDataById>> ApOlprrGetIncidentDataById(int olprrId)
        {
            var olprrIdParam = (new SqlParameter("@OlprrId", olprrId));
            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var exeSp = "execute dbo.apOLPRRGetIncidentDataByID  @OlprrId, @RESULT OUTPUT ";
            var result =  await _dbContext.Set<ApOlprrGetIncidentDataById>().AsNoTracking().FromSql(exeSp, olprrIdParam, resultOutParam).ToListAsync();

            var resultCode = (Int16)(resultOutParam.Value);

            if (resultCode != 0)
            {
                var errorMsg = $"{exeSp} returned status code = {resultCode} for OlprrId {olprrId}.";
                _logger.LogError(errorMsg);
                throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            } 
            if (result.Count == 0)
            {
                throw new ResourceNotFoundException($"Resource requested - OlprrId {olprrId} not found.");
            }
            return result;

        }

        public async Task<ApOlprrCheckPostalCounty> ApOlprrCheckPostalCounty(int reportedCountyCode, string usPostalCountyCodeFips)
        {
            var reportedCountyCodeParam = (new SqlParameter("@UICountyCode", reportedCountyCode));
            var usPostalCountyCodeFipsCodeParam = (new SqlParameter("@ZP4FIPSCounty", usPostalCountyCodeFips));
            var countyCodeParam = new SqlParameter { ParameterName = "@IncidentCounty", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var countyNameParam = new SqlParameter { ParameterName = "@CountyName", SqlDbType = SqlDbType.VarChar, Size=10, Direction = ParameterDirection.Output };
            var resultOutParam = new SqlParameter { ParameterName = "@ErrorValue", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };

            var exeSp = "execute dbo.apOLPRRCheckPostalCountyData  @UICountyCode, @ZP4FIPSCounty, @IncidentCounty OUTPUT, @CountyName OUTPUT, @ErrorValue OUTPUT ";
            var result = await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, reportedCountyCodeParam, usPostalCountyCodeFipsCodeParam, countyCodeParam, countyNameParam, resultOutParam);

            var resultCode = (Int16)(resultOutParam.Value);
            var countyCode = 0;
            if (countyCodeParam.Value == DBNull.Value)
                countyCode = 0;
            else
                countyCode = (Int16)countyCodeParam.Value;
            if (resultCode == 0 && result < 0)
                resultCode = (Int16) result;

            if (resultCode != 0 || result != 0)
            {
                var errorMsg = $"{exeSp} returned @ErrorValue = {resultCode} Result = {result} for reportedCountyCode {reportedCountyCode} usPostalCountyCodeFips {usPostalCountyCodeFips}";
                _logger.LogError(errorMsg);
                //throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }

            return new ApOlprrCheckPostalCounty()
            {
                ReportedCountyCode = reportedCountyCode,
                UsPostalCountyCodeFips = usPostalCountyCodeFips,
                CountyCode = countyCode,
                CountyName = (countyNameParam.Value == DBNull.Value) ? null : (string)countyNameParam.Value,
                ErrorCode = resultCode
            };
        }

        public async Task<OlprrReviewIncidentResult> ApCreateIncidentData (OlprrReviewIncident olprrReviewIncident)
        {
            var lustIdInParam = new SqlParameter("@LustIdIN", olprrReviewIncident.LustIdIn);
            var facilityIdParam = new SqlParameter("@FacilityId", olprrReviewIncident.FacilityId);
            var countyIdParam = new SqlParameter("@CountyId", olprrReviewIncident.CountyId);
            var receivedDateParam = new SqlParameter("@ReceivedDate", olprrReviewIncident.DateReceived);
            var siteNameParam = new SqlParameter("@SiteName", olprrReviewIncident.SiteName);
            var siteAddressParam = new SqlParameter("@SiteAddress", olprrReviewIncident.SiteAddress);
            var siteCityParam = new SqlParameter("@SiteCity", olprrReviewIncident.SiteCity);
            var siteZipParam = new SqlParameter("@SiteZip", olprrReviewIncident.SiteZipcode);
            var sitePhoneParam = new SqlParameter("@SitePhone", olprrReviewIncident.SitePhone);
            var noValidAddressParam = new SqlParameter("@NoValidAddress", olprrReviewIncident.NoValidAddress);
            var regTankIndParam = new SqlParameter("@RegTankInd", olprrReviewIncident.RegTankInd);
            var hotIndParam = new SqlParameter("@HotInd", olprrReviewIncident.HotInd);
            var nonRegTankIndParam = new SqlParameter("@NonRegTankInd", olprrReviewIncident.NonRegTankInd);
            var siteCommentParam = new SqlParameter("@SiteComment", olprrReviewIncident.InitialComment);
            var olprrIdParam = new SqlParameter("@OlprrId", olprrReviewIncident.OlprrId);
            var errorMessageParam = new SqlParameter { ParameterName = "@ErrorMessage", SqlDbType = SqlDbType.VarChar, Size = 1024, Direction = ParameterDirection.Output };
            var logNumberTempParam = new SqlParameter { ParameterName = "@LogNumberTemp", SqlDbType = SqlDbType.VarChar, Size = 10, Direction = ParameterDirection.Output };
            var lustIdTempParam = new SqlParameter { ParameterName = "@LustIdTemp", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var discoverDateParam = new SqlParameter("@DiscoverDate", olprrReviewIncident.DiscoveryDate);
            var confirmationIdParam = new SqlParameter("@ConfirmationCode", olprrReviewIncident.ConfirmationCode);
            var discoveryIdParam = new SqlParameter("@DiscoveryCode", olprrReviewIncident.DiscoveryCode);
            var releaseCauseIdParam = new SqlParameter("@ReleaseCauseCode", olprrReviewIncident.CauseCode);
            var releaseSourceIdParam = new SqlParameter("@ReleaseSourceId", olprrReviewIncident.SourceId);
            var soilParam = new SqlParameter("@SLMediaInd", olprrReviewIncident.Soil);
            var groundWaterParam = new SqlParameter("@GWMediaInd", olprrReviewIncident.GroundWater);
            var surfaceWaterParam = new SqlParameter("@SWMediaInd", olprrReviewIncident.SurfaceWater);
            var drinkingWaterParam = new SqlParameter("@DWMediaInd", olprrReviewIncident.DringkingWater);
            var vaporParam = new SqlParameter("@FVMediaInd", olprrReviewIncident.Vapor);
            var freeProductParam = new SqlParameter("@FPMediaInd", olprrReviewIncident.FreeProduct);
            var unleadedGasParam = new SqlParameter("@UGContamInd", olprrReviewIncident.UnleadedGas);
            var leadedGasParam = new SqlParameter("@LGContamInd", olprrReviewIncident.LeadedGas);
            var misGasParam = new SqlParameter("@MGContamInd", olprrReviewIncident.MisGas);
            var dieselParam = new SqlParameter("@DSContamInd", olprrReviewIncident.Diesel);
            var wasteOilParam = new SqlParameter("@WOContamInd", olprrReviewIncident.WasteOil);
            var lubricantParam = new SqlParameter("@LBContamInd", olprrReviewIncident.Lubricant);
            var solventParam = new SqlParameter("@SVContamInd", olprrReviewIncident.Solvent);
            var otherPetParam = new SqlParameter("@OPContamInd", olprrReviewIncident.OtherPet);
            var chemicalParam = new SqlParameter("@CHContamInd", olprrReviewIncident.Chemical);
            var unknownParam = new SqlParameter("@UNContamInd", olprrReviewIncident.Unknown);
            var mtbeParam = new SqlParameter("@MTBEContamInd", olprrReviewIncident.Mtbe);
            var heatingOilParam = new SqlParameter("@HOContamInd", olprrReviewIncident.HeatingOil);
            var rpOrganizationParam = new SqlParameter("@RPOrganization", olprrReviewIncident.RpOrganization);
            var rpFirstNameParam = new SqlParameter("@RPFirstName", olprrReviewIncident.RpFirstName);
            var rpLastNameParam = new SqlParameter("@RPLastName", olprrReviewIncident.RpLastName);
            var rpPhoneParam = new SqlParameter("@RPPhone", olprrReviewIncident.RpPhone);
            var rpEmailParam = new SqlParameter("@RPEmail", olprrReviewIncident.RpEmail);
            var rpStreetParam = new SqlParameter("@RPStreet", olprrReviewIncident.RpAddress);
            var rpCityParam = new SqlParameter("@RPCity", olprrReviewIncident.RpCity);
            var rpZipParam = new SqlParameter("@RPZIP", olprrReviewIncident.RpZipcode);
            var rpStateParam = new SqlParameter("@RPState", olprrReviewIncident.RpState);
            var rpCountryParam = new SqlParameter("@RPCountry", olprrReviewIncident.RpCountry);
            var rpAffilCommentsParam = new SqlParameter("@RPAffilComments", olprrReviewIncident.RpAffilComments);
            var icOrganizationParam = new SqlParameter("@ICOrganization", olprrReviewIncident.IcOrganization);
            var icFirstNameParam = new SqlParameter("@ICFirstName", olprrReviewIncident.IcFirstName);
            var icLastNameParam = new SqlParameter("@ICLastName", olprrReviewIncident.IcLastName);
            var icPhoneParam = new SqlParameter("@ICPhone", olprrReviewIncident.IcPhone);
            var icEmailParam = new SqlParameter("@ICEmail", olprrReviewIncident.IcEmail);
            var icStreetParam = new SqlParameter("@ICStreet", olprrReviewIncident.IcAddress);
            var icCityParam = new SqlParameter("@ICCity", olprrReviewIncident.IcCity);
            var icZipParam = new SqlParameter("@ICZIP", olprrReviewIncident.IcZipcode);
            var icStateParam = new SqlParameter("@ICState", olprrReviewIncident.IcState);
            var icCountryParam = new SqlParameter("@ICCountry", olprrReviewIncident.IcCountry);
            var icAffilCommentsParam = new SqlParameter("@ICAffilComments", olprrReviewIncident.IcAffilComments);
            var appIdParam = new SqlParameter("@AppID", olprrReviewIncident.AppId);
            var newSiteStatusParam = new SqlParameter("@NewSiteStatus", olprrReviewIncident.NewSiteStatus);

            icOrganizationParam.Value = icOrganizationParam.Value ?? DBNull.Value;
            icFirstNameParam.Value = icFirstNameParam.Value ?? DBNull.Value;
            icLastNameParam.Value = icLastNameParam.Value ?? DBNull.Value;
            icPhoneParam.Value = icPhoneParam.Value ?? DBNull.Value;
            icEmailParam.Value = icEmailParam.Value ?? DBNull.Value;
            icStreetParam.Value = icStreetParam.Value ?? DBNull.Value;
            icCityParam.Value = icCityParam.Value ?? DBNull.Value;
            icZipParam.Value = icZipParam.Value ?? DBNull.Value;
            icStateParam.Value = icStateParam.Value ?? DBNull.Value;
            icCountryParam.Value = icCountryParam.Value ?? DBNull.Value;
            icAffilCommentsParam.Value = icAffilCommentsParam.Value ?? DBNull.Value;
            appIdParam.Value = appIdParam.Value ?? DBNull.Value;
            rpAffilCommentsParam.Value = rpAffilCommentsParam.Value ?? DBNull.Value;
            rpCountryParam.Value = rpCountryParam.Value ?? DBNull.Value;
            rpPhoneParam.Value = rpPhoneParam.Value ?? DBNull.Value;
            rpEmailParam.Value = rpEmailParam.Value ?? DBNull.Value;

            var exeSp = "execute dbo.apCreateIncidentData " +
            "  @LustIdIN, @FacilityId, @CountyId,@ReceivedDate,@SiteName,@SiteAddress,@SiteCity,@SiteZip,@SitePhone,@NoValidAddress,@RegTankInd,@HotInd,@NonRegTankInd " +
            "  ,@SiteComment,@OlprrId,@ErrorMessage OUTPUT ,@LogNumberTemp  OUTPUT ,@LustIdTemp OUTPUT  ,@DiscoverDate,@ConfirmationCode,@DiscoveryCode,@ReleaseCauseCode,@ReleaseSourceId " +
            "  ,@SLMediaInd, @GWMediaInd, @SWMediaInd, @DWMediaInd, @FVMediaInd, @FPMediaInd ,@UGContamInd , @LGContamInd, @MGContamInd, @DSContamInd, @WOContamInd " +
            "  ,@LBContamInd, @OPContamInd , @SVContamInd, @CHContamInd, @UNContamInd, @MTBEContamInd, @HOContamInd " +
            "  , @RPOrganization, @RPFirstName, @RPLastName, @RPPhone, @RPEmail, @RPStreet, @RPCity, @RPZIP, @RPState, @RPCountry, @RPAffilComments  " +
            "  , @ICOrganization, @ICFirstName , @ICLastName, @ICPhone , @ICEmail, @ICStreet, @ICCity, @ICZIP, @ICState, @ICCountry, @ICAffilComments  " +
            "  , @AppID, @NewSiteStatus ";

            var result = await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, lustIdInParam, facilityIdParam, countyIdParam
                , receivedDateParam, siteNameParam, siteAddressParam, siteCityParam, siteZipParam, sitePhoneParam, noValidAddressParam, regTankIndParam, hotIndParam, nonRegTankIndParam
                , siteCommentParam, olprrIdParam, errorMessageParam, logNumberTempParam, lustIdTempParam, discoverDateParam, confirmationIdParam, discoveryIdParam, releaseCauseIdParam, releaseSourceIdParam
                , soilParam, groundWaterParam, surfaceWaterParam, drinkingWaterParam, vaporParam, freeProductParam, unleadedGasParam, leadedGasParam, misGasParam, dieselParam, wasteOilParam
                , lubricantParam, otherPetParam, solventParam, chemicalParam, unknownParam, mtbeParam, heatingOilParam
                , rpOrganizationParam, rpFirstNameParam, rpLastNameParam, rpPhoneParam, rpEmailParam, rpStreetParam, rpCityParam, rpZipParam, rpStateParam, rpCountryParam, rpAffilCommentsParam
                , icOrganizationParam, icFirstNameParam, icLastNameParam, icPhoneParam, icEmailParam, icStreetParam, icCityParam, icZipParam, icStateParam, icCountryParam, icAffilCommentsParam
                , appIdParam, newSiteStatusParam);
            if ((errorMessageParam.Value != DBNull.Value) && (((string) errorMessageParam.Value).Length > 0))
            {
                var errorMsg = $"{exeSp} returned @ErrorMessage = {errorMessageParam.Value} Result = {result} for olprrId {olprrReviewIncident.OlprrId} site name {olprrReviewIncident.SiteName}";
                _logger.LogError(errorMsg);
                //throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }
            return new OlprrReviewIncidentResult
            {
                OlprrId = olprrReviewIncident.OlprrId,
                ErrorMessage = (errorMessageParam.Value == DBNull.Value) ? null : (string)errorMessageParam.Value,
                LogNumberTemp = (logNumberTempParam.Value == DBNull.Value) ? null : (string)logNumberTempParam.Value,
                LustIdTemp = (lustIdTempParam.Value == DBNull.Value) ? 0 : (Int32) lustIdTempParam.Value,
            };
        }

        public async Task<IEnumerable<ApGetSiteAliasByLustId2>> ApGetSiteAliasByLustId(int lustId)
        {
            var lustIdParam = new SqlParameter("@LustId", lustId);
            if (lustIdParam.Value == null)
                lustIdParam.Value = DBNull.Value;
            var exeSp = "execute dbo.ApGetSiteAliasByLustId  @LustId ";
            var results =  await _dbContext.Set<ApGetSiteAliasByLustId>().AsNoTracking().FromSql(exeSp,lustIdParam).ToListAsync();
            var resultList = new List<ApGetSiteAliasByLustId2>();
            foreach (var result in results)
            {
                resultList.Add(new ApGetSiteAliasByLustId2
                {
                    LustId = lustId,
                    SiteNameAlias = result.SiteNameAlias,
                    LastChangeBy = result.LastChangeBy,
                    LastChangeDate = result.LastChangeDate,
                    SiteNameAliasId = result.SiteNameAliasId
                });
            }
            return resultList;
        }

        public async Task<int> ApInsUpdSiteAlias(ApInsUpdSiteAlias apInsUpdSiteAlias)
        {
            var lustIdParam = new SqlParameter("@LustId", apInsUpdSiteAlias.LustId);
            var lastChangeByParam = new SqlParameter("@LastChangeBy", apInsUpdSiteAlias.LastChangeBy);
            var siteNameAliasParam = new SqlParameter("@SiteNameAlias", apInsUpdSiteAlias.SiteNameAlias);
            var siteNameAliasIdInParam = new SqlParameter("@SiteNameAliasIdIn", apInsUpdSiteAlias.SiteNameAliasIdIn);
            var siteNameAliasIdOutParam = new SqlParameter { ParameterName = "@SiteNameAliasIdOut", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var exeSp = "execute dbo.apInsUpdSiteAliasData @SiteNameAliasIdIn, @SiteNameAliasIdOut OUTPUT, @LustId, @SiteNameAlias, @LastChangeBy ";
            var result = await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, siteNameAliasIdInParam, siteNameAliasIdOutParam, lustIdParam, siteNameAliasParam, lastChangeByParam);

            return (Int32)(siteNameAliasIdOutParam.Value);
        }

        public async Task ApDltSiteNameAlias(int siteNameAliasId)
        {
            var siteNameAliasIdParam = new SqlParameter("@SiteNameAliasId", siteNameAliasId);
            var bitParam = new SqlParameter { ParameterName = "@Bit", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var exeSp = "execute dbo.apDltSiteNameAlias @SiteNameAliasId, @Bit OUTPUT ";
            await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, siteNameAliasIdParam, bitParam);
        }
    }
}

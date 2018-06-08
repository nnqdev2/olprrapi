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



        public async Task<int> InsertOLPRRIncidentRecord(ApOlprrInsertIncident apOLPRRInsertIncident)
        {
            var result = await _dbContext.Database.ExecuteSqlCommandAsync("execute dbo.apOLPRRInsertIncident " +
            "  @ErrNum ,@CONTRACTOR_UID, @CONTRACTOR_PWD, @REPORTED_BY, @REPORTED_BY_PHONE,  @REPORTED_BY_EMAIL, @RELEASE_TYPE, @DATE_RECEIVED,@FACILITY_ID, @SITE_NAME,@SITE_COUNTY" +
            ", @STREET_NBR, @STREET_QUAD,@STREET_NAME,@STREET_TYPE,@SITE_ADDRESS,@SITE_CITY,@SITE_ZIPCODE,@SITE_PHONE, @INITIAL_COMMENT, @DISCOVERY_DATE, @CONFIRMATION_CODE" +
            ", @DISCOVERY_CODE,@CAUSE_CODE,@SOURCEID,@RP_FIRSTNAME,@RP_LASTNAME,@RP_ORGANIZATION,@RP_ADDRESS,@RP_ADDRESS2,@RP_CITY,@RP_STATE,@RP_ZIPCODE,@RP_PHONE,@RP_EMAIL" +
            ", @IC_FIRSTNAME,@IC_LASTNAME,@IC_ORGANIZATION,@IC_ADDRESS,@IC_ADDRESS2,@IC_CITY,@IC_STATE,@IC_ZIPCODE,@IC_PHONE,@IC_EMAIL" +
            ", @GROUNDWATER,@SURFACEWATER,@DRINKINGWATER,@SOIL,@VAPOR,@FREEPRODUCT,@UNLEADEDGAS,@LEADEDGAS,@MISGAS,@DIESEL,@WASTEOIL,@HEATINGOIL,@LUBRICANT,@SOLVENT" +
            ", @OTHERPET,@CHEMICAL,@UNKNOWN,@MTBE,@SUBMIT_DATETIME,@DEQ_OFFICE", BuildSqlParams(apOLPRRInsertIncident));
            return result;
        }

        private IEnumerable<SqlParameter> BuildSqlParams(ApOlprrInsertIncident apOLPRRInsertIncident)
        {
            IList<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter { ParameterName = "@ErrNum", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            list.Add(new SqlParameter("@CONTRACTOR_UID", apOLPRRInsertIncident.ContractorUid));
            list.Add(new SqlParameter("@CONTRACTOR_PWD", apOLPRRInsertIncident.ContractorPwd));
            list.Add(new SqlParameter("@REPORTED_BY", apOLPRRInsertIncident.ReportedBy));
            list.Add(new SqlParameter("@REPORTED_BY_PHONE", apOLPRRInsertIncident.ReportedByPhone));
            list.Add(new SqlParameter("@REPORTED_BY_EMAIL", apOLPRRInsertIncident.ReportedByEmail));
            list.Add(new SqlParameter("@RELEASE_TYPE", apOLPRRInsertIncident.ReleaseType));
            list.Add(new SqlParameter("@DATE_RECEIVED", apOLPRRInsertIncident.DateReceived));
            list.Add(new SqlParameter("@FACILITY_ID", apOLPRRInsertIncident.FacilityId));
            list.Add(new SqlParameter("@SITE_NAME", apOLPRRInsertIncident.SiteName));
            list.Add(new SqlParameter("@SITE_COUNTY", apOLPRRInsertIncident.SiteCounty));
            list.Add(new SqlParameter("@STREET_NBR", apOLPRRInsertIncident.StreetNbr));
            list.Add(new SqlParameter("@STREET_QUAD", apOLPRRInsertIncident.StreetQuad));
            list.Add(new SqlParameter("@STREET_NAME", apOLPRRInsertIncident.StreetName));
            list.Add(new SqlParameter("@STREET_TYPE", apOLPRRInsertIncident.StreetType));
            list.Add(new SqlParameter("@SITE_ADDRESS", apOLPRRInsertIncident.SiteAddress));
            list.Add(new SqlParameter("@SITE_CITY", apOLPRRInsertIncident.SiteCity));
            list.Add(new SqlParameter("@SITE_ZIPCODE", apOLPRRInsertIncident.SiteZipcode));
            list.Add(new SqlParameter("@SITE_PHONE", apOLPRRInsertIncident.SitePhone));
            list.Add(new SqlParameter("@INITIAL_COMMENT", apOLPRRInsertIncident.InitialComment));
            list.Add(new SqlParameter("@DISCOVERY_DATE", apOLPRRInsertIncident.DiscoveryDate));
            list.Add(new SqlParameter("@CONFIRMATION_CODE", apOLPRRInsertIncident.ConfirmationCode));
            list.Add(new SqlParameter("@DISCOVERY_CODE", apOLPRRInsertIncident.DiscoveryCode));
            list.Add(new SqlParameter("@CAUSE_CODE", apOLPRRInsertIncident.CauseCode));
            list.Add(new SqlParameter("@SOURCEID", apOLPRRInsertIncident.SourceId));
            list.Add(new SqlParameter("@RP_FIRSTNAME", apOLPRRInsertIncident.RpFirstName));
            list.Add(new SqlParameter("@RP_LASTNAME", apOLPRRInsertIncident.RpLastName));
            list.Add(new SqlParameter("@RP_ORGANIZATION", apOLPRRInsertIncident.RpOrganization));
            list.Add(new SqlParameter("@RP_ADDRESS", apOLPRRInsertIncident.RpAddress));
            list.Add(new SqlParameter("@RP_ADDRESS2", apOLPRRInsertIncident.RpAddress2));
            list.Add(new SqlParameter("@RP_CITY", apOLPRRInsertIncident.RpCity));
            list.Add(new SqlParameter("@RP_STATE", apOLPRRInsertIncident.RpState));
            list.Add(new SqlParameter("@RP_ZIPCODE", apOLPRRInsertIncident.RpZipcode));
            list.Add(new SqlParameter("@RP_PHONE", apOLPRRInsertIncident.RpPhone));
            list.Add(new SqlParameter("@RP_EMAIL", apOLPRRInsertIncident.RpEmail));
            list.Add(new SqlParameter("@IC_FIRSTNAME", apOLPRRInsertIncident.IcFirstName));
            list.Add(new SqlParameter("@IC_LASTNAME", apOLPRRInsertIncident.IcLastName));
            list.Add(new SqlParameter("@IC_ORGANIZATION", apOLPRRInsertIncident.IcOrganization));
            list.Add(new SqlParameter("@IC_ADDRESS", apOLPRRInsertIncident.IcAddress));
            list.Add(new SqlParameter("@IC_ADDRESS2", apOLPRRInsertIncident.IcAddress2));
            list.Add(new SqlParameter("@IC_CITY", apOLPRRInsertIncident.IcCity));
            list.Add(new SqlParameter("@IC_STATE", apOLPRRInsertIncident.IcState));
            list.Add(new SqlParameter("@IC_ZIPCODE", apOLPRRInsertIncident.IcZipcode));
            list.Add(new SqlParameter("@IC_PHONE", apOLPRRInsertIncident.IcPhone));
            list.Add(new SqlParameter("@IC_EMAIL", apOLPRRInsertIncident.IcEmail));
            list.Add(new SqlParameter("@GROUNDWATER", apOLPRRInsertIncident.GroundWater));
            list.Add(new SqlParameter("@SURFACEWATER", apOLPRRInsertIncident.SurfaceWater));
            list.Add(new SqlParameter("@DRINKINGWATER", apOLPRRInsertIncident.DringkingWater));
            list.Add(new SqlParameter("@SOIL", apOLPRRInsertIncident.Soil));
            list.Add(new SqlParameter("@VAPOR", apOLPRRInsertIncident.Vapor));
            list.Add(new SqlParameter("@FREEPRODUCT", apOLPRRInsertIncident.FreeProduct));
            list.Add(new SqlParameter("@UNLEADEDGAS", apOLPRRInsertIncident.UnleadedGas));
            list.Add(new SqlParameter("@LEADEDGAS", apOLPRRInsertIncident.LeadedGas));
            list.Add(new SqlParameter("@MISGAS", apOLPRRInsertIncident.MisGas));
            list.Add(new SqlParameter("@DIESEL", apOLPRRInsertIncident.Diesel));
            list.Add(new SqlParameter("@WASTEOIL", apOLPRRInsertIncident.WasteOil));
            list.Add(new SqlParameter("@HEATINGOIL", apOLPRRInsertIncident.HeatingOil));
            list.Add(new SqlParameter("@LUBRICANT", apOLPRRInsertIncident.Lubricant));
            list.Add(new SqlParameter("@SOLVENT", apOLPRRInsertIncident.Solvent));
            list.Add(new SqlParameter("@OTHERPET", apOLPRRInsertIncident.OtherPet));
            list.Add(new SqlParameter("@CHEMICAL", apOLPRRInsertIncident.Chemical));
            list.Add(new SqlParameter("@UNKNOWN", apOLPRRInsertIncident.Unknown));
            list.Add(new SqlParameter("@MTBE", apOLPRRInsertIncident.Mtbe));
            list.Add(new SqlParameter("@SUBMIT_DATETIME", apOLPRRInsertIncident.SubmitDateTime));
            list.Add(new SqlParameter("@DEQ_OFFICE", apOLPRRInsertIncident.DeqOffice));
            IEnumerable<SqlParameter> myParams = list;
            return myParams;
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

        //private IEnumerable<SqlParameter> BuildSqlParams(int olprrId)
        //{
        //    IList<SqlParameter> list = new List<SqlParameter>();
        //    list.Add(new SqlParameter("@OlprrId", olprrId));
        //    list.Add(new SqlParameter { ParameterName = "@ReleaseType", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@ReceiveDate", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@FacilityId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@SiteName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@SiteCounty", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@SiteAddress", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@OtherAddress", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@SiteCity", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@SiteZipCode", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output});
        //    list.Add(new SqlParameter { ParameterName = "@SitePhone", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@SiteComment", SqlDbType = SqlDbType.DateTime, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@ContractorId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@SiteStatus", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@ReportedBy", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@ReportedByPhone", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@ContractorName", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@ContractorEmail", SqlDbType = SqlDbType.VarChar, Direction = ParameterDirection.Output });
        //    list.Add(new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output });
        //    IEnumerable<SqlParameter> myParams = list;
        //    return myParams;
        //}

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

        public async Task<IEnumerable<ApGetLustSearch>> ApGetLustSearch(string sqlInjectionString)
        {
            sqlInjectionString = "where INC.RegulatedTankInd = 1";

            var whereParam = new SqlParameter("@Where", sqlInjectionString);

            const string ExecuteApGetLustSearch = "execute dbo.apGetLustSearch @Where ";

            return  await _dbContext.Set<ApGetLustSearch>().AsNoTracking().FromSql(ExecuteApGetLustSearch, whereParam).ToListAsync();
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
    }
}

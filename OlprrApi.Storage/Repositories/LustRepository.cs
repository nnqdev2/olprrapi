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
    public class LustRepository : ILustRepository
    {
        private LustDbContext _dbContext;
        private ILogger<OlprrRepository> _logger;
        public LustRepository(ILogger<OlprrRepository> logger, LustDbContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<ApGetSiteAliasByLustId2>> ApGetSiteAliasByLustId(int lustId)
        {
            var lustIdParam = new SqlParameter("@LustId", lustId);
            if (lustIdParam.Value == null)
                lustIdParam.Value = DBNull.Value;
            var exeSp = "execute dbo.ApGetSiteAliasByLustIdData  @LustId ";
            var results = await _dbContext.Set<ApGetSiteAliasByLustId2>().AsNoTracking().FromSql(exeSp, lustIdParam).ToListAsync();
            var resultList = new List<ApGetSiteAliasByLustId2>();
            foreach (var result in results)
            {
                resultList.Add(new ApGetSiteAliasByLustId2
                {
                    LustId = lustId,
                    SiteNameAlias = result.SiteNameAlias,
                    LastChangeBy = result.LastChangeBy,
                    LastChangeDate = result.LastChangeDate,
                    SiteNameAliasId = result.SiteNameAliasId,
                    LogNumber = result.LogNumber
                });
            }
            return resultList;
        }

        public async Task<ApGetSiteAliasByLustId2> ApGetSiteAliasBySiteNameAliasIdData(int siteNameAliasId)
        {
            var siteNameAliasIdParam = new SqlParameter("@SiteNameAliasId", siteNameAliasId);
            if (siteNameAliasIdParam.Value == null)
                siteNameAliasIdParam.Value = DBNull.Value;
            var exeSp = "execute dbo.ApGetSiteAliasBySiteNameAliasIdData  @SiteNameAliasId ";
            var results = await _dbContext.Set<ApGetSiteAliasByLustId2>().AsNoTracking().FromSql(exeSp, siteNameAliasIdParam).ToListAsync();
            return results[0];
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
        public async Task<IEnumerable<ContactsStats>> ApGetPartyByFirstLastOrgName(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            var fNameParam = new SqlParameter("@FirstName", fname);
            var lNameParam = new SqlParameter("@LastName", lname);
            var orgParam = new SqlParameter("@PartyOrg", org);
            var sortColParam = new SqlParameter("@SortCol", sortColumn);
            var sortOrderParam = new SqlParameter("@SortOrder", sortOrder);
            var pageNumberParam = new SqlParameter("@PageNumber", pageNumber);
            var rowsPerPageParam = new SqlParameter("@RowsPerPage", rowsPerPage);
            var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var totalRowsOutParam = new SqlParameter { ParameterName = "@TotalRows", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var totalPagesOutParam = new SqlParameter { ParameterName = "@TotalPages", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            if (fNameParam.Value == null) fNameParam.Value = DBNull.Value;
            if (lNameParam.Value == null) lNameParam.Value = DBNull.Value;
            if (orgParam.Value == null) orgParam.Value = DBNull.Value;
            var exeSp = "execute dbo.apGetPartyByFirstLastOrgNameData  @FirstName, @LastName, @PartyOrg, @SortCol, @SortOrder, @PageNumber, @RowsPerPage, @TotalRows OUTPUT, @TotalPages OUTPUT ";
            var result = await _dbContext.Set<Contact>().AsNoTracking().FromSql(exeSp, fNameParam, lNameParam, orgParam, sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();
            //var result = await _dbContext.Set<Contact>().AsNoTracking().FromSql(exeSp, fNameParam, lNameParam, orgParam, sortColParam, sortOrderParam, pageNumberParam, rowsPerPageParam, resultOutParam, totalRowsOutParam, totalPagesOutParam).ToListAsync();
            //var resultCode = (Int16)(resultOutParam.Value);
            //if (resultCode != 0)
            //{
            //    var errorMsg = $"{exeSp} returned status code = {resultCode} for Contact Search filters: FirstName {fname}  LastName {lname} Org {org}.";
            //    _logger.LogError(errorMsg);
            //    throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            //}
            var contactsStats = new List<ContactsStats>();
            foreach (var res in result)
            {
                contactsStats.Add(
                    new ContactsStats()
                    {
                        ReqFirstName = fname,
                        ReqLastName = lname,
                        ReqOrganization = org,
                        ReqPageNumber = pageNumber,
                        ReqRowsPerPage = rowsPerPage,
                        ReqSortColumn = sortColumn,
                        ReqSortOrder = sortOrder,
                        TotalPages = (Int32)(totalPagesOutParam.Value),
                        TotalRows = (Int32)(totalRowsOutParam.Value),
                        PartyId = res.PartyId,
                        Organization = res.Organization,
                        FirstName = res.FirstName,
                        LastName = res.LastName,
                        PersonName = res.PersonName,
                        Phone = res.Phone,
                        Street = res.Street,
                        City = res.City,
                        State = res.State,
                        Zipcode = res.Zipcode,
                        Address = res.Address,
                        Country = res.Country,
                        Email = res.Email
                    }
                );
            }
            return contactsStats;
        }

        public async Task<ApGetCountyIdAndNameFromZP4Fips> ApGetCountyIdAndNameFromZP4Fips(int usPostalCountyCodeFips)
        {
            var usPostalCountyCodeFipsCodeParam = (new SqlParameter("@ZP4FIPSCounty", usPostalCountyCodeFips));
            var countyCodeParam = new SqlParameter { ParameterName = "@IncidentCounty", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            var countyNameParam = new SqlParameter { ParameterName = "@CountyName", SqlDbType = SqlDbType.VarChar, Size = 10, Direction = ParameterDirection.Output };
            var exeSp = "execute dbo.apGetCountyIdAndNameFromZP4Fips  @ZP4FIPSCounty, @IncidentCounty OUTPUT, @CountyName OUTPUT";
            var result = await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, usPostalCountyCodeFipsCodeParam, countyCodeParam, countyNameParam);

            int countyCode;
            if (countyCodeParam.Value == DBNull.Value)
                countyCode = 0;
            else
                countyCode = (Int16)countyCodeParam.Value;
            return new ApGetCountyIdAndNameFromZP4Fips()
            {
                UsPostalCountyCodeFips = usPostalCountyCodeFips,
                CountyCode = countyCode,
                CountyName = (countyNameParam.Value == DBNull.Value) ? null : (string)countyNameParam.Value
            };
        }

        public async Task<IEnumerable<LustIncident>> ApGetIncidentByIdData (int lustId)
        {
            var lustIdParam = (new SqlParameter("@LustId", lustId));
            //var resultOutParam = new SqlParameter { ParameterName = "@RESULT", SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output };
            //var exeSp = "execute dbo.apGetIncidentByIdData  @lustId, @RESULT OUTPUT ";
            //var result = await _dbContext.Set<LustIncident>().AsNoTracking().FromSql(exeSp, lustIdParam, resultOutParam).ToListAsync();
            var exeSp = "execute dbo.apGetIncidentByIdData  @lustId ";
            var result = await _dbContext.Set<LustIncident>().AsNoTracking().FromSql(exeSp, lustIdParam).ToListAsync();

            //var resultCode = (Int16)(resultOutParam.Value);
            //if (resultCode != 0)
            //{
            //    var errorMsg = $"{exeSp} returned status code = {resultCode} for LustId {lustId}.";
            //    _logger.LogError(errorMsg);
            //    throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            //}
            if (result.Count == 0)
            {
                throw new ResourceNotFoundException($"Resource requested - LustId {lustId} not found.");
            }
            return result; 
        }


        public async Task<IEnumerable<ProjectManagerIncident>> ApGetCurrentProjMgr(int lustId)
        {
            var lustIdParam = (new SqlParameter("@LustId", lustId));
            var exeSp = "execute dbo.apGetCurrentProjMgr  @lustId ";
            return await _dbContext.Set<ProjectManagerIncident>().AsNoTracking().FromSql(exeSp, lustIdParam).ToListAsync();
        }

        public async Task<ApInsUpdIncidentDataResult> ApInsUpdIncidentData(ApInsUpdIncidentData apInsUpdIncidentData)
        {
            var lustIdInParam = new SqlParameter("@LustIdIN", apInsUpdIncidentData.LustIdIn);
            var facilityIdParam = new SqlParameter("@FacilityId", apInsUpdIncidentData.FacilityId);
            var countyIdParam = new SqlParameter("@CountyId", apInsUpdIncidentData.CountyId);
            var receivedDateParam = new SqlParameter("@ReceivedDate", apInsUpdIncidentData.DateReceived);
            var siteNameParam = new SqlParameter("@SiteName", apInsUpdIncidentData.SiteName);
            var siteAddressParam = new SqlParameter("@SiteAddress", apInsUpdIncidentData.SiteAddress);
            var siteCityParam = new SqlParameter("@SiteCity", apInsUpdIncidentData.SiteCity);
            var siteZipParam = new SqlParameter("@SiteZip", apInsUpdIncidentData.SiteZipcode);
            var sitePhoneParam = new SqlParameter("@SitePhone", apInsUpdIncidentData.SitePhone);
            var noValidAddressParam = new SqlParameter("@NoValidAddress", apInsUpdIncidentData.NoValidAddress);
            var siteTypeIdParam = new SqlParameter("@SiteTypeId", apInsUpdIncidentData.SiteTypeId);
            var fileStatusIdParam = new SqlParameter("@FileStatusId", apInsUpdIncidentData.FileStatusId);
            var regTankIndParam = new SqlParameter("@RegTankInd", apInsUpdIncidentData.RegTankInd);
            var hotIndParam = new SqlParameter("@HotInd", apInsUpdIncidentData.HotInd);
            var nonRegTankIndParam = new SqlParameter("@NonRegTankInd", apInsUpdIncidentData.NonRegTankInd);
            var brownfieldCodeIdParam = new SqlParameter("@BrownfieldCodeId", apInsUpdIncidentData.BrownfieldCodeId);
            var propertyTranPendingIndParam = new SqlParameter("@PropertyTranPendingInd", apInsUpdIncidentData.PropertyTranPendingInd);
            var programTransferIndParam = new SqlParameter("@ProgramTransferInd", apInsUpdIncidentData.ProgramTransferInd);
            var hotAuditRejectIndParam = new SqlParameter("@HotAuditRejectInd", apInsUpdIncidentData.HotAuditRejectInd);
            var activeReleaseIndParam = new SqlParameter("@ActiveReleaseInd", apInsUpdIncidentData.ActiveReleaseInd);
            var optionLetterSentIndParam = new SqlParameter("@OptionLetterSentInd", apInsUpdIncidentData.OptionLetterSentInd);
            var siteCommentParam = new SqlParameter("@SiteComment", apInsUpdIncidentData.SiteComment);
            var seeAlsoCommentParam = new SqlParameter("@SeeAlsoComment", apInsUpdIncidentData.SeeAlsoComment);
            var publicSummaryCommentParam = new SqlParameter("@PublicSummaryComment", apInsUpdIncidentData.PublicSummaryComment);
            var geoLocIdParam = new SqlParameter("@GeolocId", apInsUpdIncidentData.GeoLocId);
            var olprrIdParam = new SqlParameter("@OlprrId", apInsUpdIncidentData.OlprrId);
            var discoverDateParam = new SqlParameter("@DiscoverDate", apInsUpdIncidentData.DiscoveryDate);
            var managementIdInParam = new SqlParameter("@ManagementIdIn", apInsUpdIncidentData.ManagementIdIn);
            var cleanupStartDtParam = new SqlParameter("@CleanupStartDt", apInsUpdIncidentData.CleanupStartDt);
            var releaseStopDtParam = new SqlParameter("@ReleaseStopDt", apInsUpdIncidentData.ReleaseStopDt);
            var closedDtParam = new SqlParameter("@ClosedDt", apInsUpdIncidentData.ClosedDt);
            var finalInvcRqstDtParam = new SqlParameter("@FinalInvcRqstDt", apInsUpdIncidentData.ReleaseStopDt);
            var letterOfAgreementDtParam = new SqlParameter("@LetterOfAgreementDt", apInsUpdIncidentData.LetterOfAgreementDt);
            var letterOfAgreementCommentParam = new SqlParameter("@LetterOfAgreementComment", apInsUpdIncidentData.LetterOfAgreementComment);



            var logNumberOutParam = new SqlParameter{ ParameterName = "@LogNumberOUT", SqlDbType = SqlDbType.VarChar, Size = 10, Direction = ParameterDirection.Output };
            var lustIdOutParam = new SqlParameter { ParameterName = "@LustIdOUT", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var errorMessageHandlerParam = new SqlParameter { ParameterName = "@ErrorMessageHandler", SqlDbType = SqlDbType.VarChar, Size = 1024, Direction = ParameterDirection.Output };
            var resultSpParam = new SqlParameter { ParameterName = "@ResultSP", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            if (seeAlsoCommentParam.Value == null) seeAlsoCommentParam.Value = DBNull.Value;
            if (siteCommentParam.Value == null) siteCommentParam.Value = DBNull.Value;
            if (publicSummaryCommentParam.Value == null) publicSummaryCommentParam.Value = DBNull.Value;
            if (olprrIdParam.Value == null) olprrIdParam.Value = DBNull.Value;
            if (facilityIdParam.Value == null) facilityIdParam.Value = DBNull.Value;
            if (publicSummaryCommentParam.Value == null) publicSummaryCommentParam.Value = DBNull.Value;
            if (geoLocIdParam.Value == null) geoLocIdParam.Value = DBNull.Value;
            if (brownfieldCodeIdParam.Value == null) brownfieldCodeIdParam.Value = DBNull.Value;
            if (fileStatusIdParam.Value == null) fileStatusIdParam.Value = DBNull.Value;
            if (siteTypeIdParam.Value == null) siteTypeIdParam.Value = DBNull.Value;
            if (cleanupStartDtParam.Value == null) cleanupStartDtParam.Value = DBNull.Value;
            if (releaseStopDtParam.Value == null) releaseStopDtParam.Value = DBNull.Value;
            if (finalInvcRqstDtParam.Value == null) finalInvcRqstDtParam.Value = DBNull.Value;
            if (closedDtParam.Value == null) closedDtParam.Value = DBNull.Value;
            if (letterOfAgreementDtParam.Value == null) letterOfAgreementDtParam.Value = DBNull.Value;
            if (letterOfAgreementCommentParam.Value == null) letterOfAgreementCommentParam.Value = DBNull.Value;
            if (discoverDateParam.Value == null) discoverDateParam.Value = DBNull.Value;

            var exeSp = "execute dbo.apUpdIncidentData " +
            "  @LustIdIN, @FacilityId, @CountyId,@ReceivedDate,@SiteName,@SiteAddress,@SiteCity,@SiteZip,@SitePhone,@NoValidAddress" +
            "  ,@SiteTypeId,@FileStatusId,@RegTankInd,@HotInd,@NonRegTankInd,@BrownfieldCodeId,@PropertyTranPendingInd,@ProgramTransferInd,@HotAuditRejectInd " +
            "  ,@ActiveReleaseInd,@OptionLetterSentInd,@SiteComment,@SeeAlsoComment,@PublicSummaryComment,@GeolocId,@OlprrId,@DiscoverDate" +
            "  ,@ManagementIdIn,@CleanupStartDt,@ReleaseStopDt,@FinalInvcRqstDt,@ClosedDt,@LetterOfAgreementDt,@LetterOfAgreementComment" +
            "  ,@LogNumberOUT OUTPUT ,@LustIdOUT  OUTPUT ,@ErrorMessageHandler OUTPUT ,@ResultSP OUT";

            var result = await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, lustIdInParam, facilityIdParam, countyIdParam
                , receivedDateParam, siteNameParam, siteAddressParam, siteCityParam, siteZipParam, sitePhoneParam, noValidAddressParam
                , siteTypeIdParam, fileStatusIdParam, regTankIndParam, hotIndParam, nonRegTankIndParam
                , brownfieldCodeIdParam, propertyTranPendingIndParam, programTransferIndParam, hotAuditRejectIndParam, activeReleaseIndParam
                , optionLetterSentIndParam, siteCommentParam, seeAlsoCommentParam, publicSummaryCommentParam, geoLocIdParam, olprrIdParam, discoverDateParam
                , managementIdInParam, cleanupStartDtParam, releaseStopDtParam, finalInvcRqstDtParam, closedDtParam, letterOfAgreementDtParam, letterOfAgreementCommentParam
                , logNumberOutParam, lustIdOutParam, errorMessageHandlerParam, resultSpParam);

            if ((errorMessageHandlerParam.Value != DBNull.Value) && (((string)errorMessageHandlerParam.Value).Length > 0))
            {
                var errorMsg = $"{exeSp} returned @ErrorMessage = {errorMessageHandlerParam.Value} Result = {result} for lustId {apInsUpdIncidentData.LustIdIn} site name {apInsUpdIncidentData.SiteName}";
                _logger.LogError(errorMsg);
                //throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }
            return new ApInsUpdIncidentDataResult
            {
                LustIdIn = apInsUpdIncidentData.LustIdIn,
                ErrorMessageHandler = (errorMessageHandlerParam.Value == DBNull.Value) ? null : (string)errorMessageHandlerParam.Value,
                LogNumberOut = (logNumberOutParam.Value == DBNull.Value) ? null : (string)logNumberOutParam.Value,
                LustIdOut = (lustIdOutParam.Value == DBNull.Value) ? 0 : (Int32)lustIdOutParam.Value,
                OlprrId = (olprrIdParam.Value == DBNull.Value) ? 0 : (Int32)olprrIdParam.Value,
                ResultSp = (resultSpParam.Value == DBNull.Value) ? 0 : (Int32)resultSpParam.Value,
            };
        }

        public async Task<ApGetLogNumber> ApGetLogNumber(int lustId)
        {
            var lustIdParam = new SqlParameter("@LustId", lustId);
            if (lustIdParam.Value == null)
                lustIdParam.Value = DBNull.Value;
            var exeSp = "execute dbo.ApGetLogNumber  @LustId ";
            var results = await _dbContext.Set<ApGetLogNumber>().AsNoTracking().FromSql(exeSp, lustIdParam).ToListAsync();
            if (results.Count > 0)
            {
                return results[0];
            } else
            {
                throw new ResourceNotFoundException($"Resource requested - LustId {lustId} not found.");
            }
        }

        public async Task<ApGetAffilById> ApGetAffilById(int affilId)
        {
            var affilIdParam = new SqlParameter("@AffilId", affilId);
            if (affilIdParam.Value == null)
                affilIdParam.Value = DBNull.Value;
            var exeSp = "execute dbo.apGetAffilByIdData  @AffilId ";
            var results = await _dbContext.Set<ApGetAffilById>().AsNoTracking().FromSql(exeSp, affilIdParam).ToListAsync();
            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                throw new ResourceNotFoundException($"Resource requested - AffilId {affilId} not found.");
            }
        }

        public async Task<ApInsUpdLustAffilPartyDataResult> ApInsUpdLustAffilPartyData(ApInsUpdLustAffilPartyData apInsUpdLustAffilPartyData)
        {
            var lustIdInParam = new SqlParameter("@LUSTID", apInsUpdLustAffilPartyData.LustId);
            var affilTypeParam = new SqlParameter("@AffilType", apInsUpdLustAffilPartyData.AffilType);
            var startDtParam = new SqlParameter("@StartDate", apInsUpdLustAffilPartyData.StartDt);
            var endDtParam = new SqlParameter("@EndDate", apInsUpdLustAffilPartyData.EndDt);
            var organizationParam = new SqlParameter("@Organization", apInsUpdLustAffilPartyData.Organization);
            var subOrgParam = new SqlParameter("@SubOrg", apInsUpdLustAffilPartyData.SubOrg);
            var jobTitleParam = new SqlParameter("@JobTitle", apInsUpdLustAffilPartyData.Jobtitle);
            var firstNameParam = new SqlParameter("@FirstName", apInsUpdLustAffilPartyData.FirstName);
            var lastNameParam = new SqlParameter("@LastName", apInsUpdLustAffilPartyData.LastName);
            var phoneParam = new SqlParameter("@Phone", apInsUpdLustAffilPartyData.Phone);
            var emailParam = new SqlParameter("@Email", apInsUpdLustAffilPartyData.Email);
            var streetParam = new SqlParameter("@Street", apInsUpdLustAffilPartyData.Street);
            var cityParam = new SqlParameter("@City", apInsUpdLustAffilPartyData.City);
            var zipParam = new SqlParameter("@ZIP", apInsUpdLustAffilPartyData.Zip);
            var stateParam = new SqlParameter("@State", apInsUpdLustAffilPartyData.State);
            var countryParam = new SqlParameter("@Country", apInsUpdLustAffilPartyData.Country);
            var affilCommentsParam = new SqlParameter("@AffilComments", apInsUpdLustAffilPartyData.AffilComments);
            var affilIdParam = new SqlParameter("@AffilId", apInsUpdLustAffilPartyData.AffilId);

            var partyIdOutParam = new SqlParameter { ParameterName = "@PartyId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var affilIdOutParam = new SqlParameter { ParameterName = "@AffiliationID", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
            var errorMsgOutParam = new SqlParameter { ParameterName = "@ErrMsg", SqlDbType = SqlDbType.VarChar, Size = 100, Direction = ParameterDirection.Output };
            var resultOutParam = new SqlParameter { ParameterName = "@Result", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

            if (subOrgParam.Value == null) subOrgParam.Value = DBNull.Value;
            if (affilCommentsParam.Value == null) affilCommentsParam.Value = DBNull.Value;
            if (affilTypeParam.Value == null) affilTypeParam.Value = DBNull.Value;
            if (startDtParam.Value == null) startDtParam.Value = DBNull.Value;
            if (endDtParam.Value == null) endDtParam.Value = DBNull.Value;
            if (organizationParam.Value == null) organizationParam.Value = DBNull.Value;
            if (jobTitleParam.Value == null) jobTitleParam.Value = DBNull.Value;
            if (firstNameParam.Value == null) firstNameParam.Value = DBNull.Value;
            if (lastNameParam.Value == null) lastNameParam.Value = DBNull.Value;
            if (phoneParam.Value == null) phoneParam.Value = DBNull.Value;
            if (emailParam.Value == null) emailParam.Value = DBNull.Value;
            if (streetParam.Value == null) streetParam.Value = DBNull.Value;
            if (cityParam.Value == null) cityParam.Value = DBNull.Value;
            if (zipParam.Value == null) zipParam.Value = DBNull.Value;
            if (stateParam.Value == null) stateParam.Value = DBNull.Value;
            if (countryParam.Value == null) countryParam.Value = DBNull.Value;
            if (affilCommentsParam.Value == null) affilCommentsParam.Value = DBNull.Value;
            if (affilIdParam.Value == null) affilIdParam.Value = DBNull.Value;

            var exeSp = "execute dbo.apInsUpdLUSTAffilPartyData " +
            "  @LUSTID, @AffilType,@StartDate,@EndDate,@Organization,@SubOrg,@JobTitle,@FirstName,@LastName,@Phone" +
            "  ,@Email,@Street,@City,@ZIP,@State,@Country,@AffilComments,@AffilID " +
            "  ,@PartyID OUTPUT ,@AffiliationID  OUTPUT ,@ErrMsg OUTPUT ,@Result OUT";

            var result = await _dbContext.Database.ExecuteSqlCommandAsync(exeSp, lustIdInParam, affilTypeParam, startDtParam
                , endDtParam, organizationParam, subOrgParam, jobTitleParam, firstNameParam, lastNameParam, phoneParam, emailParam
                , streetParam, cityParam, zipParam, stateParam, countryParam, affilCommentsParam, affilIdParam
                , partyIdOutParam, affilIdOutParam, errorMsgOutParam, resultOutParam);


            if ((errorMsgOutParam.Value != DBNull.Value) && (((string)errorMsgOutParam.Value).Length > 0))
            {
                var errorMsg = $"{exeSp} returned @ErrorMessage = {errorMsgOutParam.Value} Result = {result} for lustId {apInsUpdLustAffilPartyData.LustId} organization {apInsUpdLustAffilPartyData.Organization} name {apInsUpdLustAffilPartyData.FirstName} {apInsUpdLustAffilPartyData.LastName} ";
                _logger.LogError(errorMsg);
                //throw new StoreProcedureNonZeroOutputParamException(errorMsg);
            }
            return new ApInsUpdLustAffilPartyDataResult
            {
                LustId = apInsUpdLustAffilPartyData.LustId,
                AffilIdIn = apInsUpdLustAffilPartyData.AffilId,
                ErrMsg = (errorMsgOutParam.Value == DBNull.Value) ? null : (string)errorMsgOutParam.Value,
                PartyId = (Int32)partyIdOutParam.Value,
                AffilId = (Int32)affilIdOutParam.Value,
                Result = (Int32)resultOutParam.Value
            };
        }
    }
}

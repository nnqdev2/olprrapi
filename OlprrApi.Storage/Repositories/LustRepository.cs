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
            var exeSp = "execute dbo.ApGetSiteAliasByLustId  @LustId ";
            var results = await _dbContext.Set<ApGetSiteAliasByLustId>().AsNoTracking().FromSql(exeSp, lustIdParam).ToListAsync();
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
    }
}

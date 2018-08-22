﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OlprrApi.Storage.Entities;

namespace OlprrApi.Storage.Repositories
{
    public interface ILustRepository
    {
        Task<IEnumerable<ApGetSiteAliasByLustId2>> ApGetSiteAliasByLustId(int lustId);
        Task<int> ApInsUpdSiteAlias(ApInsUpdSiteAlias apInsUpdSiteAlias);
        Task ApDltSiteNameAlias(int siteNameAliasId);
        Task<IEnumerable<ContactsStats>> ApGetPartyByFirstLastOrgName(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);
    }
}
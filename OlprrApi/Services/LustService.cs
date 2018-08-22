﻿using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using OlprrApi.Storage.Repositories;
using RequestDto = OlprrApi.Models.Request;
using ResponseDto = OlprrApi.Models.Response;
using EntityDto = OlprrApi.Storage.Entities;
using System.Text;

namespace OlprrApi.Services
{
    public class LustService : ILustService
    {
        private ILogger<LustService> _logger;
        private ILustRepository _lustRepository;
        private readonly IMapper _mapper;
        public LustService(ILogger<LustService> logger, ILustRepository lustRepository, IMapper mapper)
        {
            _logger = logger;
            _lustRepository = lustRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseDto.ApGetSiteAliasByLustId2>> GetSiteAlias(int lustId)
        {
            var resultList = new List<ResponseDto.ApGetSiteAliasByLustId2>();
            foreach (var result in await _lustRepository.ApGetSiteAliasByLustId(lustId))
            {
                resultList.Add(_mapper.Map<EntityDto.ApGetSiteAliasByLustId2, ResponseDto.ApGetSiteAliasByLustId2>(result));
            }
            return resultList;
        }
        public async Task<int> InsUpdSiteAlias(RequestDto.ApInsUpdSiteAlias apInsUpdSiteAlias)
        {
            var siteAliasData = _mapper.Map<RequestDto.ApInsUpdSiteAlias, EntityDto.ApInsUpdSiteAlias>(apInsUpdSiteAlias);
            return await _lustRepository.ApInsUpdSiteAlias(siteAliasData);
        }
        public async Task ApDltSiteNameAlias(int siteNameAliasId)
        {
            await _lustRepository.ApDltSiteNameAlias(siteNameAliasId);
        }
        public async Task<IEnumerable<ResponseDto.ContactsStats>> GetContacts(string fname, string lname, string org, int sortColumn, int sortOrder, int pageNumber, int rowsPerPage)
        {
            if (fname != null && fname == "null") fname = null;
            if (lname != null && lname == "null") lname = null;
            if (org != null && org == "null") org = null;
            var resultList = new List<ResponseDto.ContactsStats>();
            foreach (var result in await _lustRepository.ApGetPartyByFirstLastOrgName(fname, lname, org, sortColumn, sortOrder, pageNumber, rowsPerPage))
            {
                resultList.Add(_mapper.Map<EntityDto.ContactsStats, ResponseDto.ContactsStats>(result));
            }
            return resultList;
        }


    }
}
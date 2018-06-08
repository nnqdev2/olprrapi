using System.Collections.Generic;
using System.Threading.Tasks;
using RequestDto = OlprrApi.Models.Request;
using ResponseDto = OlprrApi.Models.Response;

namespace OlprrApi.Services
{
    public interface IOlprrReviewService
    {
        Task<IEnumerable<ResponseDto.LustSiteAddressSearch>> SearchLust(RequestDto.LustSiteAddressSearch lustSiteAddressSearch);
        Task<ResponseDto.IncidentById> GetIncidentById(int olprrId);
        Task<IEnumerable<ResponseDto.ApGetLustSearch>> Search(RequestDto.LustSearchFilter lustSearchFilter);
        Task<ResponseDto.ApOLPRRGetContactByIdByContactType>GetContactByIdByContactType(int olprrId, string contactType);
        Task<IEnumerable<ResponseDto.ApOlprrGetIncidents>> GetIncidents(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);
        Task<ResponseDto.ApOlprrGetIncidentsWithStats> GetIncidentsWithStats (string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);

        Task<IEnumerable<ResponseDto.ApOlprrGetIncidentsStats>> GetIncidentsStats(string office, string status, string siteType, string olprrId
            , int sortColumn, int sortOrder, int pageNumber, int rowsPerPage);
    }
}

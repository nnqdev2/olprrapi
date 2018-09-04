using System;

namespace OlprrApi.Storage.Entities
{
    public class ApGetLustSearchDataStats
    {
        public int ReqPageNumber { get; set; }
        public int ReqRowsPerPage { get; set; }
        public int ReqSortColumn { get; set; }
        public int ReqSortOrder { get; set; }
        public int? TotalRows { get; set; }
        public int? TotalPages { get; set; }
        public int LustId { get; set; }
        public string LogNumber { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public DateTime? FirDt { get; set; }
        public DateTime? ClosedDt { get; set; }
        public string FacilityId { get; set; }
        public int? SiteScore { get; set; }
    }
}
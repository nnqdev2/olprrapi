using System;

namespace OlprrApi.Models.Response
{
    public class ApGetLustSearch
    {
        public int LustId { get; set; }
        public string LogNumber { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public DateTime? FirDt { get; set; }
        public DateTime? ClosedDt { get; set; }
        public string FacilityId { get; set; }
        public int SiteScore { get; set; }
    }
}

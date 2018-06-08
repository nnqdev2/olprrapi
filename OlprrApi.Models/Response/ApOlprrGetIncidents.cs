using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
    public class ApOlprrGetIncidents
    {
        public int OlprrId { get; set; }
        public string ReleaseType { get; set; }
        public string ReleaseTypeName { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int? FacilityId { get; set; }
        public string SiteName { get; set; }
        public string SiteCounty { get; set; }
        public string SiteAddress { get; set; }
        public string OtherAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteZipcode { get; set; }
        public string SitePhone { get; set; }
        public string SiteComment { get; set; }
        public int ContractorId { get; set; }
        public string SiteStatus { get; set; }
        public string ReportedBy { get; set; }
        public string ReportedByPhone { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string CountyName { get; set; }
    }
}

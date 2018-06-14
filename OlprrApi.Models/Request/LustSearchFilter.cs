using System;

namespace OlprrApi.Models.Request
{
    public class LustSearchFilter
    {
        public string LogCounty { get; set; }
        public string LogYear { get; set; }
        public string LogSeqNbr { get; set; }
        public string FacilityId { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteZipcode { get; set; }
        public string RegionCode { get; set; }
        public string ReleaseSiteTypeCode { get; set; }
        public string CleanUpSiteTypeId { get; set; }
        public int? FileStatusId { get; set; }
        public string ProjectManager { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactOrganization { get; set; }
        public int? TankStatusId { get; set; }
        public int? HotAuditRejectInd { get; set; }
        public int? CompareDate1Id { get; set; }
        public int? CompareDate2Id { get; set; }
        public DateTime? CompareDate1IdFromDate { get; set; }
        public DateTime? CompareDate1IdToDate { get; set; }
        public DateTime? CompareDate2IdFromDate { get; set; }
        public DateTime? CompareDate2IdToDate { get; set; }
        public int SortColumn { get; set; }
        public int SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
    }
}

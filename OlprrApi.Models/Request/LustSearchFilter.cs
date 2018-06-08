using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OlprrApi.Models.Request
{
    public class LustSearchFilter
    {

        [MaxLength(5)]
        //[Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string LogNumber { get; set; }
        public string logCounty { get; set; }
        public string logYear { get; set; }
        public string logSeqNbr { get; set; }
        public string facilityId { get; set; }
        public string siteName { get; set; }
        public string siteAddress { get; set; }
        public string siteCity { get; set; }
        public string siteZipcode { get; set; }
        public string regionName { get; set; }
        public string regionCode { get; set; }
        public bool regInd { get; set; }
        public bool hotInd { get; set; }
        public bool hotAuditReject { get; set; }
        public int siteType { get; set; }
        public int siteStatus { get; set; }
        public int compareDt1Idx { get; set; }
        public string fromDate1 { get; set; }
        public string toDate1 { get; set; }
        public int compareDt2Idx { get; set; }
        public string fromDate2 { get; set; }
        public string toDate2 { get; set; }
        public string projectMananger { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public string contactOrgName { get; set; }
        public int lustId { get; set; }
    }
}

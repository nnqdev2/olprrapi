using System;
using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Models.Request
{
    public class ApInsUpdIncidentData
    {
        public int LustIdIn { get; set; }
        public int? FacilityId { get; set; } = 0;
        public int CountyId { get; set; }
        //[Column("ReceivedDate")]
        public DateTime DateReceived { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        //[Column("SiteZip")]
        public string SiteZipcode { get; set; }
        public string SitePhone { get; set; } = "";
        public int NoValidAddress { get; set; } = 0;
        public int? SiteTypeId { get; set; } = 0;
        public int? FileStatusId { get; set; } = 0;
        public int? RegTankInd { get; set; } = 0;
        public int? HotInd { get; set; } = 0;
        public int? NonRegTankInd { get; set; } = 0;
        public int? BrownfieldCodeId { get; set; } = 0;
        public int? PropertyTranPendingInd { get; set; } = 0;
        public int? ProgramTransferInd { get; set; } = 0;
        public int? HotAuditRejectInd { get; set; } = 0;
        public int? ActiveReleaseInd { get; set; } = 0;
        public int? OptionLetterSentInd { get; set; } = 0;
        [MaxLength(8000)]
        public string SiteComment { get; set; }
        [MaxLength(8000)]
        public string SeeAlsoComment { get; set; }
        [MaxLength(2500)]
        public string PublicSummaryComment { get; set; }
        public int? GeoLocId { get; set; }
        public int? OlprrId { get; set; }
        public DateTime DiscoveryDate { get; set; }
        public int ManagementIdIn { get; set; }
        public DateTime? CleanupStartDt { get; set; }
        public DateTime? ReleaseStopDt { get; set; }
        public DateTime? FinalInvcRqstDt { get; set; }
        public DateTime? ClosedDt { get; set; }
        public DateTime? LetterOfAgreementDt { get; set; }
        [MaxLength(8000)]
        public string LetterOfAgreementComment { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlprrApi.Storage.Entities
{
    public class LustIncident
    {
        [Key]
        public int LustId { get; set; }
        public string LogNumber { get; set; }
        public string LogNbrCounty { get; set; }
        public int? FacilityId { get; set; }
        public int QtimeId { get; set; }
        public int? CrisCheck { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string SiteCity { get; set; }
        [Column("SiteZip")]
        public string SiteZipcode { get; set; }
        public string SitePhone { get; set; } = "";
        public int? NoValidAddress { get; set; }
        public int? SiteTypeId { get; set; } = 0;
        public int? FileStatusId { get; set; } = 0;
        public string ReleaseType { get; set; }
        public int RegulatedTankInd { get; set; } = 0;
        public int HotInd { get; set; } = 0;
        public int? NonRegTankInd { get; set; } = 0;
        public int? BrownfieldCodeId { get; set; } = 0;
        public int? PropertyTranPendingInd { get; set; } = 0;
        public int? ProgramTransferInd { get; set; } = 0;
        public int? HotAuditRejectInd { get; set; } = 0;
        public int? ActiveReleaseInd { get; set; } = 0;
        public int? OptionLetterSentInd { get; set; } = 0;
        public string SiteComment { get; set; }
        public string SeeAlsoComment { get; set; }
        public string PublicSummaryComment { get; set; }
       
        public int? GeolocId { get; set; }
        public int? OlprrId { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public Decimal? LatDegrees { get; set; }
        public Decimal? LatMinutes { get; set; }
        public Decimal? LatSeconds { get; set; }
        public Decimal? LatDecimals { get; set; }
        public Decimal? LongDegrees { get; set; }
        public Decimal? LongMinutes { get; set; }
        public Decimal? LongSeconds { get; set; }
        public Decimal? LongDecimals { get; set; }
        public int? ManagementId { get; set; }
        public DateTime? CleanupStartDate { get; set; }
        public DateTime? ReleaseStopDate { get; set; }
        public DateTime? FinalInvcRqstDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime? LetterOfAgreementDate { get; set; }
        public string LetterOfAgreementComment { get; set; }
        public string MgmtLastChangeBy { get; set; }
        public DateTime? MgmtLastChangeDate { get; set; }
        [Column("DiscoverDate")]
        public DateTime? DiscoveryDate { get; set; }
    }
}
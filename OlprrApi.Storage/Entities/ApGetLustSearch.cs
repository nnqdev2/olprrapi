using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlprrApi.Storage.Entities
{
    public class ApGetLustSearch
    {
        [Key]
        public int LustId { get; set; }
        public string LogNumber { get; set; }
        public string SiteName { get; set; }
        [Column("ADDRESS")]
        public string SiteAddress { get; set; }
        public DateTime? FirDt { get; set; }
        public DateTime? ClosedDt { get; set; }
        public string FacilityId { get; set; }
        public int SiteScore { get; set; }
    }
}

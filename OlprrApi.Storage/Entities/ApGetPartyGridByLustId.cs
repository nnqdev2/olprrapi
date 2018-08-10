using System;
using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class ApGetPartyGridByLustId
    {
        [Key]
        public int AffilId { get; set; }
        public string AffilTypeDesc { get; set; }
        public DateTime? AffilStartDate { get; set; }
        public DateTime? AffilEndDate { get; set; }
        public string PartyName { get; set; }
        public string Organization { get; set; }
    }
}

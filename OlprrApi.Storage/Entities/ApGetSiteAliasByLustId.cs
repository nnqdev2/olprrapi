using System;
using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class ApGetSiteAliasByLustId
    {
        [Key]
        public int SiteNameAliasId { get; set; }
        public string SiteNameAlias { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime? LastChangeDate { get; set; }
    }
}

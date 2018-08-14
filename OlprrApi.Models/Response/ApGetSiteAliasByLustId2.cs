using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
    public class ApGetSiteAliasByLustId2
    {
        public int SiteNameAliasId { get; set; }
        public string SiteNameAlias { get; set; }
        public string LastChangeBy { get; set; }
        public DateTime? LastChangeDate { get; set; }
        public int LustId { get; set; }
    }
}

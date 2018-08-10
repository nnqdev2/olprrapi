using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ApInsUpdSiteAlias
    {
        public int SiteNameAliasIdIn { get; set; }
        public int LustId { get; set; }
        public string SiteNameAlias { get; set; }
        public string LastChangeBy { get; set; }
    }
}

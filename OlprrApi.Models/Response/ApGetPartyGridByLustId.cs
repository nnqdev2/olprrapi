using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
    public class ApGetPartyGridByLustId
    {
        public int AffilId { get; set; }
        public string AffilTypeDesc { get; set; }
        public DateTime? AffilStartDate { get; set; }
        public DateTime? AffilEndDate { get; set; }
        public string PartyName { get; set; }
        public string Organization { get; set; }
    }
}

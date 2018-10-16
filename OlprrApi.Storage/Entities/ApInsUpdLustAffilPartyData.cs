using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ApInsUpdLustAffilPartyData
    {
        public int LustId { get; set; }
        public int? AffilId { get; set; }
        public string AffilType { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public string Organization { get; set; }       
        public string SubOrg { get; set; }
        public string Jobtitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }        
        public string Country { get; set; }
        public string AffilComments { get; set; }
        public string LastChangedBy { get; set; }
    }
}

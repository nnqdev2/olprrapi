using System;

namespace OlprrApi.Models.Response
{
    public class ApGetAffilById
    {
        public int AffilId { get; set; }
        public string AffilTypeCd { get; set; }
        public string AffilTypeDesc { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public int? PartyId { get; set; }
        public string Organization { get; set; }
        public string SubOrganization { get; set; }
        public string Jobtitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string AffilComments { get; set; }
        public string LastUpdBy { get; set; }
        public DateTime? LastUpdDttm { get; set; }
        public int? Zp4Checked { get; set; }
        public int LustId { get; set; }
        public string LogNumber { get; set; }
    }
}

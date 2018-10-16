using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
    public class ContactsStats
    {
        public string ReqFirstName { get; set; }
        public string ReqLastName { get; set; }
        public string ReqOrganization { get; set; }
        public int ReqPageNumber { get; set; }
        public int ReqRowsPerPage { get; set; }
        public int ReqSortColumn { get; set; }
        public int ReqSortOrder { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public int PartyId { get; set; }
        public string Organization { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonName { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string SubOrganization { get; set; }
    }
}

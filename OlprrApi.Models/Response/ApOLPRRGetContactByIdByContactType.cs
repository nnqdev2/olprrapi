using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
    public class ApOLPRRGetContactByIdByContactType
    {
        public int OlprrId { get; set; }
        public string ContactType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public int Result { get; set; }
    }
}

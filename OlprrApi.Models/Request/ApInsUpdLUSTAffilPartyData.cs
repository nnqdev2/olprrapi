using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OlprrApi.Models.Request
{
    public class ApInsUpdLustAffilPartyData
    {
        [Required]        
        public int LustId { get; set; }
        public int? AffilId { get; set; }
        [MaxLength(3)]
        public string AffilType { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        [MaxLength(40)]
        public string Organization { get; set; }
        [MaxLength(40)]
        public string SubOrg { get; set; }
        [MaxLength(40)]
        public string Jobtitle { get; set; }
        [MaxLength(40)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        [MaxLength(40)]
        public string Phone { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(56)]
        public string Street { get; set; }
        [MaxLength(25)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        [MaxLength(2)]
        public string State { get; set; }

        [MaxLength(25)]
        public string Country { get; set; }
        [MaxLength(2000)]
        public string AffilComments { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastChangedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ApOlprrGetUstLookupData
    {
        [Key]
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityZip { get; set; }
        public string CountyName { get; set; }
        public int CountyCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ApGetCountyIdAndNameFromZP4Fips
    {
        public int UsPostalCountyCodeFips { get; set; }
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
    }
}

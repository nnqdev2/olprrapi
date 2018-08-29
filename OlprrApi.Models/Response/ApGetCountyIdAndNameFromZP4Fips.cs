using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
    public class ApGetCountyIdAndNameFromZP4Fips
    {
        public int UsPostalCountyCodeFips { get; set; }
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
    }
}

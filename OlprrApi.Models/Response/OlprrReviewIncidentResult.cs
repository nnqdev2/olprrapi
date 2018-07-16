using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Models.Response
{
     public class OlprrReviewIncidentResult
    {
        public int OlprrId { get; set; }

        public string ErrorMessage { get; set; }
        public string LogNumberTemp { get; set; }
        public int LustIdTemp { get; set; }
    }
}

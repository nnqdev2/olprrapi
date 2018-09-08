using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ApInsUpdIncidentDataResult
    {
        public int? LustIdIn { get; set; }
        public int? OlprrId { get; set; }
        public string LogNumberOut { get; set; }
        public int LustIdOut { get; set; }
        public string ErrorMessageHandler { get; set; }
        public int? ResultSp { get; set; }
    }
}

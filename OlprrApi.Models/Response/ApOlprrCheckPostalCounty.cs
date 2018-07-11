namespace OlprrApi.Models.Response
{
    public class ApOlprrCheckPostalCounty
    {
        public int ReportedCountyCode { get; set; }
        public string UsPostalCountyCodeFips { get; set; }
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        public int ErrorCode { get; set; }
    }
}

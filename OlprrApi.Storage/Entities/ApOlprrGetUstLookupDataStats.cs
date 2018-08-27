namespace OlprrApi.Storage.Entities
{
    public class ApOlprrGetUstLookupDataStats
    {
        public int ReqPageNumber { get; set; }
        public int ReqRowsPerPage { get; set; }
        public int ReqSortColumn { get; set; }
        public int ReqSortOrder { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityZip { get; set; }
        public string CountyName { get; set; }
        public int CountyCode { get; set; }
    }
}

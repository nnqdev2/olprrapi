namespace OlprrApi.Models.Request
{
    public class UstSearchFilter
    {
        public string FacilityName { get; set; }
        public string FacilityAddress { get; set; }
        public string FacilityCity { get; set; }
        public string FacilityZip { get; set; }
        public int SortColumn { get; set; }
        public int SortOrder { get; set; }
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
    }
}

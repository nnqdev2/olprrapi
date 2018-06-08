using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ApOlprrGetIncidentsWithStats
    {
        public string DeqOffice { get; set; }
        public string IncidentStatus { get; set; }
        public string SiteType { get; set; }
        public string OlprrId { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int RowsPerPage { get; set; }
        public int SortColumn { get; set; }
        public int SortOrder { get; set; }
        public IEnumerable<ApOlprrGetIncidents> ApOlprrGetIncidents { get; set; }
    }
}

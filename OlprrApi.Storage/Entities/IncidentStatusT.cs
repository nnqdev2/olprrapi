using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class IncidentStatusT
    {
        [Key]
        public string IncidentStatus { get; set; }
        public int SortBy { get; set; }
    }
}

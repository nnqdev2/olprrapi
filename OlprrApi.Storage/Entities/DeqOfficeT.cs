using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class DeqOfficeT
    {
        [Key]
        public string DeqOffice { get; set; }
        public int SortBy { get; set; }
    }
}

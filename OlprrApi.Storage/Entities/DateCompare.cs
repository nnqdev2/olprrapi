using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class DateCompare
    {
        public string DateComparision { get; set; }
        [Key]
        public int ID { get; set; }
    }
}

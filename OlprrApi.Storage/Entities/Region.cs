using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class Region
    {
        [Key]
        public string RegionCode { get; set; }
        public string RegionDescription { get; set; }
    }
}

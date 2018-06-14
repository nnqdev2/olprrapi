using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class City
    {
        [Key]
        public string PlaceName { get; set; }

        public string PlaceName2 { get; set; }
    }
}

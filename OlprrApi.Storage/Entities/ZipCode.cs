using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class ZipCode
    {
        [Key]
        public string ZipCode1 { get; set; }
        public string ZipCode2 { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class ContactType
    {
        [Key]
        public string Sid { get; set; }
        public string Descript { get; set; }
    }
}

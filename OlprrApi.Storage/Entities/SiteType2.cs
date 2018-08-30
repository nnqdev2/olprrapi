using System.ComponentModel.DataAnnotations;
namespace OlprrApi.Storage.Entities
{
    public class SiteType2
    {
        [Key]
        public int Id { get; set; }
        public string Descript { get; set; }
    }
}

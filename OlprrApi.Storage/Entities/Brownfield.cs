using System.ComponentModel.DataAnnotations;
namespace OlprrApi.Storage.Entities
{
    public class Brownfield
    {
        [Key]
        public int Id { get; set; }
        public string Descript { get; set; }
    }
}

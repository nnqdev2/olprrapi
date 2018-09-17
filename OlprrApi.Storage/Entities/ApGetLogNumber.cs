using System.ComponentModel.DataAnnotations;
namespace OlprrApi.Storage.Entities
{
    public class ApGetLogNumber
    {
        [Key]
        public int LustId { get; set; }
        public string LogNumber { get; set; }
    }
}

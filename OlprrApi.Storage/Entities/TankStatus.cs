using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class TankStatus
    {       
        public string TankStatusDescription { get; set; }
        [Key]
        public int TankStatusId { get; set; }
    }
}


using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class CleanupSiteType
    {
        public string CleanupSiteTypeDescription { get; set; }
        [Key]
        public int CleanupSiteTypeId { get; set; }
    }
}

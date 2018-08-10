using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Models.Request
{
    public class ApInsUpdSiteAlias
    {
        [DefaultValue(0)]
        public int SiteNameAliasIdIn { get; set; }
        [Required]
        public int LustId { get; set; }
        [Required]
        [MaxLength(50)]
        public string SiteNameAlias { get; set; }
        [Required]
        [MaxLength(64)]
        public string LastChangeBy { get; set; }
    }
}

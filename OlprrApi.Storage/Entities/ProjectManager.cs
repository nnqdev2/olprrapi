using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class ProjectManager
    {
        [Key]
        public string ProjectManagerCode { get; set; }
        public string ProjectManagerDescription { get; set; }

    }
}

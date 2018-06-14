using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class FileStatus
    {
        public string FileStatusTypeDescription { get; set; }
        [Key]
        public int FileStatusTypeID { get; set; }
    }
}

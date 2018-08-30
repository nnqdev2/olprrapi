using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class ProjectManagerIncident
    {
        [Key]
        [Column("PmLogin")]
        public string ProjectManagerCode { get; set; }
        [Column("lf_nm")]
        public string ProjectManagerDescription { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
namespace OlprrApi.Models.Request
{
    public class OlprrReviewIncident
    {
        //[Required]
        public int LustIdIn { get; set; }
        //[Required]
        public int? FacilityId { get; set; }
        [Required]
        public int CountyId { get; set; }
        [Required]
        public DateTime DateReceived { get; set; }

        [Required]
        [MaxLength(40)]
        public string SiteName { get; set; }

        [Required]
        [MaxLength(40)]
        public string SiteAddress { get; set; }

        [Required]
        [MaxLength(20)]
        public string SiteCity { get; set; }

        [Required]
        [MaxLength(10)]
        public string SiteZipcode { get; set; }

        //[Required]
        [MaxLength(25)]
        public string SitePhone { get; set; } = "";

        [Required]
        public int NoValidAddress { get; set; } = 0;

        [Required]
        public int RegTankInd { get; set; } = 0;

        [Required]
        public int HotInd { get; set; } = 0;

        [Required]
        public int NonRegTankInd { get; set; } = 0;

        //[MaxLength(800)]
        public string InitialComment { get; set; }

        [Required]
        public int OlprrId { get; set; }

        //public string ErrorMessage { get; set; }
        //public string LogNumberTemp { get; set; }
        //public int LustIdTemp { get; set; }

        [Required]
        public DateTime DiscoveryDate { get; set; }

        [Required]
        //[MaxLength(2)]
        public string ConfirmationCode { get; set; }

        [Required]
        //[MaxLength(2)]
        public string DiscoveryCode { get; set; }

        [Required]
        //[MaxLength(2)]
        public string CauseCode { get; set; }

        [Required]
        //[MaxLength(2)]
        public int SourceId { get; set; }

        //Media data

        public int Soil { get; set; } = 0;

        public int GroundWater { get; set; } = 0;

        public int SurfaceWater { get; set; } = 0;

        public int DringkingWater { get; set; } = 0;

        public int Vapor { get; set; } = 0;

        public int FreeProduct { get; set; } = 0;

        //Contamimnant data

        public int UnleadedGas { get; set; } = 0;

        public int LeadedGas { get; set; } = 0;

        public int MisGas { get; set; } = 0;

        public int Diesel { get; set; } = 0;

        public int WasteOil { get; set; } = 0;

        public int HeatingOil { get; set; } = 0;

        public int Lubricant { get; set; } = 0;

        public int Solvent { get; set; } = 0;

        public int OtherPet { get; set; } = 0;

        public int Chemical { get; set; } = 0;

        public int Unknown { get; set; } = 0;

        public int Mtbe { get; set; } = 0;



        // Responsible Party data

        [MaxLength(40)]
        public string RpOrganization { get; set; }
        [MaxLength(40)]
        public string RpFirstName { get; set; }
        [MaxLength(40)]
        public string RpLastName { get; set; }
        [MaxLength(40)]
        public string RpPhone { get; set; }
        [MaxLength(40)]
        public string RpEmail { get; set; }
        [MaxLength(56)]
        public string RpAddress { get; set; }

        //[MaxLength(40)]
        //public string RpAddress2 { get; set; }

        [MaxLength(25)]
        public string RpCity { get; set; }

        [MaxLength(2)]
        public string RpState { get; set; }

        [MaxLength(10)]
        public string RpZipcode { get; set; }

        [MaxLength(25)]
        public string RpCountry { get; set; }

        [MaxLength(2000)]
        public string RpAffilComments { get; set; }

        // IC data

        [MaxLength(40)]
        public string IcOrganization { get; set; }

        [MaxLength(40)]
        public string IcFirstName { get; set; }

        [MaxLength(40)]
        public string IcLastName { get; set; }
        [MaxLength(40)]
        public string IcPhone { get; set; }

        [MaxLength(40)]
        public string IcEmail { get; set; }

        [MaxLength(56)]
        public string IcAddress { get; set; }

        [MaxLength(25)]
        public string IcCity { get; set; }

        [MaxLength(10)]
        public string IcZipcode { get; set; }

        [MaxLength(02)]
        public string IcState { get; set; }
        [MaxLength(25)]
        public string IcCountry { get; set; }

        [MaxLength(2000)]
        public string IcAffilComments { get; set; }



        [MaxLength(25)]
        public string AppId { get; set; }

        [Required]
        [MaxLength(8)]
        public string NewSiteStatus { get; set; }
    }
}

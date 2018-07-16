using System;
using System.Collections.Generic;
using System.Text;

namespace OlprrApi.Storage.Entities
{
    public class OlprrReviewIncident
    {
        public int LustIdIn { get; set; }
        public int FacilityId { get; set; }
        public int CountyId { get; set; }
        public DateTime DateReceived { get; set; }
        public string SiteName { get; set; }

        public string SiteAddress { get; set; }

        public string SiteCity { get; set; }

        public string SiteZipcode { get; set; }

        public string SitePhone { get; set; } = "";

        public int NoValidAddress { get; set; } = 0;

        public int RegTankInd { get; set; } = 0;

        public int HotInd { get; set; } = 0;

        public int NonRegTankInd { get; set; } = 0;

        public string InitialComment { get; set; }

        public int OlprrId { get; set; }

        //public string ErrorMessage { get; set; }
        //public string LogNumberTemp { get; set; }
        //public int LustIdTemp { get; set; }

        public DateTime DiscoveryDate { get; set; }
        public string ConfirmationCode { get; set; }
        public string DiscoveryCode { get; set; }
        public string CauseCode { get; set; }
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
        public string RpOrganization { get; set; }
        public string RpFirstName { get; set; }
        public string RpLastName { get; set; }
        public string RpPhone { get; set; }
        public string RpEmail { get; set; }
        public string RpAddress { get; set; }
        public string RpCity { get; set; }
        public string RpState { get; set; }
        public string RpZipcode { get; set; }
        public string RpCountry { get; set; }
        public string RpAffilComments { get; set; }

        // IC data
        public string IcOrganization { get; set; }
        public string IcFirstName { get; set; }
        public string IcLastName { get; set; }
        public string IcPhone { get; set; }
        public string IcEmail { get; set; }
        public string IcAddress { get; set; }
        public string IcCity { get; set; }
        public string IcZipcode { get; set; }
        public string IcState { get; set; }
        public string IcCountry { get; set; }
        public string IcAffilComments { get; set; }

        public string AppId { get; set; }

        public string NewSiteStatus { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace OlprrApi.Storage.Entities
{
    public class ApOlprrGetIncidentDataById
    {
        [Key]
        public int OlprrId { get; set; }
        public string ReleaseTypeCode { get; set; }
        public string ReleaseType { get; set; }
        public DateTime DateReceived { get; set; }
        public int? FacilityId { get; set; }
        public string SiteName { get; set; }
        public string SiteCounty { get; set; }
        public string SiteAddress { get; set; }
        public string OtherAddress { get; set; }
        public string SiteCity { get; set; }
        public string SiteZipcode { get; set; }
        public string SitePhone { get; set; }
        public string SiteComment { get; set; }
        public int ContractorId { get; set; }
        public string SiteStatus { get; set; }
        public string ReportedBy { get; set; }
        public string ReportedByPhone { get; set; }
        public string ContractorName { get; set; }
        public string ContractorEmail { get; set; }

        // Responsible Party data
        public string RpFirstName { get; set; }
        public string RpLastName { get; set; }
        public string RpOrganization { get; set; }
        public string RpAddress { get; set; }
        public string RpAddress2 { get; set; }
        public string RpCity { get; set; }
        public string RpState { get; set; }
        public string RpZipcode { get; set; }
        public string RpPhone { get; set; }
        public string RpEmail { get; set; }

        // IC data
        public string IcFirstName { get; set; }
        public string IcLastName { get; set; }
        public string IcOrganization { get; set; }
        public string IcAddress { get; set; }
        public string IcAddress2 { get; set; }
        public string IcCity { get; set; }
        public string IcState { get; set; }
        public string IcZipcode { get; set; }
        public string IcPhone { get; set; }
        public string IcEmail { get; set; }


        public DateTime DiscoveryDate { get; set; }

        public string ConfirmationCode { get; set; }
        public string ConfirmationDesc { get; set; }

        public string DiscoveryCode { get; set; }
        public string DiscoveryDesc { get; set; }
        public int? SourceId { get; set; }
        public string SourceDesc { get; set; }
        public string CauseCode { get; set; }
        public string CauseDesc { get; set; }





        //Media data
        public int GroundWater { get; set; }
        public int SurfaceWater { get; set; }
        public int DringkingWater { get; set; }
        public int Soil { get; set; }
        public int Vapor { get; set; }
        public int FreeProduct { get; set; }
        //Contamimnant data
        public int UnleadedGas { get; set; }
        public int LeadedGas { get; set; }
        public int? MisGas { get; set; }
        public int Diesel { get; set; }
        public int WasteOil { get; set; }
        public int HeatingOil { get; set; }
        public int Lubricant { get; set; }
        public int Solvent { get; set; }
        public int OtherPet { get; set; }
        public int Chemical { get; set; }
        public int? Unknown { get; set; }
        public int Mtbe { get; set; }

        public string InUseBy { get; set; }
    }
}

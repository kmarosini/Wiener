using PartnerWeb.Models.Common;
using PartnerWeb.Utils;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PartnerWeb.Models
{
    public class InsurancePolicy
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationConsts.Messages.PolicyNumberRequired)]
        [StringLength(15, MinimumLength = 10, ErrorMessage = ValidationConsts.Messages.PolicyNumberLengthInvalid)]
        [DisplayName("Broj police")]
        public string PolicyNumber { get; set; }

        [Required(ErrorMessage = ValidationConsts.Messages.PlicyPriceRequired)]
        [Range(0.01, double.MaxValue, ErrorMessage = ValidationConsts.Messages.PolicyPriceMustBeGreaterThanZero)]
        [DisplayName("Cijena police")]
        public decimal PolicyPrice { get; set; }

        [Required(ErrorMessage = ValidationConsts.Messages.PartnerRequired)]
        [DisplayName("Identifikacijski broj partnera")]
        public int PartnerId { get; set; }

        public bool IsValid()
        {
            bool isPolicyNumberValid = ValidatorUtil.IsValidPolicyNumber(PolicyNumber);
            bool isPartnerIdValid = ValidatorUtil.IsValidPartnerId(PartnerId);

            return isPolicyNumberValid &&
                   isPartnerIdValid;
        }

    }
}
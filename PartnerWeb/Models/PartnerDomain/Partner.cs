using PartnerWeb.Models.Common;
using PartnerWeb.Models.PartnerDomain.Enums;
using PartnerWeb.Utils;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PartnerWeb.Models
{
    public class Partner
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ValidationConsts.Messages.Required)]
        [DisplayName("Ime")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = ValidationConsts.Messages.FirstLastNameLengthInvalid)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = ValidationConsts.Messages.Required)]
        [DisplayName("Prezime")]
        [StringLength(255, MinimumLength = 2, ErrorMessage = ValidationConsts.Messages.FirstLastNameLengthInvalid)]
        public string LastName { get; set; }
        [DisplayName("Adresa")]
        public string Address { get; set; }
        [Required(ErrorMessage = ValidationConsts.Messages.Required)]
        [RegularExpression(RegexPatterns.TwentyDigitNumberRegex, ErrorMessage = ValidationConsts.Messages.PartnerNumberLengthInvalid)]
        [DisplayName("Broj partnera")]
        public string PartnerNumber { get; set; }
        [RegularExpression(RegexPatterns.ElevenDigitNumberRegex, ErrorMessage = ValidationConsts.Messages.CroatianPINInvalid)]
        [DisplayName("OIB")]
        public string CroatianPIN { get; set; }
        [DisplayName("Tip partnera")]
        public PartnerTypeEnum PartnerTypeId { get; set; }
        [DisplayName("Kreiran")]
        public DateTime? CreatedAtUtc { get; set; }
        [Required(ErrorMessage = ValidationConsts.Messages.Required)]
        [EmailAddress(ErrorMessage = ValidationConsts.Messages.InvalidEmail)]
        [DisplayName("Korisnika kreirao")]
        public string CreateByUser { get; set; }
        [DisplayName("Stranac")]
        public bool IsForeign { get; set; }
        [StringLength(20, MinimumLength = 10, ErrorMessage = ValidationConsts.Messages.ExternalCodeLengthInvalid)]
        [DisplayName("External Code")]
        public string ExternalCode { get; set; }
        [DisplayName("Spol")]
        public GenderTypeEnum GenderTypeId { get; set; }
        public int PolicyCount { get; set; }
        public decimal TotalPolicyAmount { get; set; }

        public bool IsValid()
        {
            bool isFirstNameValid = ValidatorUtil.IsValidName(FirstName);
            bool isLastNameValid = ValidatorUtil.IsValidName(LastName);
            bool isEmailValid = ValidatorUtil.IsValidEmail(CreateByUser);
            bool isPartnerNumberValid = ValidatorUtil.IsValidPartnerNumber(PartnerNumber);
            bool isPartnerTypeValid = Enum.IsDefined(typeof(PartnerTypeEnum), PartnerTypeId);
            bool isGenderValid = Enum.IsDefined(typeof(GenderTypeEnum), GenderTypeId);
            bool isExternalCodeValid = ValidatorUtil.IsValidExternalCode(ExternalCode);
            bool isCroatianPINValid = ValidatorUtil.IsValidCroatianPINNumber(CroatianPIN);

            return isFirstNameValid &&
                   isLastNameValid &&
                   isEmailValid &&
                   isPartnerNumberValid &&
                   isPartnerTypeValid &&
                   isExternalCodeValid &&
                   isGenderValid &&
                   isCroatianPINValid;
        }
    }
}
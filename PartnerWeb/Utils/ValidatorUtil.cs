namespace PartnerWeb.Utils
{
    public class ValidatorUtil
    {
        public static bool IsValidName(string name) => !string.IsNullOrWhiteSpace(name) && name.Length >= 2 && name.Length <= 255;

        public static bool IsValidEmail(string email) => !string.IsNullOrEmpty(email) && System.Text.RegularExpressions.Regex.IsMatch(email, RegexPatterns.EmailRegex);

        public static bool IsValidPartnerNumber(string partnerNumber) => !string.IsNullOrEmpty(partnerNumber) && partnerNumber.Length == 20;

        public static bool IsValidCroatianPINNumber(string croatianPIN) => !string.IsNullOrEmpty(croatianPIN) && croatianPIN.ToString().Length == 11;

        public static bool IsValidPartnerType(int partnerTypeId) => partnerTypeId != default;

        public static bool IsValidExternalCode(string externalCode) => !string.IsNullOrEmpty(externalCode) && externalCode.Length >= 10 && externalCode.Length <= 20;

        public static bool IsValidPolicyNumber(string policyNumber) => !string.IsNullOrEmpty(policyNumber) && policyNumber.Length >= 10 && policyNumber.Length <= 15;

        public static bool IsValidPolicyPrice(decimal policyPrice) => policyPrice != default;

        public static bool IsValidPartnerId(int partnerId) => partnerId != default;
    }
}
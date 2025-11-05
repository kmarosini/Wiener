namespace PartnerWeb.Utils
{
    public static class RegexPatterns
    {
        public const string TwentyDigitNumberRegex = @"^\d{20}$";
        public const string ElevenDigitNumberRegex = @"^\d{11}$";
        public const string EmailRegex = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
    }
}

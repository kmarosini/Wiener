namespace PartnerWeb.Models.Common
{
    public static class ValidationConsts
    {
        public static class Messages
        {
            public const string PolicyNumberRequired = "Broj police je obavezan podatak.";
            public const string PlicyPriceRequired = "Cijena police je obavezan podatak.";
            public const string PartnerRequired = "Partner je obavezan podatak.";
            public const string LengthInvalid = "* minimalna duljina je 2, a maksimalna duljina je 255";
            public const string PolicyNumberLengthInvalid = "Broj police mora sadržavati između 10 i 15 znakova.";
            public const string PolicyPriceMustBeGreaterThanZero = "Cijena police mora biti veća od 0kn.";
            public const string InsertPolicyError = "Greška prilikom dodavanja police.";
            public const string ContentNotValid = "Greška u poslanim podacima.";
            public const string Required = "* obavezno polje.";
            public const string InvalidEmail = "* neispravan e-mail.";
            public const string FirstLastNameLengthInvalid = "* minimalna duljina je 2, a maksimalna 255";
            public const string PartnerNumberLengthInvalid = "Broj partnera se mora sastojati od 20 znakova.";
            public const string CroatianPINInvalid = "Oib mora se mora sastojati od 11 znakova";
            public const string ExternalCodeLengthInvalid = "* minimalnda duljina je 10, a maksimalna 20";
        };
    }
}

namespace PartnerWeb.DataAccess.DB
{
    public static class StoredProcedures
    {
        public static class Partner
        {
            public const string DeletePartnerById = "DeletePartnerById";
            public const string GetAllPartners = "GetAllPartners";
            public const string PartnerUpdate = "PartnerUpdate";
            public const string GetPartnerById = "GetPartnerById";
            public const string AddPartner = "AddPartner";
        }

        public static class Policy
        {
            public const string GetPoliciesByPartner = "GetPoliciesByPartner";
            public const string GetPoliciesCountByPartner = "GetPoliciesCountByPartner";
            public const string AddPolicy = "AddPolicy";
        }
    }
}

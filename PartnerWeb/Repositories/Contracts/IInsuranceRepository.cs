using PartnerWeb.Models;

namespace PartnerWeb.Repositories
{
    public interface IInsuranceRepository
    {
        void CreateInsurancePolicy(InsurancePolicy policy);
    }
}

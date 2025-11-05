using PartnerWeb.Models;
using PartnerWeb.Models.Common;
using PartnerWeb.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PartnerWeb.Services
{
    public class InsurancePolicyService : IInsurancePolicyService
    {
        private readonly IInsuranceRepository _insuranceRepository;
        public InsurancePolicyService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public void CreateInsurancePolicy(InsurancePolicy policy)
        {
            if (!policy.IsValid())
            {
                throw new ValidationException(ValidationConsts.Messages.InsertPolicyError);
            }
            
            _insuranceRepository.CreateInsurancePolicy(policy);
        }
    }
}
using Dapper;
using PartnerWeb.DataAccess;
using PartnerWeb.DataAccess.DB;
using PartnerWeb.Models;

namespace PartnerWeb.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        public void CreateInsurancePolicy(InsurancePolicy policy)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(nameof(policy.PolicyNumber), policy.PolicyNumber);
            param.Add(nameof(policy.PolicyPrice), policy.PolicyPrice);
            param.Add(nameof(policy.PartnerId), policy.PartnerId);
            DapperORM.ExecuteWithoutReturn(StoredProcedures.Policy.AddPolicy, param);
        }
    }
}

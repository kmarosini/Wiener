using NSubstitute;
using PartnerWeb.Models;
using PartnerWeb.Models.Common;
using PartnerWeb.Repositories;
using PartnerWeb.Services;
using Shouldly;
using System.ComponentModel.DataAnnotations;

namespace PartnerWeb.Tests.Services
{
    public class InsurancePolicyServiceTests
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly InsurancePolicyService _service;

        public InsurancePolicyServiceTests()
        {
            _insuranceRepository = Substitute.For<IInsuranceRepository>();
            _service = new InsurancePolicyService(_insuranceRepository);
        }

        [Fact]
        public void CreateInsurancePolicy_Should_Create_When_Valid()
        {
            var validPolicy = new InsurancePolicy();
            validPolicy.PolicyNumber = "TEST123454";
            validPolicy.PartnerId = 1;

            _service.CreateInsurancePolicy(validPolicy);

            _insuranceRepository.Received(1).CreateInsurancePolicy(validPolicy);
        }

        [Fact]
        public void CreateInsurancePolicy_Should_Throw_When_Invalid()
        {
            var invalidPolicy = new InsurancePolicy();
            invalidPolicy.PolicyNumber = "INVALID";
            invalidPolicy.PartnerId = 0;

            var ex = Should.Throw<ValidationException>(() =>
                _service.CreateInsurancePolicy(invalidPolicy)
            );

            ex.Message.ShouldBe(ValidationConsts.Messages.InsertPolicyError);
            _insuranceRepository.DidNotReceive().CreateInsurancePolicy(Arg.Any<InsurancePolicy>());
        }
    }
}

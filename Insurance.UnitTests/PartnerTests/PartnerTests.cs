using NSubstitute;
using PartnerWeb.Models;
using PartnerWeb.Models.Common;
using PartnerWeb.Repositories;
using PartnerWeb.Services;
using Shouldly;
using System.ComponentModel.DataAnnotations;

namespace PartnerWeb.Tests.Services
{
    public class PartnerServiceTests
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly PartnerService _partnerService;

        public PartnerServiceTests()
        {
            _partnerRepository = Substitute.For<IPartnerRepository>();
            _partnerService = new PartnerService(_partnerRepository);
        }   

        [Fact]
        public void GetPartnerById_Should_Return_Partner()
        {
            var expected = new Partner { Id = 5 };
            _partnerRepository.GetById(5).Returns(expected);

            var result = _partnerService.GetPartnerById(5);

            result.ShouldBe(expected);
        }

        [Fact]
        public void GetAllPartners_Should_Return_List()
        {
            var partners = new List<Partner> { new Partner { Id = 1 } };
            _partnerRepository.GetAllPartners().Returns(partners);

            var result = _partnerService.GetAllPartners();

            result.ShouldBe(partners);
            result.ShouldContain(p => p.Id == 1);
        }

        [Fact]
        public void DeletePartner_Should_Call_Repository_Delete()
        {
            var id = 42;
            _partnerService.DeletePartner(id);
            _partnerRepository.Received(1).Delete(id);
        }
    }
}

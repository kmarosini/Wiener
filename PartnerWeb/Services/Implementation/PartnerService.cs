using PartnerWeb.Models;
using PartnerWeb.Models.Common;
using PartnerWeb.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PartnerWeb.Services
{
    public class PartnerService : IPartnerService
    {

        private readonly IPartnerRepository _partnerRepository;

        public PartnerService(IPartnerRepository repository)
        {
            _partnerRepository = repository;
        }

        public void CreatePartner(Partner partner)
        {
            if (!partner.IsValid())
            {
                throw new Exception(ValidationConsts.Messages.ContentNotValid);
            }

            _partnerRepository.Add(partner);
        }

        public void DeletePartner(int id)
        {
            _partnerRepository.Delete(id);
        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return _partnerRepository.GetAllPartners();
        }

        public Partner GetPartnerById(int id)
        {
            return _partnerRepository.GetById(id);
        }

        public void UpdatePartner(Partner partner)
        {
            if (!partner.IsValid())
            {
                throw new ValidationException(ValidationConsts.Messages.ContentNotValid);
            }
            
            _partnerRepository.Update(partner);
        }
    }
}
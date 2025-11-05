using PartnerWeb.Models;
using System.Collections.Generic;

namespace PartnerWeb.Services
{
    public interface IPartnerService
    {
        IEnumerable<Partner> GetAllPartners();
        void CreatePartner(Partner partner);
        void UpdatePartner(Partner partner);
        void DeletePartner(int id);
        Partner GetPartnerById(int id);
    }
}

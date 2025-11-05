using PartnerWeb.Models;
using System.Collections.Generic;

namespace PartnerWeb.Repositories
{
    public interface IPartnerRepository
    {
        IEnumerable<Partner> GetAllPartners();
        void Add(Partner partner);
        void Update(Partner partner);
        void Delete(int id);
        Partner GetById(int id);
    }
}

using Dapper;
using PartnerWeb.DataAccess;
using PartnerWeb.DataAccess.DB;
using PartnerWeb.Models;
using System;
using System.Collections.Generic;

namespace PartnerWeb.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        public void Add(Partner partner)
        {
            var param = new DynamicParameters();
            param.Add(nameof(partner.FirstName), partner.FirstName);
            param.Add(nameof(partner.LastName), partner.LastName);
            param.Add(nameof(partner.Address), partner.Address);
            param.Add(nameof(partner.PartnerNumber), Convert.ToDecimal(partner.PartnerNumber));
            param.Add(nameof(partner.CroatianPIN), partner.CroatianPIN);
            param.Add(nameof(partner.PartnerTypeId), partner.PartnerTypeId);
            param.Add(nameof(partner.CreateByUser), partner.CreateByUser);
            param.Add(nameof(partner.IsForeign), partner.IsForeign);
            param.Add(nameof(partner.ExternalCode), partner.ExternalCode);
            param.Add(nameof(partner.GenderTypeId), partner.GenderTypeId);

            DapperORM.ExecuteWithoutReturn(StoredProcedures.Partner.AddPartner, param);
        }

        public void Delete(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            DapperORM.ExecuteWithoutReturn(StoredProcedures.Partner.DeletePartnerById, param);
        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return DapperORM.ReturnList<Partner>(StoredProcedures.Partner.GetAllPartners);
        }

        public Partner GetById(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            return DapperORM.ReturnSingle<Partner>(StoredProcedures.Partner.GetPartnerById, param);
        }

        public void Update(Partner partner)
        {
            var param = new DynamicParameters();
            param.Add(nameof(partner.Id), partner.Id);
            param.Add(nameof(partner.FirstName), partner.FirstName);
            param.Add(nameof(partner.LastName), partner.LastName);
            param.Add(nameof(partner.Address), partner.Address);
            param.Add(nameof(partner.PartnerNumber), Convert.ToDecimal(partner.PartnerNumber));
            param.Add(nameof(partner.CroatianPIN), partner.CroatianPIN);
            param.Add(nameof(partner.PartnerTypeId), partner.PartnerTypeId);
            param.Add(nameof(partner.CreateByUser), partner.CreateByUser);
            param.Add(nameof(partner.IsForeign), partner.IsForeign);
            param.Add(nameof(partner.ExternalCode), partner.ExternalCode);
            param.Add(nameof(partner.GenderTypeId), partner.GenderTypeId);

            DapperORM.ExecuteWithoutReturn(StoredProcedures.Partner.PartnerUpdate, param);
        }
    }
}

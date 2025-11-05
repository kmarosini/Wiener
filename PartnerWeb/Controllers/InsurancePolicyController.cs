using PartnerWeb.Models;
using PartnerWeb.Repositories;
using PartnerWeb.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PartnerWeb.Controllers
{
    public class InsurancePolicyController : Controller
    {
        private readonly IInsurancePolicyService _insurancePolicyService;
        private readonly IPartnerService _partnerService;

        public InsurancePolicyController(IInsurancePolicyService insurancePolicyService, IPartnerService partnerService)
        {
            _partnerService = partnerService;
            _insurancePolicyService = insurancePolicyService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            IEnumerable<Partner> partners = _partnerService.GetAllPartners();
            List<SelectListItem> partnerItems = partners.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = $"{p.FirstName} {p.LastName}" }).ToList();
            ViewBag.Partners = partnerItems;
   
            return View();
        }

        [HttpPost]
        public ActionResult Create(InsurancePolicy policy)
        {
            _insurancePolicyService.CreateInsurancePolicy(policy);
            return RedirectToAction("Index", "Partner");
        }
    }
}
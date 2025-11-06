using PartnerWeb.DataAccess;
using PartnerWeb.Models;
using PartnerWeb.Models.PartnerDomain.Enums;
using PartnerWeb.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PartnerWeb.Controllers
{
    public class PartnerController : Controller
    {
        private readonly IPartnerService _partnerService;

        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        // GET: Partner
        public ActionResult Index()
        {
            ViewBag.NewRecordId = TempData["NewRecord"];
            return View(_partnerService.GetAllPartners());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PartnerTypes = new SelectList(Enum.GetValues(typeof(PartnerTypeEnum)).Cast<PartnerTypeEnum>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }), "Value", "Text");

            ViewBag.GenderTypes = new SelectList(Enum.GetValues(typeof(GenderTypeEnum)).Cast<GenderTypeEnum>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }), "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Partner partner)
        {
            _partnerService.CreatePartner(partner);
            TempData["NewRecord"] = partner.ExternalCode;

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var partner = _partnerService.GetPartnerById(id);
            ViewBag.PartnerTypes = new SelectList(Enum.GetValues(typeof(PartnerTypeEnum)).Cast<PartnerTypeEnum>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }), "Value", "Text", partner.PartnerTypeId);

            ViewBag.GenderTypes = new SelectList(Enum.GetValues(typeof(GenderTypeEnum)).Cast<GenderTypeEnum>().Select(e => new SelectListItem
            {
                Value = ((int)e).ToString(),
                Text = e.ToString()
            }), "Value", "Text", partner.GenderTypeId);

            return View(partner);
        }

        [HttpPost]
        public ActionResult Edit(Partner partner)
        {
            _partnerService.UpdatePartner(partner);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _partnerService.DeletePartner(id);
            return RedirectToAction("Index");
        }
    }
}
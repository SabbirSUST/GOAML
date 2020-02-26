using System.Web.Mvc;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;
using RepositoryCloud.IRepositories;

namespace GOAML.Display.Controllers
{
    public class BusinessInformationController : Controller
    {
        //
        // GET: /BusinessInformation/

        private readonly IBusinessInfoRepository _businessInfoRepository;
        private readonly ITaddressRepository _taddressRepository;
        private readonly IPhoneInformationRepository _phoneInformationRepository;
        private readonly ITEntityRepository _tEntityRepository;

        public BusinessInformationController(ITEntityRepository tEntityRepository, IPhoneInformationRepository phoneInformationRepository, ITaddressRepository taddressRepository, IBusinessInfoRepository businessInfoRepository)
        {
            _tEntityRepository = tEntityRepository;
            _phoneInformationRepository = phoneInformationRepository;
            _taddressRepository = taddressRepository;
            _businessInfoRepository = businessInfoRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Business Information";
            ViewBag.Country = DropDownListClass.GetCountryCodeses();
            ViewBag.CommunicationTypes = DropDownListClass.GetCommunicationTypes();
            ViewBag.ContactTypes = DropDownListClass.GetContactTypes();
            ViewBag.DivisionNames = DropDownListClass.GetDivisionNames();
            ViewBag.DistrictNames = DropDownListClass.GetDistrictNames();
            ViewBag.ThanaNames = DropDownListClass.GetThanaNames();
            ViewBag.LegalFormTypes = DropDownListClass.GetLegalFormType();
            ViewBag.YesNoList = DropDownListClass.GetYesNoSelectList();
            return View();
        }

        [HttpGet]
        public JsonResult GetCustomerInformation(long cifNumber)
        {
            var x = _businessInfoRepository.GetBusinessInformation(cifNumber);
            //x.ReturnValue = null;
            //var t = x.ReturnValue;
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveBusinessInformation(Tentity tentity)
        {
            var response = _tEntityRepository.SaveBusinessEntity(tentity);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveBusinessAddress(Taddress taddress)
        {
            var response = _taddressRepository.SaveTaddress(taddress);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveBusinessPhone(Tphone tphone)
        {
            var response = _phoneInformationRepository.SaveTphone(tphone);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
	}
}
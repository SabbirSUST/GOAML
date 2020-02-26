using System.Web.Mvc;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;
using RepositoryCloud.IRepositories;

namespace GOAML.Display.Controllers
{
    public class IndividualInformationController : Controller
    {
        //
        // GET: /IndividualInformation/
        private readonly IIndividualInformationRepository _individualInformationRepository;
        private readonly ITpersonMyClientRepository _tpersonMyClientRepository;
        private readonly ITaddressRepository _taddressRepository;
        private readonly IPhoneInformationRepository _phoneInformationRepository;
        private readonly IPersonIdentificationRepository _personIdentificationRepository;

        public IndividualInformationController(IPersonIdentificationRepository personIdentificationRepository, IPhoneInformationRepository phoneInformationRepository, ITaddressRepository taddressRepository, ITpersonMyClientRepository tpersonMyClientRepository, IIndividualInformationRepository individualInformationRepository)
        {
            _personIdentificationRepository = personIdentificationRepository;
            _phoneInformationRepository = phoneInformationRepository;
            _taddressRepository = taddressRepository;
            _tpersonMyClientRepository = tpersonMyClientRepository;
            _individualInformationRepository = individualInformationRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Individual Customer Information";
            //var directorList = DropDownListClass.GetTaskStatusList();
            ViewBag.DirectorList = DropDownListClass.GetTaskStatusList();
            ViewBag.Gender = DropDownListClass.GetGenderList();
            ViewBag.Country = DropDownListClass.GetCountryCodeses();
            ViewBag.IdentificationTypes = DropDownListClass.GetIdentificationTypes();
            ViewBag.CommunicationTypes = DropDownListClass.GetCommunicationTypes();
            ViewBag.ContactTypes = DropDownListClass.GetContactTypes();
            ViewBag.DivisionNames = DropDownListClass.GetDivisionNames();
            ViewBag.DistrictNames = DropDownListClass.GetDistrictNames();
            ViewBag.ThanaNames = DropDownListClass.GetThanaNames();
            ViewBag.BranchList = DropDownListClass.GetBranches();
            return View();
        }
        [HttpGet]
        public JsonResult GetIndividualInformation(long cifNumber)
        {
            var x = _individualInformationRepository.GetIndividualInformation(cifNumber);
            //x.ReturnValue = null;
            //var t = x.ReturnValue;
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveIndividualInformation(TpersonMyClient tpersonMyClient)
        {
            var response = _tpersonMyClientRepository.SaveTpersonMyClient(tpersonMyClient);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveIndividualAddress(Taddress taddress)
        {
            var response = _taddressRepository.SaveTaddress(taddress);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveIndividualPhone(Tphone tphone)
        {
            var response = _phoneInformationRepository.SaveTphone(tphone);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveIndividualIdentificaiton(TpersonIdentification tpersonIdentification)
        {
            var response = _personIdentificationRepository.SaveTpersonIdentification(tpersonIdentification);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
	}
}
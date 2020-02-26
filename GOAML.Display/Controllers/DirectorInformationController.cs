using System.Web.Mvc;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;
using RepositoryCloud.IRepositories;

namespace GOAML.Display.Controllers
{
    public class DirectorInformationController : Controller
    {
        //
        // GET: /DirectorInformation/
        private readonly IRoleTypeRepository _roleTypeRepository;
        private readonly IDirectorInformationRepository _directorInformationRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly ITaddressRepository _taddressRepository;
        private readonly IPhoneInformationRepository _phoneInformationRepository;
        private readonly IPersonIdentificationRepository _personIdentificationRepository;

        public DirectorInformationController(IPersonIdentificationRepository personIdentificationRepository, IPhoneInformationRepository phoneInformationRepository, ITaddressRepository taddressRepository, IDirectorRepository directorRepository, IDirectorInformationRepository directorInformationRepository, IRoleTypeRepository roleTypeRepository)
        {
            _personIdentificationRepository = personIdentificationRepository;
            _phoneInformationRepository = phoneInformationRepository;
            _taddressRepository = taddressRepository;
            _directorRepository = directorRepository;
            _directorInformationRepository = directorInformationRepository;
            _roleTypeRepository = roleTypeRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Director Information";
            //var directorList = DropDownListClass.GetTaskStatusList();
            ViewBag.DirectorList = DropDownListClass.GetTaskStatusList();
            ViewBag.RoleInCompany = _roleTypeRepository.GetRoleTypes("C");
            ViewBag.Gender = DropDownListClass.GetGenderList();
            ViewBag.Country = DropDownListClass.GetCountryCodeses();
            ViewBag.IdentificationTypes = DropDownListClass.GetIdentificationTypes();
            ViewBag.CommunicationTypes = DropDownListClass.GetCommunicationTypes();
            ViewBag.ContactTypes = DropDownListClass.GetContactTypes();
            ViewBag.DivisionNames = DropDownListClass.GetDivisionNames();
            ViewBag.DistrictNames = DropDownListClass.GetDistrictNames();
            ViewBag.ThanaNames = DropDownListClass.GetThanaNames();
            return View();
        }
        [HttpGet]
        public JsonResult GetDirectorInformation(long cifNumber)
        {
            var x = _directorInformationRepository.GetDirectorInformation(cifNumber);
            //x.ReturnValue = null;
            //var t = x.ReturnValue;
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDirectorInformation(DirectorDetail directorDetails)
        {
            var response = _directorRepository.SaveDirectorDetails(directorDetails);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveDirectorAddress(Taddress taddress)
        {
            var response = _taddressRepository.SaveTaddress(taddress);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDirectorPhone(Tphone tphone)
        {
            var response = _phoneInformationRepository.SaveTphone(tphone);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDirectorIdentificaiton(TpersonIdentification tpersonIdentification)
        {
            var response = _personIdentificationRepository.SaveTpersonIdentification(tpersonIdentification);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
	}
}
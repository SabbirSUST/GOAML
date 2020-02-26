using System.Web.Mvc;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;


namespace GOAML.Display.Controllers
{
    public class CustomerInformationEntryController : Controller
    {
        private readonly IAccountInfoUpdateRepository _accountInfoUpdateRepository;

        public CustomerInformationEntryController(IAccountInfoUpdateRepository accountInfoUpdateRepository)
        {
            _accountInfoUpdateRepository = accountInfoUpdateRepository;
        }

        //
        // GET: /CustomerInformationEntry/
        public ActionResult Index()
        {
            ViewBag.Title = "Customer Information Update";
            ViewBag.CurrencyList = DropDownListClass.GetCurrencyList();
            ViewBag.AccStatusList = DropDownListClass.GetAccStatusList();
            ViewBag.AccRoleList = DropDownListClass.GetRoleList();
            ViewBag.AccTypeList = DropDownListClass.GetAccountTypeList();
            ViewBag.SignatoryStatusList = DropDownListClass.GetSignatoryStatusList();
            return View();
        }

        [HttpGet]
        public JsonResult GetCustomerInfo(string cifNumber)
        {
            var x = _accountInfoUpdateRepository.GetAccountInfoUpdate(cifNumber);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveCustomerInfoUpdate(TaccountMyClientBucket taccountMyClientBucket)
        {
            var response = _accountInfoUpdateRepository.SaveAccountInfoUpdate(taccountMyClientBucket);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
	}
}
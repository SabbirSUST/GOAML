using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOAML.Repository.CustomStatic;

namespace GOAML.Display.Controllers
{
    public class CibReportController : Controller
    {
        // GET: CibReport
        public ActionResult Index()
        {
            ViewBag.SubjectRoleList = DropDownListClass.GetSubjectRole();
            return View();
        }
    }
}
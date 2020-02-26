using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using GOAML.DomainModels.GlobalVariable;
using GOAML.DomainModels.LocalObjects;
using GOAML.Repository.CustomStatic;
using GOAML.Repository.IRepositories;

namespace GOAML.Display.Controllers
{
    public class WinFosFileUploadController : Controller
    {
        private readonly ITAccountMyClientRepository _repository;

        public WinFosFileUploadController(ITAccountMyClientRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /WinFosFileUpload/
        public ActionResult Index(DbResponse dbResponse)
        {

            ViewBag.MessageType = dbResponse.MessageType;
            ViewBag.Message = dbResponse.Message;
            var mystr = "";
            if (dbResponse.ReturnValue != null)
            {
                var pi = (string[])dbResponse.ReturnValue;
                mystr = pi[0];
            }
            ViewBag.ReturnValue = mystr ?? "";
            return View();
        }

        //[HttpPost]
        //public JsonResult CustomerAccountUpdate(List<TaccountMyClient> taccountMyClients)
        //{
        //    var response = _repository.SaveTaccountMyClientInBatch(taccountMyClients);
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public JsonResult CustomerInfoUpload(List<CustomerInformation> customerInformations)
        //{
        //    var response = _repository.SaveCustomerInformationInBatch(customerInformations);
        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult CustomerAccountUpdate()
        {
            var dbResponse = System128.FailureMessage("Job Failed");
            if (Request.Files.Count <= 0) return RedirectToAction("Index", dbResponse);
            var file = Request.Files[0];
            // Read bytes from http input stream
            if (file == null) return RedirectToAction("Index");
            var b = new BinaryReader(file.InputStream);
            var binData = b.ReadBytes(Convert.ToInt32(file.InputStream.Length));
            var result = System.Text.Encoding.UTF8.GetString(binData);
            dbResponse = _repository.SaveTaccountMyClientInBatch(result);
            return RedirectToAction("Index", dbResponse);
        }
        [HttpPost]
        public ActionResult CustomerInfoUpload()
        {
            var dbResponse = System128.FailureMessage("Job Failed");
            if (Request.Files.Count <= 0) return RedirectToAction("Index", dbResponse);
            var file = Request.Files[0];
            // Read bytes from http input stream
            if (file == null) return RedirectToAction("Index");
            var b = new BinaryReader(file.InputStream);
            var binData = b.ReadBytes(Convert.ToInt32(file.InputStream.Length));
            var result = System.Text.Encoding.UTF8.GetString(binData);
            dbResponse = _repository.SaveCustomerInformationInBatch(result);
            return RedirectToAction("Index", dbResponse);
        }
    }
}
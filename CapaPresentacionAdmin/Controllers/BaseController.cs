using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult ResponseJson(string messageError, int id)
        {
            return Json(new { mensaje = messageError, Id = id }, JsonRequestBehavior.AllowGet);
        }
    }
}
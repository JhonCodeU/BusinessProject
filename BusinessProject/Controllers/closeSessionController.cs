using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessProject.Controllers
{
    public class closeSessionController : Controller
    {
        // GET: closeSession
        public ActionResult Login()
        {
            Session["User"] = null;

            return RedirectToAction("Login", "Acceso");
            //return View();
        }
    }
}
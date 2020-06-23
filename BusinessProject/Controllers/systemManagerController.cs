using System;
using BusinessProject.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessProject.Controllers
{
    public class systemManagerController : Controller
    {
        // GET: systemManager
        [AuthorizeUser(idOperacion: 3)]
        public ActionResult System()
        {
            return View();
        }
    }
}
using BusinessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessProject.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string User, string Pass)
        {
            try
            {
                using (Models.BusinessProjectEntities db = new Models.BusinessProjectEntities())
                {
                    var oUser = (from d in db.usuarios
                                 where d.email == User.Trim() && d.password == Pass.Trim()
                                 select d).FirstOrDefault();

                    var salesman = (from d in db.ServiceSalesmen
                                 select d.idServiceSalesman);

                    Console.WriteLine(salesman);

                    if (oUser == null)
                    {
                        ViewBag.Error = "Usuario o contraseña invalida";
                        return View();
                    }

                    Session["User"] = oUser;

                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}
using apr.Business;
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace apr.WebMVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult findAll()
        {
            List<Clientes> clientes = new List<Clientes>();
            try
            {
                clientes = new ClientesBll().findAll();
            }
            catch (Exception ex)
            {

            }

            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
    }
}